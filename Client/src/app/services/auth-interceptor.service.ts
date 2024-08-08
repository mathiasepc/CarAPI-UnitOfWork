import { 
  HttpHandler, 
  HttpInterceptor, 
  HttpRequest 
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { 
  from, 
  switchMap 
} from 'rxjs';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private auth: AuthService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    return from(this.auth.getAccessTokenSilently().pipe(
      switchMap(idToken => {

        console.log("idToken: ", idToken);
        const authReq = req.clone({
          setHeaders: {
            Authorization: `Bearer ${idToken}`
          }
        });

        return next.handle(authReq)
      })
    ))
  }
  

}
