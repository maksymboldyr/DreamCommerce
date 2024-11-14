import { ApplicationConfig, importProvidersFrom, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import { provideAnimations } from '@angular/platform-browser/animations';
import { HTTP_INTERCEPTORS, provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';
import { AccessTokenInterceptor } from './core/auth/interceptors/access-token.interceptor';

export function tokenGetter() {
  return localStorage.getItem("access_token");
}

export function tokenSetter(token: string) {
  localStorage.setItem("access_token", token);
}

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideHttpClient(
      withInterceptorsFromDi()
    ),
    provideRouter(routes),
    provideAnimations(),
    importProvidersFrom(
      JwtModule.forRoot({
        config: {
          tokenGetter: tokenGetter,
        },
      }),
    ),
    { provide: HTTP_INTERCEPTORS, useClass: AccessTokenInterceptor, multi: true }
  ]
};