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
