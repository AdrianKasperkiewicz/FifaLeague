import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NewSeasonComponent } from './pages/new-season/new-season.component';

const routes: Routes = [{
  path: 'newseason',
  component: NewSeasonComponent
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SettingsRoutingModule { }
