/* eslint-disable @typescript-eslint/no-empty-interface */
import { EntityState, createEntityAdapter } from '@ngrx/entity';
import { createReducer, Action, on } from '@ngrx/store';

export interface ShoppingListEntity {
  id: string;
  description: string;
  purchased: boolean;
}

export interface State extends EntityState<ShoppingListEntity> {}

export const adapter = createEntityAdapter<ShoppingListEntity>();

const initialState = adapter.getInitialState();

export const reducer = createReducer(initialState);
