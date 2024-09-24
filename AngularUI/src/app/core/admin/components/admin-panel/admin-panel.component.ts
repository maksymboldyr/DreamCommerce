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
          icon: 'pi pi-fw pi-tag',
          routerLink: 'categories'
        },
        {
          label: 'Subcategories',
          icon: 'pi pi-fw pi-tags',
          routerLink: 'subcategories'
        },
      ]
    }
  ];

}
