import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment.development';
import { OrderDto } from '../../cart/interfaces/order-dto';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { StatusDto } from '../interfaces/status-dto';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  http: HttpClient;
  api: string;

  constructor(http: HttpClient) {
    this.http = http;
    this.api = environment.apiUrl;
  }

  getAll(): Observable<OrderDto[]> {
    return this.http.get<OrderDto[]>(`${this.api}/Orders/All`).pipe(
      map((response: OrderDto[]) => {
        return response.map(order => ({
          id: order.id,
          userId: order.userId,
          address: order.address,
          totalPrice: order.totalPrice,
          status: order.status,
          createdAt: order.createdAt,
          orderDetails: order.orderDetails
        }));
      }),
      catchError((error: any) => {
        console.error('Failed to fetch orders', error);
        throw error;
      })
    );
  }

  getFiltered(filter: string, page: number, pageSize: number, sortField?: string | string[], sortOrder?: number): Observable<{ totalCount: number, data: OrderDto[] }> {
    return this.http.get<{ totalCount: number, data: OrderDto[] }>(
      `${this.api}/Orders?filter=${filter}&page=${page}&pageSize=${pageSize}&sortField=${sortField}&sortOrder=${sortOrder}`
    ).pipe(
      map((response: { totalCount: number, data: OrderDto[] }) => {
        return {
          totalCount: response.totalCount,
          data: response.data.map(order => ({
            id: order.id,
            userId: order.userId,
            address: order.address,
            totalPrice: order.totalPrice,
            status: order.status,
            createdAt: order.createdAt,
            orderDetails: order.orderDetails
          }))
        };
      }),
      catchError((error: any) => {
        console.error('Failed to fetch filtered orders', error);
        throw error;
      })
    );
  }

  getById(id: string): Observable<OrderDto> {
    return this.http.get<OrderDto>(`${this.api}/Orders/${id}`).pipe(
      catchError((error: any) => {
        console.error(`Failed to fetch order with ID ${id}`, error);
        throw error;
      })
    );
  }

  create(orderDto: OrderDto): Observable<string> {
    return this.http.post(`${this.api}/Orders`, orderDto, { responseType: 'text' }).pipe(
      map((res: string) => {
        return res;
      }),
      catchError((error: any) => {
        console.error('Order creation failed', error);
        throw error;
      })
    );
  }

  update(order: OrderDto): Observable<void> {
    return this.http.put<void>(`${this.api}/Orders/${order.id}`, order).pipe(
      catchError((error: any) => {
        console.error('Order update failed', error);
        throw error;
      })
    );
  }

  delete(id: string): Observable<string> {
    return this.http.delete(`${this.api}/Orders/${id}`, { responseType: 'text' }).pipe(
      map((res: string) => {
        return res;
      }),
      catchError((error: any) => {
        console.error('Order deletion failed', error);
        throw error;
      })
    );
  }

  changeOrderStatus(statusDto: StatusDto): Observable<any> {
    return this.http.put(`${this.api}/Orders/status`, statusDto, { responseType: 'text' }).pipe(
      catchError((error: any) => {
        console.error(`Failed to change status for order with ID ${statusDto.id}`, error);
        throw error;
      })
    );
  }
}