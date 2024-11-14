import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CheckoutService } from '../../services/checkout.service';
import { OrderDto } from '../../interfaces/order-dto';
import { AddressDto } from '../../interfaces/address-dto';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { CartService } from '../../services/cart.service';
import { UserService } from '../../../admin/services/user.service';
import { Router } from '@angular/router';
import { UserDataDto } from '../../interfaces/user-data-dto';
import { AuthService } from '../../../auth/services/auth.service';

@Component({
  selector: 'app-checkout',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule, InputTextModule, ButtonModule],
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit {
  checkoutForm: FormGroup;
  order: OrderDto = {
    address: {} as AddressDto,
    orderDetails: [],
    totalPrice: 0
  };

  constructor(
    private fb: FormBuilder,
    private checkoutService: CheckoutService,
    private cartService: CartService,
    private userService: UserService,
    private authService: AuthService,
    private router: Router
  ) {
    this.checkoutForm = this.fb.group({
      fullName: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      country: ['', Validators.required],
      city: ['', Validators.required],
      street: ['', Validators.required],
      building: ['', Validators.required],
      apartment: ['', Validators.required],
      zipCode: ['', Validators.required],
      totalPrice: [{ value: 0, disabled: true }, Validators.required]
    });
  }

  ngOnInit() {
    this.populateOrderDetails();
  }

  populateOrderDetails() {
    this.cartService.getCart().subscribe(cart => {
      this.order.orderDetails = cart.cartItems.map(item => ({
        productId: item.productDTO.id ?? '',
        quantity: item.quantity,
        price: item.productDTO.price,
        totalPrice: item.quantity * item.productDTO.price
      }));
      this.order.totalPrice = cart.total;
      this.checkoutForm.patchValue({ totalPrice: this.order.totalPrice });
    });

    let userId = this.authService.currentUserId;

    this.userService.getUserData(userId).subscribe((user: UserDataDto) => {
      this.checkoutForm.patchValue({
        fullName: `${user.firstName} ${user.lastName}`,
        phoneNumber: user.phoneNumber,
        country: user.country,
        city: user.city,
        street: user.street,
        building: user.building,
        apartment: user.apartment,
        zipCode: user.zipCode
      });
    });
  }

  onSubmit() {
    if (this.checkoutForm.invalid) {
      return;
    }

    this.order.userId = this.authService.currentUserId;

    this.order.address = this.checkoutForm.value as AddressDto;

    this.checkoutService.placeOrder(this.order).subscribe(
      response => {
        console.log('Order placed successfully', response);
        this.router.navigate(['/checkout-confirm']);
      },
      error => {
        console.error('Error placing order', error);
      }
    );
  }
}