import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LeagueRoutingModule } from './league-routing.module';
import { FixtureComponent } from './fixture/fixture.component';

@NgModule({
  imports: [
    CommonModule,
    LeagueRoutingModule
  ],
  declarations: [FixtureComponent]
})
export class LeagueModule { }
