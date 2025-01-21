import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { catchError, map, Observable } from 'rxjs';
import { TagDto } from '../interfaces/tag-dto';

@Injectable({
  providedIn: 'root'
})
export class TagService {
  http: HttpClient;
  api: string;

  constructor(http: HttpClient) {
    this.http = http;
    this.api = environment.apiUrl;
  }

  getAll(): Observable<TagDto[]> {
    return this.http.get<TagDto[]>(`${this.api}/Tags/All`).pipe(
      map((response: TagDto[]) => {
        return response.map(tag => ({
          id: tag.id,
          subcategoryId: tag.subcategoryId,
          name: tag.name,
        }));
      }),
      catchError((error: any) => {
        console.error('Failed to fetch tags', error);
        throw error;
      })
    );
  }

  getFiltered(filter: string, page: number, pageSize: number, sortField?: string | string[], sortOrder?: number): Observable<{ totalCount: number, data: TagDto[] }> {
    return this.http.get<{ totalCount: number, data: TagDto[] }>(
      `${this.api}/Tags?filter=${filter}&page=${page}&pageSize=${pageSize}&sortField=${sortField}&sortOrder=${sortOrder}`
    ).pipe(
      map((response: { totalCount: number, data: TagDto[] }) => {
        return {
          totalCount: response.totalCount,
          data: response.data.map(tag => ({
            id: tag.id,
            subcategoryId: tag.subcategoryId,
            name: tag.name,
            subcategoryName: tag.subcategoryName,
          }))
        };
      }),
      catchError((error: any) => {
        console.error('Failed to fetch filtered tags', error);
        throw error;
      })
    );
  }

  getById(id: string): Observable<TagDto> {
    return this.http.get<TagDto>(`${this.api}/Tags/${id}`).pipe(
      catchError((error: any) => {
        console.error(`Failed to fetch tag with ID ${id}`, error);
        throw error;
      })
    );
  }

  create(tag: TagDto): Observable<string> {
    return this.http.post(`${this.api}/Tags`, tag, { responseType: 'text' }).pipe(
      map((res: string) => {
        return res;
      }),
      catchError((error: any) => {
        console.error('TagDto creation failed', error);
        throw error;
      })
    );
  }

  update(tag: TagDto): Observable<void> {
    return this.http.put<void>(`${this.api}/Tags/${tag.id}`, tag).pipe(
      catchError((error: any) => {
        console.error('TagDto update failed', error);
        throw error;
      })
    );
  }

  delete(id: string): Observable<string> {
    return this.http.delete(`${this.api}/Tags/${id}`, { responseType: 'text' }).pipe(
      map((res: string) => {
        return res;
      }),
      catchError((error: any) => {
        console.error('TagDto deletion failed', error);
        throw error;
      })
    );
  }
}