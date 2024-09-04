import { HttpEvent, HttpHandler, HttpInterceptorFn, HttpRequest } from '@angular/common/http';

export const accessTokenInterceptor: HttpInterceptorFn = (req, next) => {
  const tokenAvailable = localStorage.getItem('accessToken') !== null;

  if (tokenAvailable) {
    req = req.clone({
      setHeaders: {
        Authorization: `Bearer ${localStorage.getItem('accessToken')}`
      }
    });
  }

  return next(req);
};
