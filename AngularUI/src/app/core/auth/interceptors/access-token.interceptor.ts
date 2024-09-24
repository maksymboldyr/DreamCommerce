import { Injectable } from '@angular/core';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tokenGetter } from '../../../app.config';

@Injectable()
export class AccessTokenInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const tokenAvailable = tokenGetter();

    if (tokenAvailable) {
      req = req.clone({
        setHeaders: {
          Authorization: `Bearer ${tokenAvailable}`
        }
      });
    }

    return next.handle(req);
  }
}