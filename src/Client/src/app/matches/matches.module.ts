import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatchesRoutingModule } from './matches-routing.module';
import { AddScoreComponent } from './pages/add-score/add-score.component';
import { MaterialModule } from '../shared/modules/material-module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ScoreComponent } from './pages/add-score/score/score.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [AddScoreComponent, ScoreComponent],
  imports: [
    CommonModule,
    MatchesRoutingModule,
    MaterialModule,
    FlexLayoutModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
  ]
})
export class MatchesModule { }
