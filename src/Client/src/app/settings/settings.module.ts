import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SettingsRoutingModule } from './settings-routing.module';
import { NewSeasonComponent } from './pages/new-season/new-season.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {DragDropModule} from '@angular/cdk/drag-drop';
import { MaterialModule } from '../shared/modules/material-module';

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
  declarations: [NewSeasonComponent]
})
export class SettingsModule { }
