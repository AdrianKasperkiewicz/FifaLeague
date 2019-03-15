import { Routes } from '@angular/router';
import { FullComponent } from './shared/layouts/full/full.component';


export const AppRoutes: Routes = [
  {
    path: '',
    component: FullComponent,
    children: [
      {
        path: '',
        redirectTo: '/starter',
        pathMatch: 'full'
      },
      {
        path: '',
        loadChildren:
          './material-component/material.module#MaterialComponentsModule'
      },
      {
        path: 'starter',
        loadChildren: './starter/starter.module#StarterModule'
      },
      {
        path: 'settings',
        loadChildren: './settings/settings.module#SettingsModule'
      },
      {
        path: 'league',
        loadChildren: './league/league.module#LeagueModule'
      },
      {
        path: 'matches',
        loadChildren: './matches/matches.module#MatchesModule'
      }
    ]
  },
  {
    path: 'error',
    loadChildren: './errors/errors.module#ErrorsModule'
  }
];
