import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { RegisterDto } from './register/register.component';
import { LoginDto } from './login/login.component';
import { catchError, map, Observable, of } from 'rxjs';
import { LoginResponseDTO } from './interfaces/login-response-dto';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  api: string;
  http: HttpClient;

  constructor(http: HttpClient) { 
    this.api = environment.apiUrl;
    this.http = http;
  }

  get accessToken() {
    return localStorage.getItem('accessToken');
  }

  register(registerDto: RegisterDto) {
    return this.http.post(`${this.api}/register`, registerDto);
  }

  login(loginDto: LoginDto) : Observable<LoginResponseDTO>{
    return this.http.post<LoginResponseDTO>(`${this.api}/login`, loginDto)
      .pipe(map((res => {
        localStorage.setItem('accessToken', res.accessToken);
        document.cookie = `refreshToken=${res.refreshToken};`;
        return res;
      }
    )));
  }

  refreshToken() : Observable<LoginResponseDTO> {
    const refreshToken = this.getRefreshTokenFromCookie();
    return this.http.post<LoginResponseDTO>(`${this.api}/refresh-token`, { refreshToken })
      .pipe(map((res => {
        localStorage.setItem('accessToken', res.accessToken);
        document.cookie = `refreshToken=${res.refreshToken};`;
        return res;
      }
    )));
  }
  
  isAuthenticated(): Observable<boolean> {
    if (localStorage.getItem('accessToken') === null) {
      return of(false);
    }

    return this.http.get(`${this.api}/validate-access-token`)
      .pipe(
        map(() => true),
        catchError(() => of(false))
      );
  }

  logout() {
    localStorage.removeItem('accessToken');
  }

  forgotPassword(email: string) {
    return this.http.post(`${this.api}/forgot-password`, { email });
  }

  private getRefreshTokenFromCookie() : string | null {
    const cookie = document.cookie;
    const cookieArray = cookie.split('; ');
    for (const cookie of cookieArray) {
      const [key, value] = cookie.split('=');
      if (key === 'refreshToken') {
        return value;
      }
    }

    return null;
  }

  
}
