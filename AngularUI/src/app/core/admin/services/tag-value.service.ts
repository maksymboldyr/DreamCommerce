import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { catchError, map, Observable } from 'rxjs';
import { TagValueDto } from '../interfaces/tag-value-dto';

@Injectable({
  providedIn: 'root'
})
export class TagValueService {
  http: HttpClient;
  api: string;

  constructor(http: HttpClient) {
    this.http = http;
    this.api = environment.apiUrl;
  }

  getAll(): Observable<TagValueDto[]> {
    return this.http.get<TagValueDto[]>(`${this.api}/TagValues/All`).pipe(
      map((response: TagValueDto[]) => {
        return response.map(tagValue => ({
          id: tagValue.id,
          tagId: tagValue.tagId,
          tagName: tagValue.tagName,
          value: tagValue.value,
          subcategoryName: tagValue.subcategoryName,
        }));
      }),
      catchError((error: any) => {
        console.error('Failed to fetch tag values', error);
        throw error;
      })
    );
  }

  getFiltered(filter: string, page: number, pageSize: number, sortField?: string | string[], sortOrder?: number): Observable<{ totalCount: number, data: TagValueDto[] }> {
    return this.http.get<{ totalCount: number, data: TagValueDto[] }>(
      `${this.api}/TagValues?filter=${filter}&page=${page}&pageSize=${pageSize}&sortField=${sortField}&sortOrder=${sortOrder}`
    ).pipe(
      map((response: { totalCount: number, data: TagValueDto[] }) => {
        return {
          totalCount: response.totalCount,
          data: response.data.map(tagValue => ({
            id: tagValue.id,
            tagId: tagValue.tagId,
            tagName: tagValue.tagName,
            value: tagValue.value,
            subcategoryName: tagValue.subcategoryName,
          }))
        };
      }),
      catchError((error: any) => {
        console.error('Failed to fetch filtered tag values', error);
        throw error;
      })
    );
  }

  getById(id: string): Observable<TagValueDto> {
    return this.http.get<TagValueDto>(`${this.api}/TagValues/${id}`).pipe(
      catchError((error: any) => {
        console.error(`Failed to fetch tag value with ID ${id}`, error);
        throw error;
      })
    );
  }

  create(tagValue: TagValueDto): Observable<string> {
    return this.http.post(`${this.api}/TagValues`, tagValue, { responseType: 'text' }).pipe(
      map((res: string) => {
        return res;
      }),
      catchError((error: any) => {
        console.error('TagValue creation failed', error);
        throw error;
      })
    );
  }

  update(tagValue: TagValueDto): Observable<void> {
    return this.http.put<void>(`${this.api}/TagValues/${tagValue.id}`, tagValue).pipe(
      catchError((error: any) => {
        console.error('TagValue update failed', error);
        throw error;
      })
    );
  }

  delete(id: string): Observable<string> {
    return this.http.delete(`${this.api}/TagValues/${id}`, { responseType: 'text' }).pipe(
      map((res: string) => {
        return res;
      }),
      catchError((error: any) => {
        console.error('TagValue deletion failed', error);
        throw error;
      })
    );
  }
}