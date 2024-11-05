import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { TableModule, TableLazyLoadEvent } from 'primeng/table';
import { OrderService } from '../../services/order.service';
import { Router } from '@angular/router';
import { TableFilterService } from '../../services/table-filter.service';
import { OrderDto } from '../../../cart/interfaces/order-dto';
import { ToolbarModule } from 'primeng/toolbar';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DropdownModule } from 'primeng/dropdown';
import { StatusDto } from '../../interfaces/status-dto';

@Component({
  selector: 'app-orders-admin',
  standalone: true,
  providers: [TableFilterService],
  imports: [
    CommonModule,
    TableModule,
    InputTextModule,
    DialogModule,
    ButtonModule,
    ToolbarModule,
    FormsModule,
    ReactiveFormsModule,
    DropdownModule,
  ],
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent {
  orderService: OrderService;
  router: Router;
  tableFilter: TableFilterService;
  loading: boolean = true;

  orders: OrderDto[] = [];
  totalRecords: number = 0;
  
  statusOptions: string[] = ['New', 'Confirmed', 'Shipped', 'Delivered', 'Cancelled', 'Completed'];
  selectedStatus: string = '';
  displayStatusDialog: boolean = false;
  selectedOrder: OrderDto | null = null;

  lastEvent: TableLazyLoadEvent = {};

  constructor(
    orderService: OrderService, 
    router: Router, 
    tableFilter: TableFilterService
  ) {
    this.orderService = orderService;
    this.router = router;
    this.tableFilter = tableFilter;
  }

  ngOnInit() {
    this.loadOrders();
  }

  loadData(event: TableLazyLoadEvent) {
    if (event.filters) {
      this.tableFilter.applyFilters(event);
    }

    this.tableFilter.applyPaginationAndSorting(event);
    this.loadOrders();
    this.lastEvent = event;    
  }

  loadOrders() {
    this.loading = true;
    this.orderService.getFiltered(
      this.tableFilter.filtersString,
      this.tableFilter.page,
      this.tableFilter.pageSize,
      this.tableFilter.sortField,
      this.tableFilter.sortOrder
    ).subscribe({
      next: (response) => {
        this.orders = response.data;
        this.totalRecords = response.totalCount;
        this.loading = false;
        console.log(this.orders);
      },
      error: (error) => {
        console.error('Error loading orders', error);
        this.loading = false;
      }
    });
  }

  viewOrder(order: OrderDto) {
    this.router.navigate(['/account/order-details', order.id]);
  }

  deleteOrder(order: OrderDto) {
    if (!order.id) return;
    
    this.loading = true;
    this.orderService.delete(order.id).subscribe({
      next: () => {
        this.loadOrders();
      },
      error: (error) => {
        console.error('Error deleting order', error);
        this.loading = false;
      }
    });
  }

  openStatusDialog(order: OrderDto) {
    this.selectedOrder = order;
    this.selectedStatus = order.status || '';
    this.displayStatusDialog = true;
  }

  changeOrderStatus() {
    if (!this.selectedOrder?.id || !this.selectedStatus) return;

    this.loading = true;
    const statusDto: StatusDto = { 
      id: this.selectedOrder.id, 
      name: this.selectedStatus 
    };
    
    this.orderService.changeOrderStatus(statusDto).subscribe({
      next: () => {
        this.displayStatusDialog = false;
        this.loadOrders();
        this.loading = false;
      },
      error: (error) => {
        console.error('Error changing order status', error);
        this.loading = false;
      }
    });
  }

  toggleFormDialog() {
    this.displayStatusDialog = !this.displayStatusDialog;
    if (!this.displayStatusDialog) {
      this.selectedOrder = null;
      this.selectedStatus = '';
    }
  }
}