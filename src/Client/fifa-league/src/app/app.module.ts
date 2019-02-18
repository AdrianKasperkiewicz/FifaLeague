import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddTeamComponent } from './pages/add-team/add-team.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AppMaterialModule } from './shared/modules/app-material.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { TeamListComponent } from './pages/team-list/team-list.component';
import { LoaderComponent } from './shared/components/loader/loader.component';
import { LoaderInterceptor } from './shared/interceptors/loader.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    AddTeamComponent,
    TeamListComponent,
    LoaderComponent
  ],
  imports: [
    BrowserAnimationsModule,
    AppRoutingModule,
    ReactiveFormsModule,
    AppMaterialModule,
    HttpClientModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: LoaderInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
