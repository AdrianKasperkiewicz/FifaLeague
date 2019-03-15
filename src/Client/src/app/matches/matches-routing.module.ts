import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddScoreComponent } from './pages/add-score/add-score.component';

const routes: Routes = [{
  path: 'addscore',
  component: AddScoreComponent
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MatchesRoutingModule { }
