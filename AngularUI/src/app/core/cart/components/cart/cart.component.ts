import { Component, OnInit } from '@angular/core';
import { CartService } from '../../services/cart.service';
import { CartItemDto } from '../../interfaces/cart-item-dto';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { DataViewModule } from 'primeng/dataview';
import { environment } from '../../../../../environments/environment.development';
import { CartDto } from '../../interfaces/cart-dto';
import { ScrollPanelModule } from 'primeng/scrollpanel';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CommonModule, ButtonModule, DataViewModule, CardModule, ScrollPanelModule],
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {
  cart: CartDto | null = null;
  cartItems: CartItemDto[] = [];
  root: string = environment.root;
  cartEmptyString: string = 'Your cart is empty';

  constructor(private cartService: CartService, private router: Router) {}

  ngOnInit() {
    this.getCart();
  }

  get total(): number {
    if (!this.cart?.total) {
      return 0;
    }
    return this.cart.total;
  }

  getCart() {
    this.cartService.getCart().subscribe(cart => {
      this.cart = cart;
      this.cartItems = cart.cartItems;
    });
  }

  addToCart(productId?: string) {
    if (!productId) {
      return;
    }
    this.cartService.addToCart(productId).subscribe(() => {
      this.getCart();
    });
  }

  removeFromCart(productId?: string) {
    if (!productId) {
      return;
    }
    this.cartService.removeFromCart(productId).subscribe(() => {
      this.getCart();
    });
  }

  removeAllFromCart(productId?: string) {
    if (!productId) {
      return;
    }
    this.cartService.removeAllFromCart(productId).subscribe(() => {
      this.getCart();
    });
  }

  checkout() {
    this.router.navigate(['/checkout']);
  }

  getImageUrl(item: CartItemDto): string {
    return this.root + item.productDTO.imageUrl;
  }
}