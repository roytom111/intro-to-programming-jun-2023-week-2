import { Routes } from '@angular/router';
import { BankAccountComponent } from './components/bank-account.component';
import { LandingPageComponent } from './components/landing-page/landing-page.component';

export const routes: Routes = [

    {
        path: 'home',

        component: LandingPageComponent

    },

    {

        path: 'account',

        component: BankAccountComponent

    },

    {

        path: '**',

        redirectTo: 'home'

    }


];
