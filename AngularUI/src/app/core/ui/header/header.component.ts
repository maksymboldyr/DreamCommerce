import { Component, inject, OnInit, ViewEncapsulation } from '@angular/core';
import { MegaMenuItem, MenuItem } from 'primeng/api';
import { MenubarModule } from 'primeng/menubar';
import { BadgeModule } from 'primeng/badge';
import { AvatarModule } from 'primeng/avatar';
import { InputTextModule } from 'primeng/inputtext';
import { CommonModule } from '@angular/common';
import { RippleModule } from 'primeng/ripple';
import { TieredMenuModule } from 'primeng/tieredmenu';
import { MenuModule } from 'primeng/menu';
import { Button } from 'primeng/button';
import { MegaMenuModule } from 'primeng/megamenu';
import { OverlayPanelModule } from 'primeng/overlaypanel';
import { StyleClassModule } from 'primeng/styleclass';
import { OverlayModule } from 'primeng/overlay';
import { AuthService } from '../../auth/services/auth.service';
import { map } from 'rxjs';
import { CatalogueService } from '../../catalogue/services/catalogue.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
  standalone: true,
  imports: [
    MenubarModule,
    BadgeModule,
    AvatarModule,
    InputTextModule,
    RippleModule,
    CommonModule,
    TieredMenuModule,
    MenuModule,
    Button,
    MegaMenuModule,
    OverlayPanelModule,
    StyleClassModule,
    OverlayModule,
  ],
  encapsulation: ViewEncapsulation.Emulated,
})
export class HeaderComponent implements OnInit {
  items: MenuItem[] | undefined;
  avatarItems: MenuItem[] | undefined;
  catalogueItems: MenuItem[] | undefined;
  overlayVisible: boolean = false;
  headerVisible: boolean = true;
  auth = inject(AuthService);
  catalogueService = inject(CatalogueService);

  get isAuthenticated() {
    return this.auth.accessToken !== null && this.auth.accessToken !== '';
  }

  ngOnInit() {
    this.loadItems();
  }

  loadItems() {
    this.avatarItems = [
      {
        label: 'Admin Panel',
        icon: 'pi pi-cog',
        routerLink: '/admin',
        visible: this.auth.hasRole('Admin')
      },
      {
        label: 'Account',
        icon: 'pi pi-user',
        routerLink: '/account',
        visible: this.isAuthenticated
      },
      {
        label: 'Sign In',
        icon: 'pi pi-sign-in',
        routerLink: '/login',
        visible: !this.isAuthenticated
      },
      {
        label: 'Sign Out',
        icon: 'pi pi-sign-out',
        routerLink: '/home',
        command: () => this.logout(),
        visible: this.isAuthenticated
      }
    ];

    this.items = [
      {
        label: 'Home',
        icon: 'pi pi-home',
        route: '',
      },
    ];
  }

  loadCatalogueItems() {
    this.catalogueService.getCatalogueMenuItems().subscribe(items => {
      this.catalogueItems = items;
    });    
  }

  logout() {
    this.auth.logout();
  }

  toggleCatalogue() {
    this.loadCatalogueItems();
    this.overlayVisible = !this.overlayVisible;
  }

  toggleAvatar() {
    this.loadItems();
    
  }
}