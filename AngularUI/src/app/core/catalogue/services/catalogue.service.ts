import { Injectable } from '@angular/core';
import { CategoryService } from '../../admin/services/category.service';
import { SubcategoryService } from '../../admin/services/subcategory.service';
import { MenuItem } from 'primeng/api';
import { CategoryDto } from '../../admin/interfaces/category-dto';
import { SubcategoryDto } from '../../admin/interfaces/subcategory-dto';
import { forkJoin, Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { ProductService } from '../../admin/services/product.service';
import { ProductDto } from '../../admin/interfaces/product-dto';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class CatalogueService {
  categoryService: CategoryService;
  subcategoryService: SubcategoryService;
  api: string = environment.apiUrl;
  http: HttpClient;

  categories: CategoryDto[] = [];
  subcategories: SubcategoryDto[] = [];

  constructor(categoryService: CategoryService, subcategoryService: SubcategoryService, productService: ProductService, http: HttpClient) {
    this.categoryService = categoryService;
    this.subcategoryService = subcategoryService;
    this.http = http;

  }

  getCategories(): Observable<CategoryDto[]> {
    return this.categoryService.getAll().pipe(
      map((categories) => {
        this.categories = categories;
        return categories;
      })
    );
  }

  getSubcategories(): Observable<SubcategoryDto[]> {
    return this.subcategoryService.getAll().pipe(
      map((subcategories) => {
        this.subcategories = subcategories;
        return subcategories;
      })
    );
  }

  getCatalogueMenuItems(): Observable<MenuItem[]> {
    return forkJoin([this.getCategories(), this.getSubcategories()]).pipe(
      map(() => {
        return this.categories.map((category) => {
          if (!category.id) {
            return { label: 'No categories found' };
          }
          return {
            label: category.name,
            items: this.getSubcategoriesMenuItems(category.id),
          };
        });
      })
    );
  }

  getSubcategoriesMenuItems(categoryId: string): MenuItem[] {
    return this.subcategories
      .filter((subcategory) => subcategory.categoryId === categoryId)
      .map((subcategory) => {
        return {
          label: subcategory.name,
          routerLink: ['/catalogue', subcategory.name],
        };
      });
  }

  getProductsBySubcategory(subcategoryName: string): Observable<ProductDto[]> {
    return this.http.get<ProductDto[]>(`${this.api}/Catalogue/search/${subcategoryName}`).pipe(
      map((response: ProductDto[]) => {
        return response.map(product => {
          return {
            id: product.id,
            name: product.name,
            description: product.description,
            categoryId: product.categoryId,
            subcategoryId: product.subcategoryId,
            price: product.price,
            stock: product.stock,
            discount: product.discount,
            imageUrl: product.imageUrl,
          };
        });
      }),
      catchError((error: any) => {
        console.error('Failed to fetch products by subcategory', error);
        throw error;
      })
    );
  }

  getProductById(productId: string): Observable<ProductDto> {
    return this.http.get<ProductDto>(`${this.api}/Catalogue/${productId}`).pipe(
      map((product: ProductDto) => {
        return {
          id: product.id,
          name: product.name,
          description: product.description,
          categoryId: product.categoryId,
          subcategoryId: product.subcategoryId,          
          subcategoryName: product.subcategoryName,
          price: product.price,
          stock: product.stock,
          discount: product.discount,
          imageUrl: product.imageUrl,
        };
      }),
      catchError((error: any) => {
        console.error('Failed to fetch product by id', error);
        throw error;
      })
    );
  }

}