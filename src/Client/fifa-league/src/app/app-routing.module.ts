import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddTeamComponent } from './pages/add-team/add-team.component';
import { TeamListComponent } from './pages/team-list/team-list.component';
import { HomeComponent } from './pages/home/home.component';
import { SeasonsComponent } from './pages/seasons/seasons.component';
import { AddFirstSeasonComponent } from './pages/add-first-season/add-first-season.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'team', component: TeamListComponent },
  { path: 'team/add', component: AddTeamComponent },
  { path: 'season', component: SeasonsComponent },
  { path: 'season/add', component: AddFirstSeasonComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
