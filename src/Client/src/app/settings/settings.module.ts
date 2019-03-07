import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SettingsRoutingModule } from './settings-routing.module';
import { NewSeasonComponent } from './pages/new-season/new-season.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { MaterialModule } from '../shared/modules/material-module';
import { DivisionsComponent } from './pages/divisions/divisions.component';
import { TeamsComponent } from './pages/teams/teams.component';
import { DialogNewTeamComponent } from './pages/teams/dialog-new-team/dialog-new-team.component';
import { AddTeamToDivisionComponent } from './pages/divisions/add-team-to-division/add-team-to-division.component';
import { AddTeamToDivisionDialogComponent } from './pages/divisions/add-team-to-division-dialog/add-team-to-division-dialog.component';

@NgModule({
  imports: [
    CommonModule,
    SettingsRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    DragDropModule
  ],
  declarations: [
    NewSeasonComponent,
    DivisionsComponent,
    TeamsComponent,
    DialogNewTeamComponent,
    AddTeamToDivisionComponent,
    AddTeamToDivisionDialogComponent
  ],
  entryComponents: [DialogNewTeamComponent, AddTeamToDivisionDialogComponent],
})
export class SettingsModule { }
