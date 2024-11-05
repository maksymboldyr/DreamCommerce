import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { OrderDto } from '../interfaces/order-dto';
import { environment } from '../../../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class CheckoutService {
  private apiUrl = environment.apiUrl + '/Orders';

  constructor(private http: HttpClient) { }

  placeOrder(order: OrderDto): Observable<string> {
    return this.http.post(`${this.apiUrl}`, order, { responseType: 'text' });
  }

  getOrderById(orderId: string): Observable<OrderDto> {
    return this.http.get<OrderDto>(`${this.apiUrl}/${orderId}`);
  }

  changeOrderStatus(orderId: string, status: string): Observable<any> {
    return this.http.put(`${this.apiUrl}/${orderId}/status`, { status });
  }

  deleteOrder(orderId: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${orderId}`);
  }
}
