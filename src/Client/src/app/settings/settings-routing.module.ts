import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NewSeasonComponent } from './pages/new-season/new-season.component';
import { DivisionsComponent } from './pages/divisions/divisions.component';
import { TeamsComponent } from './pages/teams/teams.component';
import { StartSeasonComponent } from './pages/start-season/start-season.component';
const routes: Routes = [{
  path: 'newseason',
  component: NewSeasonComponent
}, {
  path: 'divisions',
  component: DivisionsComponent
},
{
  path: 'teams',
  component: TeamsComponent
},
{
  path: 'startseason',
  component: StartSeasonComponent
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SettingsRoutingModule { }
