import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { inject } from '@angular/core';
import { catchError, map, of } from 'rxjs';

export const authGuard: CanActivateFn = (route, state) => {
  const auth = inject(AuthService);
  const router = inject(Router);

  return auth.isAuthenticated().pipe(
    map(isAuthenticated => {
      if (!isAuthenticated) {
        router.navigate(['/login']);
        return false;
      }

      let role = route.data['role'];

      if (role && !auth.hasRole(role)) {
        router.navigate(['/']);
                
        return false
      }

      return true;
    }, catchError(() => {
      return of(false);
    })
  ));
};
