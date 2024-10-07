import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { catchError, map, Observable } from 'rxjs';
import { ProductDto } from '../interfaces/product-dto';
import { ProductImageUploadDto } from '../interfaces/product-image-upload-dto';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  http: HttpClient;
  api: string;

  constructor(http: HttpClient) {
    this.http = http;
    this.api = environment.apiUrl;
  }

  getAll(): Observable<ProductDto[]> {
    return this.http.get<ProductDto[]>(`${this.api}/Products/All`).pipe(
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
        console.error('Failed to fetch products', error);
        throw error;
      })
    );
  }

  getFiltered(filter: string, page: number, pageSize: number, sortField?: string | string[], sortOrder?: number): Observable<{ totalCount: number, data: ProductDto[] }> {
    return this.http.get<{ totalCount: number, data: ProductDto[] }>(
      `${this.api}/Products?filter=${filter}&page=${page}&pageSize=${pageSize}&sortField=${sortField}&sortOrder=${sortOrder}`
    ).pipe(
      map((response: { totalCount: number, data: ProductDto[] }) => {
        return {
          totalCount: response.totalCount,
          data: response.data.map(product => {
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
          })
        };
      })
    );
  }

  

  getById(id: string): Observable<ProductDto> {
    return this.http.get<ProductDto>(`${this.api}/Products/${id}`);
  }

  create(productDto: ProductDto): Observable<string> {
    return this.http.post(`${this.api}/Products`, productDto, { responseType: 'text' }).pipe(
      map((res: string) => {
        return res;
      }),
      catchError((error: any) => {
        console.error('Product creation failed', error);
        throw error;
      })
    );
  }

  update(product: ProductDto): Observable<void> {
    return this.http.put<void>(`${this.api}/Products/${product.id}`, product).pipe(
      catchError((error: any) => {
        console.error('Product update failed', error);
        throw error;
      })
    );
  }

  delete(id: string): Observable<string> {
    return this.http.delete(`${this.api}/Products/${id}`, { responseType: 'text' }).pipe(
      map((res: string) => {
        return res;
      }),
      catchError((error: any) => {
        console.error('Product deletion failed', error);
        throw error;
      })
    );
  }

  uploadImage(imageUploadDto: ProductImageUploadDto): Observable<string> {
    const formData = new FormData();
    formData.append('productId', imageUploadDto.productId);
    formData.append('image', imageUploadDto.image);
  
    return this.http.post(`${this.api}/Products/upload-image`, formData, { responseType: 'text' }).pipe(
      map((res: string) => {
        return res;
      }),
      catchError((error: any) => {
        console.error('Image upload failed', error);
        throw error;
      })
    );
  }
}