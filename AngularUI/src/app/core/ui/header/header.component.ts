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
import { AuthService } from '../../auth/auth.service';
import { map } from 'rxjs';

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

  get isAuthenticated() {
    return this.auth.accessToken !== null;
  }

  ngOnInit() {
    this.avatarItems = [
      
    ];

    this.items = [
      {
        label: 'Home',
        icon: 'pi pi-home',
        route: '',
      },
      {
        label: 'Contact',
        icon: 'pi pi-envelope',
        badge: '3',
      },
    ];
  }

  logout() {
    return this.auth.logout();
  }

  toggle() {
    this.overlayVisible = !this.overlayVisible;
  }
}
