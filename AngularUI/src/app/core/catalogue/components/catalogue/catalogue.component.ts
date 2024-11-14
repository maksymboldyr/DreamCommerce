import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { CatalogueService } from '../../services/catalogue.service';
import { ProductDto } from '../../../admin/interfaces/product-dto';
import { CommonModule } from '@angular/common';
import { CardModule } from 'primeng/card';
import { ButtonModule } from 'primeng/button';
import { environment } from '../../../../../environments/environment.development';
import { ImageModule } from 'primeng/image';
import { DataViewLayoutOptions, DataViewModule } from 'primeng/dataview';
import { TagModule } from 'primeng/tag';
import { RatingModule } from 'primeng/rating';
import { CartService } from '../../../cart/services/cart.service';

@Component({
  selector: 'app-catalogue',
  standalone: true,
  templateUrl: './catalogue.component.html',
  imports: [CommonModule, CardModule, ButtonModule, ImageModule, RouterModule, DataViewModule, TagModule, RatingModule],
  styleUrls: ['./catalogue.component.scss']
})
export class CatalogueComponent implements OnInit {
  products: ProductDto[] = [];
  subcategoryName: string | null = null;
  rootUrl: string = environment.root;

  layout: "list" | "grid" = 'grid';

  constructor(
    private route: ActivatedRoute,
    private catalogueService: CatalogueService,
    private cartService: CartService
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

  addToCart(product: ProductDto) {
    const productId = product.id;
    if (!productId) {
      return;
    }
    this.cartService.addToCart(productId).subscribe(() => {
      console.log('Added to cart');
    });
  }
}