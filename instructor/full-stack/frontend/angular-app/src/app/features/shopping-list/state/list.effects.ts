import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { map, switchMap, tap } from 'rxjs';
import { ShoppingFeatureEvents } from './feature.actions';
import { ShoppingListEntity } from './list.reducer';
import { ListDocuments } from './list.actions';

@Injectable()
export class ListEffects {
  // when the feature is entered -> go to the API and get the stuff -> (Action with the shopping list | There was error)

  goGetTheList$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(ShoppingFeatureEvents.entered),
      switchMap(() =>
        this.http
          .get<{ data: ShoppingListEntity[] }>(
            'http://localhost:1338/shopping-list',
          )
          .pipe(
            map((response) => response.data),
            map((payload) => ListDocuments.list({ payload })),
          ),
      ),
    );
  });

  logThemAll$ = createEffect(
    () => {
      return this.actions$.pipe(
        tap((a) => console.log(`Got an Action of Type: ${a.type}`)),
      );
    },
    { dispatch: false },
  );

  constructor(private http: HttpClient, private actions$: Actions) {}
}
