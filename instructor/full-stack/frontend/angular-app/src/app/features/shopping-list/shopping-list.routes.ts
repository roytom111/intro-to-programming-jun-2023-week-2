import { Routes } from '@angular/router';
import { ShoppingListComponent } from './shopping-list.component';
import { ListComponent } from './components/list/list.component';
import { CreateComponent } from './components/create/create.component';
import { provideState } from '@ngrx/store';
import { FEATURE_NAME, reducers } from './state';
import { provideHttpClient } from '@angular/common/http';
import { provideEffects } from '@ngrx/effects';
import { ListEffects } from './state/list.effects';

export const SHOPPING_LIST_ROUTES: Routes = [
  {
    path: '',
    component: ShoppingListComponent,
    providers: [
      provideState(FEATURE_NAME, reducers),
      provideHttpClient(),
      provideEffects(ListEffects),
    ],
    children: [
      {
        path: 'list',
        component: ListComponent,
      },
      {
        path: 'create',
        component: CreateComponent,
      },
      {
        path: '**',
        redirectTo: 'list',
      },
    ],
  },
];
