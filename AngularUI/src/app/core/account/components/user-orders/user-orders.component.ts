import { Component, OnInit } from '@angular/core';
import { UserOrdersService } from '../../services/user-orders.service';
import { OrderDto } from '../../../cart/interfaces/order-dto';
import { CommonModule } from '@angular/common';
import { DataViewModule } from 'primeng/dataview';
import { ButtonModule } from 'primeng/button';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-orders',
  standalone: true,
  imports: [CommonModule, DataViewModule, ButtonModule, RouterModule],
  templateUrl: './user-orders.component.html',
  styleUrls: ['./user-orders.component.scss']
})
export class UserOrdersComponent implements OnInit {
  orders: OrderDto[] = [];

  constructor(private orderService: UserOrdersService) {}

  ngOnInit() {
    this.loadOrders();
  }

  loadOrders() {
    this.orderService.getOrdersByCurrentUser().subscribe(orders => {
      console.log(orders);
      this.orders = orders;
      console.log(this.orders);
    });
  }
}