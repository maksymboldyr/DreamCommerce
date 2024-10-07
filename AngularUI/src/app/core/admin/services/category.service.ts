import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { catchError, map, Observable } from 'rxjs';
import { CategoryDto } from '../interfaces/category-dto';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  http: HttpClient;
  api: string;

  constructor(http: HttpClient) {
    this.http = http;
    this.api = environment.apiUrl;
  }

  getAll() : Observable<CategoryDto[]> {
    return this.http.get<CategoryDto[]>(`${this.api}/Categories/All`).pipe(
      map((response: CategoryDto[]) => {
        return response.map(category => {
          return {
            id: category.id,
            name: category.name,
          };
        });
      }),
      catchError((error: any) => {
        console.error('Failed to fetch categories', error);
        throw error;
      }
    ));
  }

  getFiltered(filter: string, page: number, pageSize: number, sortField?: string | string[], sortOrder?: number) : Observable<{ totalCount: number, data: CategoryDto[] }> {
    return this.http.get<{ totalCount: number, data: CategoryDto[] }>(
      `${this.api}/Categories?filter=${filter}&page=${page}&pageSize=${pageSize}&sortField=${sortField}&sortOrder=${sortOrder}`)
      .pipe(
      map((response: { totalCount: number, data: CategoryDto[] }) => {
        return {
          totalCount: response.totalCount,
          data: response.data.map(category => {
            return {
              id: category.id,
              name: category.name,
            };
          })
        };
      })
    );
  }

  getById(id: string) {
    return this.http.get(`${this.api}/Categories/${id}`);
  }

  create(categoryDto: CategoryDto) : Observable<string> {
    return this.http.post(`${this.api}/Categories`, categoryDto, { responseType: 'text' }).pipe(
      map((res: string) => {
        return res;
      }),
      catchError((error: any) => {
        console.error('Category creation failed', error);
        throw error;
      }
    ));
  }

  update(category: any) {
    return this.http.put(`${this.api}/Categories/${category.id}`, category);
  }

  delete(id: string): Observable<string> {
    return this.http.delete(`${this.api}/Categories/${id}`, { responseType: 'text' }).pipe(
      map((res: string) => {
        return res;
      }),
      catchError((error: any) => {
        console.error('Category deletion failed', error);
        throw error;
      })
    );
  }
}
