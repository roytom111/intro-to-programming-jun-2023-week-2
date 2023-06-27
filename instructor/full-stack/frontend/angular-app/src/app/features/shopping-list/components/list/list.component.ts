import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShoppingListItemModel } from '../../models';

@Component({
  selector: 'app-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent {
  list: ShoppingListItemModel[] = [
    { id: '1', description: 'Shampoo', purchased: false },
    { id: '2', description: 'Lettuce', purchased: true }
  ]
}
