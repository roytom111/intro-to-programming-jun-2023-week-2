import { ActionReducerMap } from '@ngrx/store';
import * as fromList from './list.reducer';
export const FEATURE_NAME = 'shoppingFeature';

// eslint-disable-next-line @typescript-eslint/no-empty-interface
export interface ShoppingFeatureState {
  list: fromList.State;
}

export const reducers: ActionReducerMap<ShoppingFeatureState> = {
  list: fromList.reducer,
};
