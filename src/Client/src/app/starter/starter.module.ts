import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FlexLayoutModule } from '@angular/flex-layout';
import { StarterComponent } from './starter.component';
import { StarterRoutes } from './starter.routing';
import { MaterialModule } from '../shared/modules/material-module';
import { FixtureTabComponent } from './fixture-tab/fixture-tab.component';
import { LastMatchesComponent } from './last-matches/last-matches.component';

@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    FlexLayoutModule,
    RouterModule.forChild(StarterRoutes)
  ],
  declarations: [StarterComponent, FixtureTabComponent, LastMatchesComponent]
})
export class StarterModule {}
