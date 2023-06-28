import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideStore } from '@ngrx/store';
import { reducers } from './features/counter/state';

export const appConfig: ApplicationConfig = {
  providers: [provideRouter(routes), provideStore()],
};
