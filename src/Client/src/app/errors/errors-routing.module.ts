import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppErrorComponent } from './app-error/app-error.component';
import { NotFoundComponent } from './not-found/not-found.component';

const routes: Routes = [{
  path: 'app',
  component: AppErrorComponent
},
{
  path: 'notfound',
  component: NotFoundComponent
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ErrorsRoutingModule { }
