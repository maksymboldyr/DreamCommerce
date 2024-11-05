import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { UserOrdersService } from '../../services/user-orders.service';
import { OrderDto } from '../../../cart/interfaces/order-dto';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { PanelModule } from 'primeng/panel';
import { DataViewModule } from 'primeng/dataview';
import { OrderDetailDto } from '../../../cart/interfaces/order-detail-dto';
import { OrderService } from '../../../admin/services/order.service';
import { routes } from '../../../../app.routes';

@Component({
  selector: 'app-user-order-details',
  standalone: true,
  imports: [CommonModule, ButtonModule, CardModule, PanelModule, DataViewModule, RouterModule],
  templateUrl: './user-order-details.component.html',
  styleUrls: ['./user-order-details.component.scss']
})
export class UserOrderDetailsComponent implements OnInit {
  order: OrderDto = {};
  orderDetails: OrderDetailDto[] = [];

  constructor(private route: ActivatedRoute, private userOrderService: UserOrdersService, private orderService: OrderService) {}

  ngOnInit() {
    const orderId = this.route.snapshot.paramMap.get('orderId');
    if (orderId) {
      this.loadOrderDetails(orderId);
    }
  }

  loadOrderDetails(orderId: string) {
    this.userOrderService.getOrderById(orderId).subscribe(order => {
      if (order) {
        this.order = order;
      }
      if (order && order.orderDetails) {
        this.orderDetails = order.orderDetails;
      }
    });
  }

  cancelOrder() {
    if (this.order && this.order.id) {
      const statusDto = { id: this.order.id, name: 'Cancelled' };
      this.orderService.changeOrderStatus(statusDto).subscribe(
        response => {
          if (this.order.id) {
            this.loadOrderDetails(this.order.id);
          }
          console.log('Order status changed successfully', response);
        },
        error => {
          console.error('Error changing order status', error);
          // Handle error (e.g., show an error message)
        }
      );
    }
  }
}