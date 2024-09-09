import { HttpEvent, HttpHandler, HttpInterceptorFn, HttpRequest } from '@angular/common/http';
import { tokenGetter } from '../../../app.config';

export const accessTokenInterceptor: HttpInterceptorFn = (req, next) => {
  const tokenAvailable = tokenGetter() !== null;

  if (tokenAvailable) {
    req = req.clone({
      setHeaders: {
        Authorization: `Bearer ${tokenGetter()}`
      }
    });
  }

  return next(req);
};
