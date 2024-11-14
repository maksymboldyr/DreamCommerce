import { Injectable } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { BehaviorSubject } from 'rxjs';
import { ActivatedRoute } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class BreadcrumbService {
  private breadcrumbItemsSubject = new BehaviorSubject<MenuItem[]>([]);
  breadcrumbItems$ = this.breadcrumbItemsSubject.asObservable();

  setBreadcrumbItems(items: MenuItem[]) {
    this.breadcrumbItemsSubject.next(items);
  }

  createBreadcrumbs(route: ActivatedRoute, url: string = '', breadcrumbs: MenuItem[] = []): MenuItem[] {
    const children: ActivatedRoute[] = route.children;

    if (children.length === 0) {
      return breadcrumbs;
    }

    for (const child of children) {
      const routeURL: string = child.snapshot.url.map(segment => segment.path).join('/');
      if (routeURL !== '') {
        url += `/${routeURL}`;
      }

      if (child.snapshot.data['breadcrumb']) {
        const breadcrumbData = child.snapshot.data['breadcrumb'];
        breadcrumbs.push({
          label: breadcrumbData.label,
          icon: breadcrumbData.icon,
          routerLink: url
        });
      } else if (child.snapshot.params['subcategoryName']) {
        const subcategoryUrl = url.split('/').slice(0, -2).join('/');
        breadcrumbs.push({
          label: child.snapshot.params['subcategoryName'],
          routerLink: subcategoryUrl
        });
      }

      return this.createBreadcrumbs(child, url, breadcrumbs);
    }

    return breadcrumbs;
  }
}