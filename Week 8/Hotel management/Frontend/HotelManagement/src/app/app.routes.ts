import { Routes } from '@angular/router';
import { AdminLogin } from './Auth/admin-login/admin-login';

export const routes: Routes = [
    {
        path : '', redirectTo : "admin-login", pathMatch : 'full'
    },
    {    path : "admin-login",component : AdminLogin
    }
];
