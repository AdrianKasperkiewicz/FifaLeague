import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddTeamComponent } from './pages/add-team/add-team.component';
import { TeamListComponent } from './pages/team-list/team-list.component';

const routes: Routes = [
  { path: 'team', component: TeamListComponent },
  { path: 'team/add', component: AddTeamComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
