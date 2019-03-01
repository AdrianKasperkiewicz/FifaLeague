import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SettingsRoutingModule } from './settings-routing.module';
import { NewSeasonComponent } from './pages/new-season/new-season.component';

@NgModule({
  imports: [
    CommonModule,
    SettingsRoutingModule
  ],
  declarations: [NewSeasonComponent]
})
export class SettingsModule { }
