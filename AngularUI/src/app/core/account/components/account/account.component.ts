import { Component } from '@angular/core';
import { MenuModule } from 'primeng/menu';

@Component({
  selector: 'app-account',
  standalone: true,
  imports: [MenuModule],
  templateUrl: './account.component.html',
  styleUrl: './account.component.scss'
})
export class AccountComponent {
  items = [
    {
      label: 'Profile',
      items: [
        {
          label: 'Profile',
          icon: 'pi pi-fw pi-user',
          routerLink: 'profile'
        }
      ]
    },
    {
      label: 'Orders',
      items: [
        {
          label: 'Order History',
          icon: 'pi pi-fw pi-list',
          routerLink: 'order-history'
        }
      ]
    }
  ];
}