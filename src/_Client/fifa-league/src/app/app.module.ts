import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule, ErrorHandler } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddTeamComponent } from './pages/add-team/add-team.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AppMaterialModule } from './shared/modules/app-material.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { TeamListComponent } from './pages/team-list/team-list.component';
import { LoaderComponent } from './shared/components/loader/loader.component';
import { LoaderInterceptor } from './shared/interceptors/loader.interceptor';
import { ToastrModule } from 'ngx-toastr';
import { ErrorsHandler } from './shared/handlers/errors-handler';
import { AddFirstSeasonComponent } from './pages/add-first-season/add-first-season.component';
import { NavbarComponent } from './shared/components/navbar/navbar.component';
import { HomeComponent } from './pages/home/home.component';
import { SeasonsComponent } from './pages/seasons/seasons.component';
import { LeagueStepComponent } from './pages/add-first-season/league-step/league-step.component';
import { DivisionStepComponent } from './pages/add-first-season/division-step/division-step.component';
import { TeamStepComponent } from './pages/add-first-season/team-step/team-step.component';
import { DivisionCardComponent } from './pages/add-first-season/division-step/division-card/division-card.component';
import { TeamCardComponent } from './pages/add-first-season/team-step/team-card/team-card.component';

@NgModule({
  declarations: [
    AppComponent,
    AddTeamComponent,
    TeamListComponent,
    LoaderComponent,
    AddFirstSeasonComponent,
    NavbarComponent,
    HomeComponent,
    SeasonsComponent,
    LeagueStepComponent,
    DivisionStepComponent,
    TeamStepComponent,
    DivisionCardComponent,
    TeamCardComponent,
  ],
  imports: [
    BrowserAnimationsModule,
    AppRoutingModule,
    ReactiveFormsModule,
    AppMaterialModule,
    HttpClientModule,
    ToastrModule.forRoot({
      timeOut: 5000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: false,
    }),
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: LoaderInterceptor,
      multi: true
    },
    {
      provide: ErrorHandler,
      useClass: ErrorsHandler,
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
