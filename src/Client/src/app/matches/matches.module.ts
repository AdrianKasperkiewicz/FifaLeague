import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatchesRoutingModule } from './matches-routing.module';
import { AddScoreComponent } from './pages/add-score/add-score.component';
import { MaterialModule } from '../shared/modules/material-module';
import { FlexLayoutModule } from '@angular/flex-layout';

@NgModule({
  declarations: [AddScoreComponent],
  imports: [
    CommonModule,
    MatchesRoutingModule,
    MaterialModule,
    FlexLayoutModule
  ]
})
export class MatchesModule { }
