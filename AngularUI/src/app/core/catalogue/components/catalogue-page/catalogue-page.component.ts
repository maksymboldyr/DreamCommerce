import { Component, OnInit } from '@angular/core';
import { RouterModule, ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { BreadcrumbModule } from 'primeng/breadcrumb';
import { filter } from 'rxjs/operators';
import { BreadcrumbService } from '../../services/breadcrumb.service';

@Component({
  selector: 'app-catalogue-page',
  standalone: true,
  imports: [RouterModule, BreadcrumbModule],
  templateUrl: './catalogue-page.component.html',
  styleUrls: ['./catalogue-page.component.scss']
})
export class CataloguePageComponent implements OnInit {
  breadcrumbItems: MenuItem[] = [];

  constructor(private router: Router, private route: ActivatedRoute, private breadcrumbService: BreadcrumbService) {}

  ngOnInit() {
    this.router.events.pipe(filter(event => event instanceof NavigationEnd)).subscribe(() => {
      this.setBreadcrumbs();
    });

    this.setBreadcrumbs(); // Ensure breadcrumbs are set on initial load

    this.breadcrumbService.breadcrumbItems$.subscribe(items => {
      this.breadcrumbItems = items;
    });
  }

  setBreadcrumbs() {
    const root: ActivatedRoute = this.route.root;
    const breadcrumbs = this.breadcrumbService.createBreadcrumbs(root);
    this.breadcrumbService.setBreadcrumbItems(breadcrumbs);
  }
}