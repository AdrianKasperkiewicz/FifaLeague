import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ErrorsRoutingModule } from './errors-routing.module';
import { AppErrorComponent } from './app-error/app-error.component';
import { NotFoundComponent } from './not-found/not-found.component';

@NgModule({
  declarations: [AppErrorComponent, NotFoundComponent],
  imports: [
    CommonModule,
    ErrorsRoutingModule
  ]
})
export class ErrorsModule { }
