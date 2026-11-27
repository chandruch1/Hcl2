import { Routes } from '@angular/router';
import { AdminLogin } from './Auth/admin-login/admin-login';
import { CustomerRegister } from './Auth/customer-register/customer-register';

export const routes: Routes = [
    {
        path : '', redirectTo : "User-login", pathMatch : 'full'
    },
    {    path : "User-login",component : AdminLogin
    },
    {
        path : 'customer-register', component : CustomerRegister
    }
];
