import { Component, inject, OnInit } from '@angular/core';
import { ProductDto } from '../../../admin/interfaces/product-dto';
import { CatalogueService } from '../../services/catalogue.service';
import { environment } from '../../../../../environments/environment.development';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { DataViewModule } from 'primeng/dataview';
import { ButtonModule } from 'primeng/button';
import { TagModule } from 'primeng/tag';
import { RatingModule } from 'primeng/rating';
import { CardModule } from 'primeng/card';
import { BreadcrumbModule } from 'primeng/breadcrumb';
import { CartService } from '../../../cart/services/cart.service';

@Component({
  selector: 'app-catalogue-product',
  standalone: true,
  imports: [RatingModule, ButtonModule, CardModule, BreadcrumbModule],
  templateUrl: './catalogue-product.component.html',
  styleUrls: ['./catalogue-product.component.scss']
})
export class CatalogueProductComponent implements OnInit {
  product: ProductDto;
  rootUrl: string = environment.root;
  catalogueService = inject(CatalogueService);
  cartService = inject(CartService);
  route = inject(ActivatedRoute);
  subcategoryName: string = '';

  constructor() {
    this.product = {
      id: '',
      name: '',
      description: '',
      categoryId: '',
      subcategoryId: '',
      price: 0,
      stock: 0,
      discount: 0,
      imageUrl: '',
    };
  }

  ngOnInit() {
    this.getProduct();
  }

  getProduct() {
    this.route.paramMap.subscribe(params => {
      const productId = params.get('productId');
      const subcategoryName = params.get('subcategoryName');
      if (productId && subcategoryName) {
        this.catalogueService.getProductById(productId).subscribe(product => {
          this.product = product;
        });
      }
    });
  }

  getImageUrl(product: ProductDto): string {
    return this.rootUrl + product.imageUrl;
  }

  addToCart() {
    if (!this.product.id) {
      return;
    }
    this.cartService.addToCart(this.product.id);
  }
}