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
    // 'from' konverterer en Observable eller Promise til en ny Observable
    return from(
      // Hent access token JWT (silent authentication)
      this.auth.getAccessTokenSilently().pipe(
        // switchMap bruges til at skifte fra den første Observable (token-forespørgsel)
        // til en ny Observable (HTTP-anmodningen med token)
        switchMap(idToken => {
          // Klon den oprindelige HTTP-anmodning og tilføj Authorization-headeren med Bearer token
          const authReq = req.clone({
            setHeaders: {
              // Tilføjer token som en Bearer token i Authorization-headeren
              Authorization: `Bearer ${idToken}` 
            }
          });

          // Log tokenen til debugging
          console.log("idToken: ", authReq.headers);
  
  
          // Send den modificerede HTTP-anmodning videre til næste handler i rækken.
          return next.handle(authReq)
        })
      )
    );
  }
  
}
  
