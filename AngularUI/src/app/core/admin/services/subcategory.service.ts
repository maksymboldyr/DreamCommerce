import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { catchError, map, Observable } from 'rxjs';
import { SubcategoryDto } from '../interfaces/subcategory-dto';

@Injectable({
  providedIn: 'root'
})
export class SubcategoryService {
  http: HttpClient;
  api: string;

  constructor(http: HttpClient) {
    this.http = http;
    this.api = environment.apiUrl;
   }

  getAll() : Observable<SubcategoryDto[]> {
    return this.http.get<SubcategoryDto[]>(`${this.api}/Subcategories/All`).pipe(
      map((response: SubcategoryDto[]) => {
        return response.map(subcategory => {
          return {
            id: subcategory.id,
            name: subcategory.name,
            categoryId: subcategory.categoryId,
            categoryName: subcategory.categoryName,
          };
        });
      }),
      catchError((error: any) => {
        console.error('Failed to fetch subcategories', error);
        throw error;
      }
    ));
  }

  getFiltered(filter: string, page: number, pageSize: number, sortField?: string | string[], sortOrder?: number) : Observable<{ totalCount: number, data: SubcategoryDto[] }> {
    return this.http.get<{totalCount: number, data: SubcategoryDto[]}>(
      `${this.api}/Subcategories?filter=${filter}&page=${page}&pageSize=${pageSize}&sortField=${sortField}&sortOrder=${sortOrder}`)
      .pipe(
      map((response: { totalCount: number, data: SubcategoryDto[] }) => {
        return {
          totalCount: response.totalCount,
          data: response.data.map(subcategory => {
            return {
              id: subcategory.id,
              name: subcategory.name,
              categoryId: subcategory.categoryId,
              categoryName: subcategory.categoryName,
            };
          })
        };
      })
    );
  }

  create(subcategoryDto: SubcategoryDto) : Observable<string> {
    return this.http.post(`${this.api}/Subcategories`, subcategoryDto, { responseType: 'text' }).pipe(
      map((res: string) => {
        return res;
      }),
      catchError((error: any) => {
        console.error('Subcategory creation failed', error);
        throw error;
      }
    ));
  }

  delete(subcategoryId: string) : Observable<string> {
    return this.http.delete(`${this.api}/Subcategories/${subcategoryId}`, { responseType: 'text' }).pipe(
      map((res: string) => {
        return res;
      }),
      catchError((error: any) => {
        console.error('Subcategory deletion failed', error);
        throw error;
      }
    ));
  }
    
}
