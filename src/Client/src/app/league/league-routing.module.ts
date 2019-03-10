import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FixtureComponent } from './fixture/fixture.component';

const routes: Routes =
  [{
    path: 'fixture',
    component: FixtureComponent
  }]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LeagueRoutingModule { }
