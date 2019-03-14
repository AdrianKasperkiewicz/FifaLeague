import { ErrorHandler, Injectable, Injector, Inject } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { environment } from '../../../environments/environment';


@Injectable()
export class ErrorsHandler implements ErrorHandler {

  constructor(@Inject(Injector) private readonly injector: Injector) {
  }

  handleError(error: Error | HttpErrorResponse) {
    const router = this.injector.get(Router);
    console.log(error);

    if (error instanceof HttpErrorResponse) {
      // Server error
      if (!navigator.onLine) {
        // No Internet connection
        this.toastrService.error('No Internet Connection', null, { onActivateTick: true });
      }

      // Http Error
      let message;
      if (environment.production === true) {
        message = `Sorry but error occurees : ${error.error.message}`;
      } else {
        message = `Dev: ${error.status} : ${error.error.message}`;
      }

      this.toastrService.error(message, null, { onActivateTick: true });
    } else {
      router.navigate(['/error/app']);
      this.toastrService.error(error.message, null, { onActivateTick: true });
    }
  }

  private get toastrService(): ToastrService {
    return this.injector.get(ToastrService);
  }
}
