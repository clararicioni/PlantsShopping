import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('./pages/home/home').then(m => m.Home)
  },
  {
    path: 'sobre',
    loadComponent: () =>
      import('./pages/sobre/sobre').then(m => m.Sobre)
  },
  {
    path: '**',
    redirectTo: ''
  }
];
