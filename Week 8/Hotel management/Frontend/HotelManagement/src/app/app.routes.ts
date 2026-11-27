import { Routes } from '@angular/router';

export const routes: Routes = [

  // Default route
  {
    path: '',
    redirectTo: 'User-login',
    pathMatch: 'full'
  },

  // Authentication routes
  {
    path: 'User-login',
    loadComponent: () =>
      import('./Auth/admin-login/admin-login')
        .then(m => m.AdminLogin)
  },

  {
    path: 'customer-register',
    loadComponent: () =>
      import('./Auth/customer-register/customer-register')
        .then(m => m.CustomerRegister)
  },

  // Admin layout and child routes
  {
    path: 'admin',
    loadComponent: () =>
      import('./layouts/admin-layout/admin-layout')
        .then(m => m.AdminLayout),

    children: [
      {
        path: 'list-hotels',
        loadComponent: () =>
          import('./Features/admin/list-hotels/list-hotels')
            .then(m => m.ListHotels)
      },

      {
        path: '',
        redirectTo: 'list-hotels',
        pathMatch: 'full'
      }
    ]
  },

  // Invalid routes
  {
    path: '**',
    redirectTo: 'User-login'
  }

];