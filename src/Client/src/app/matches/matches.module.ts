import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatchesRoutingModule } from './matches-routing.module';
import { AddScoreComponent } from './pages/add-score/add-score.component';
import { MaterialModule } from '../shared/modules/material-module';

@NgModule({
  declarations: [AddScoreComponent],
  imports: [
    CommonModule,
    MatchesRoutingModule,
    MaterialModule
  ]
})
export class MatchesModule { }
