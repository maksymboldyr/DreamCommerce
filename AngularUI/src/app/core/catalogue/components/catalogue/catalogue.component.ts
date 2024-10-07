import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { CatalogueService } from '../../services/catalogue.service';
import { ProductDto } from '../../../admin/interfaces/product-dto';
import { CommonModule } from '@angular/common';
import { CardModule } from 'primeng/card'; // Import CardModule
import { ButtonModule } from 'primeng/button'; // Import ButtonModule
import { environment } from '../../../../../environments/environment.development';
import { ImageModule } from 'primeng/image';
import { DataViewLayoutOptions, DataViewModule } from 'primeng/dataview';
import { TagModule } from 'primeng/tag';
import { RatingModule } from 'primeng/rating';

@Component({
  selector: 'app-catalogue',
  standalone: true,
  templateUrl: './catalogue.component.html',
  imports: [CommonModule, CardModule, ButtonModule, ImageModule, RouterModule, DataViewModule, TagModule, RatingModule], // Add PrimeNG modules
  styleUrls: ['./catalogue.component.scss']
})
export class CatalogueComponent implements OnInit {
  products: ProductDto[] = [];
  subcategoryName: string | null = null;
  rootUrl: string = environment.root;

  layout: "list" | "grid" = 'grid';

  constructor(
    private route: ActivatedRoute,
    private catalogueService: CatalogueService
  ) {}

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.subcategoryName = params.get('subcategoryName');
      if (this.subcategoryName) {
        this.catalogueService.getProductsBySubcategory(this.subcategoryName).subscribe(products => {
          this.products = products;
        });
      }
    });
  }

  getImageUrl(product: ProductDto) {
    return this.rootUrl + product.imageUrl;
  }

  getSeverity(product: ProductDto) {
    if (product.stock > 0) {
      return 'success';
    }
    return 'danger';
  }

  linkToProduct(product: ProductDto): string {
    return `/catalogue/${this.subcategoryName}/product/${product.id}`;
  }
}