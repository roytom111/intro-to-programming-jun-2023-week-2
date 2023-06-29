// Events
// Notifications that something has happened (past tense)
// no expectation of what that means from the code that dispatched.

import { createActionGroup, props } from '@ngrx/store';
import { ShoppingListEntity } from './list.reducer';

// Commands
// These are actions that are dispatched that mean "DO THIS THING" - there is
// an expectation that something will happen.
type ShoppingListEntityCreateModel = Pick<ShoppingListEntity, 'description'>;
export const ListEvents = createActionGroup({
  source: 'Shopping List Events',
  events: {
    'Item Added': props<{ payload: ShoppingListEntityCreateModel }>(),
    'Item Marked Purchased': props<{ payload: ShoppingListEntity }>(),
  },
});

// Documents
// This is just the data. Like we are going to need one that just has our list of
// shopping items from the API.

export const ListDocuments = createActionGroup({
  source: 'Shopping List Documents',
  events: {
    list: props<{ payload: ShoppingListEntity[] }>(),
    item: props<{ payload: ShoppingListEntity }>(),
  },
});
