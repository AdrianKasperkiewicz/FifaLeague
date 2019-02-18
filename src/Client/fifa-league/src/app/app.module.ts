import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddTeamComponent } from './pages/add-team/add-team.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AppMaterialModule } from './shared/modules/app-material.module';
import { TeamService } from './shared/services/team.service';
import { HttpClientModule } from '@angular/common/http';
import { TeamListComponent } from './pages/team-list/team-list.component';

@NgModule({
  declarations: [
    AppComponent,
    AddTeamComponent,
    TeamListComponent
  ],
  imports: [
    BrowserAnimationsModule,
    AppRoutingModule,
    ReactiveFormsModule,
    AppMaterialModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
