import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { OrderDto } from '../../cart/interfaces/order-dto';
import { environment } from '../../../../environments/environment.development';
import { AuthService } from '../../auth/services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class UserOrdersService {
  private apiUrl = `${environment.apiUrl}/Orders`;
  private userId: string = '';
  orders: OrderDto[] = [];

  constructor(private http: HttpClient, private authService: AuthService) {
    this.userId = this.authService.currentUserId;
  }

  getOrdersByCurrentUser(): Observable<OrderDto[]> {
    return this.http.get<OrderDto[]>(`${this.apiUrl}/User/${this.userId}`).pipe(
      map(orders => {
        this.orders = orders;
        return orders;
      })
    );
  }

  getOrderById(orderId: string): Observable<OrderDto> {
    return this.http.get<OrderDto>(`${this.apiUrl}/${orderId}`);
  }
}