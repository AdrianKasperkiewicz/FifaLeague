import { ErrorHandler, Injectable, Injector, Inject } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';


@Injectable()
export class ErrorsHandler implements ErrorHandler {

  constructor(@Inject(Injector) private readonly injector: Injector) {
  }

  handleError(error: Error | HttpErrorResponse) {
    const router = this.injector.get(Router);

    if (error instanceof HttpErrorResponse) {
      // Server error happened
      if (!navigator.onLine) {
        // No Internet connection
        this.toastrService.error('No Internet Connection', null, { onActivateTick: true });
      }
      // Http Error
      this.toastrService.error(`${error.status} - ${error.message}`, null, { onActivateTick: true });
    } else {
      // Client Error Happend
      // Send the error to the server and then
      // router.navigate(['/error'], { queryParams: errorWithContextInfo });
      this.toastrService.error('${error}', null, { onActivateTick: true });
    }
  }

  private get toastrService(): ToastrService {
    return this.injector.get(ToastrService);
  }
}
