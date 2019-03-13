import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LeagueRoutingModule } from './league-routing.module';
import { FixtureComponent } from './fixture/fixture.component';
import { MaterialModule } from '../shared/modules/material-module';
import { DivisionTabComponent } from './fixture/division-tab/division-tab.component';
import { RescheduleDialogComponent } from './fixture/reschedule-dialog/reschedule-dialog.component';

@NgModule({
  imports: [
    CommonModule,
    LeagueRoutingModule,
    MaterialModule
  ],
  declarations: [FixtureComponent, DivisionTabComponent, RescheduleDialogComponent],
  entryComponents: [RescheduleDialogComponent]
})
export class LeagueModule { }
