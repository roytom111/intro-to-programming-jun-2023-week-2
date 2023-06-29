import { Component, Input, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShoppingListItemModel } from '../../models';
import { Store } from '@ngrx/store';
import { selectShoppingListModel } from '../../state';

@Component({
  selector: 'app-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css'],
})
export class ListComponent {
  list = this.store.selectSignal(selectShoppingListModel);

  constructor(private store: Store) {}

  markPurchased(item: ShoppingListItemModel) {
    //this.store.dispatch(// new action here.)
  }
}
