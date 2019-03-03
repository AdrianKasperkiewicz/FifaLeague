import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FlexLayoutModule } from '@angular/flex-layout';
import { StarterComponent } from './starter.component';
import { StarterRoutes } from './starter.routing';
import { MaterialModule } from '../shared/modules/material-module';

@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    FlexLayoutModule,
    RouterModule.forChild(StarterRoutes)
  ],
  declarations: [StarterComponent]
})
export class StarterModule {}
