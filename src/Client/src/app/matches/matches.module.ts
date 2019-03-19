import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatchesRoutingModule } from './matches-routing.module';
import { AddScoreComponent } from './pages/add-score/add-score.component';
import { MaterialModule } from '../shared/modules/material-module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ScoreComponent } from './pages/add-score/score/score.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { StatisticComponent } from './pages/add-score/statistic/statistic.component';
import { BasicInfoComponent } from './pages/add-score/basic-info/basic-info.component';

@NgModule({
  declarations: [AddScoreComponent, ScoreComponent, StatisticComponent, BasicInfoComponent],
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
