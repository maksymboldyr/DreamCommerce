import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, map, Observable } from 'rxjs';
import { CartDto } from '../interfaces/cart-dto';
import { CartItemDto } from '../interfaces/cart-item-dto';
import { environment } from '../../../../environments/environment.development';
import { AuthService } from '../../auth/services/auth.service';
import { EditProductInCartDto } from '../interfaces/edit-product-in-cart-dto';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  private cartItemsSubject: BehaviorSubject<CartItemDto[]>;
  cartItems$: Observable<CartItemDto[]>;
  private userId: string | null | undefined;
  cart: CartDto | null = null;

  private apiUrl = `${environment.apiUrl}/cart`;

  constructor(private http: HttpClient, private authService: AuthService) {
    this.cartItemsSubject = new BehaviorSubject<CartItemDto[]>([]);
    this.cartItems$ = this.cartItemsSubject.asObservable();
    this.userId = this.authService.currentUserId;
  }

  private saveCartItems(items: CartItemDto[]) {
    sessionStorage.setItem('cartItems', JSON.stringify(items));
  }

  getCart(): Observable<CartDto> {
    return this.http.get<CartDto>(`${this.apiUrl}/${this.userId}`)
      .pipe(map((cart) => {
        this.cart = cart;
        this.saveCartItems(cart.cartItems);
        return cart;
      }));
  }

  addToCart(productId: string): Observable<CartDto> {
    if (!this.userId) {
      return new Observable<CartDto>();
    }
    const productInCartDto: EditProductInCartDto = {
      userId: this.userId,
      productId: productId,
      quantity: 1,
    };
    return this.http.post<CartDto>(`${this.apiUrl}/add`, productInCartDto)
      .pipe(map((updatedCart) => {
        this.cartItemsSubject.next(updatedCart?.cartItems || []);
        this.saveCartItems(updatedCart?.cartItems || []);
        return updatedCart;
      }));
  }

  removeFromCart(productId: string): Observable<CartDto> {
    if (!this.userId) {
      return new Observable<CartDto>();
    }
    const productInCartDto: EditProductInCartDto = {
      userId: this.userId,
      productId: productId,
      quantity: 0,
    };
    return this.http.post<CartDto>(`${this.apiUrl}/remove`, productInCartDto)
      .pipe(map((updatedCart) => {
        this.cartItemsSubject.next(updatedCart?.cartItems || []);
        this.saveCartItems(updatedCart?.cartItems || []);
        return updatedCart;
      }));
  }

  removeAllFromCart(productId: string): Observable<CartDto> {
    if (!this.userId) {
      return new Observable<CartDto>();
    }
    const productInCartDto: EditProductInCartDto = {
      userId: this.userId,
      productId: productId,
      quantity: 0,
    };
    return this.http.post<CartDto>(`${this.apiUrl}/removeAll`, productInCartDto)
      .pipe(map((updatedCart) => {
        this.cartItemsSubject.next(updatedCart?.cartItems || []);
        this.saveCartItems(updatedCart?.cartItems || []);
        return updatedCart;
      }));
  }

  clearCart(): Observable<CartDto> {
    return this.http.delete<CartDto>(`${this.apiUrl}/clear/${this.userId}`)
      .pipe(map((cart) => {
        this.cartItemsSubject.next(cart?.cartItems || []);
        this.saveCartItems(cart?.cartItems || []);
        return cart;
      }));
  }
}