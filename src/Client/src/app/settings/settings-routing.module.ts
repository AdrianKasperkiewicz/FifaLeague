import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NewSeasonComponent } from './pages/new-season/new-season.component';
import { TeamsComponent } from './pages/teams/teams.component';
const routes: Routes = [{
  path: 'newseason',
  component: NewSeasonComponent
}, {
  path: 'teams',
  component: TeamsComponent
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SettingsRoutingModule { }
