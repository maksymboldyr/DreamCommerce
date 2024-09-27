import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { UserDto } from '../interfaces/user-dto';
import { catchError, map, Observable } from 'rxjs';
import { UserAdminUpdateDto } from '../interfaces/user-admin-update-dto';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  
  http: HttpClient;
  api : string;
  router: Router;

  constructor(http: HttpClient, router: Router) {
    this.http = http;
    this.api = environment.apiUrl;
    this.router = router;
  }

  getUsers(filter: string, page: number, pageSize: number, sortField?: string | string[], sortOrder?: number): Observable<{ totalCount: number, data: UserDto[] }> {
    let sortOrderString = sortOrder === 1 ? 'asc' : 'desc';
    return this.http.get<{ totalCount: number, data: UserDto[] }>(
      `${this.api}/Users/get-users?filter=${filter}&page=${page}&pageSize=${pageSize}&sortField=${sortField}&sortOrder=${sortOrderString}`).pipe(
      map((response: { totalCount: number, data: UserDto[] }) => {
        
        return {
          totalCount: response.totalCount,
          data: response.data.map(user => {
            return {
              id: user.id,
              email: user.email,
              firstName: user.firstName,
              lastName: user.lastName,
              phoneNumber: user.phoneNumber,
              address: user.address,
              roles: user.roles.map(role => role)
            };
          })
        };
      })
    );
  }

  updateUser(updatedUser: UserAdminUpdateDto): Observable<string> {
    return this.http.put(`${this.api}/Users/update-user`, updatedUser, { responseType: 'text' }).pipe(
      map((res: string) => {
        return res;
      }),
      catchError((error: HttpErrorResponse) => {
        console.error('Update user failed', error);
        throw error;
      })
    );
  }


}
