import { Component } from '@angular/core';
import { MenuModule } from 'primeng/menu';
import { last } from 'rxjs';

@Component({
  selector: 'app-admin-panel',
  standalone: true,
  imports: [
    MenuModule,
  ],
  templateUrl: './admin-panel.component.html',
  styleUrl: './admin-panel.component.scss'
})
export class AdminPanelComponent {

  items = [
    {
      label: 'Users',
      items: [
        {
          label: 'Users',
          icon: 'pi pi-fw pi-users',
          routerLink: 'users'
        }
      ]
    },      
    {
      label: 'Products',
      items: [
        {
          label: 'Categories',
          icon: 'pi pi-fw pi-bookmark',
          routerLink: 'categories'
        },
        {
          label: 'Subcategories',
          icon: 'pi pi-fw pi-bookmark-fill',
          routerLink: 'subcategories'
        },
        {
          label: 'Tags',
          icon: 'pi pi-fw pi-tag',
          routerLink: 'tags'
        },
        {
          label: 'Tag Values',
          icon: 'pi pi-fw pi-tags',
          routerLink: 'tag-values'
        },
        {
          label: 'Products',
          icon: 'pi pi-fw pi-shopping-cart',
          routerLink: 'products'
        }
      ]
    },
    {
      label: 'Orders',
      items: [
        {
          label: 'Orders',
          icon: 'pi pi-fw pi-shopping-cart',
          routerLink: 'orders'
        }
      ]
    }
  ];

}
