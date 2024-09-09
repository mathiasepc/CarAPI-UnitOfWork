import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';

// Sider på hjemmesiden
import { AppComponent } from './app.component';
import { VehicleFormComponent } from './Component/vehicle-form/vehicle-form.component';
import { NavbarComponent } from './Component/navbar/navbar.component';
import { VehicleListComponent } from './Component/vehicle-list/vehicle-list.component';
import { PaginationComponent } from './Shared/pagination/pagination/pagination.component';

// Providers
import { 
  ErrorHandler, 
  NgModule 
} from '@angular/core';
import { 
  HTTP_INTERCEPTORS, 
  HttpClientModule 
} from '@angular/common/http';
import { 
  NOTYF, 
  notyfFactory 
} from './Shared/notyf.token';
import { VehicleService } from './services/vehicle.service';
import { appErrorHandler } from './app.error-handler';
import {
  AuthModule,
  HttpMethod,
} from '@auth0/auth0-angular';
import { AuthInterceptor } from './services/auth-interceptor.service';

@NgModule({
  declarations: [
    AppComponent,
    VehicleFormComponent,
    NavbarComponent,
    VehicleListComponent,
    PaginationComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    // Modify your existing SDK configuration to include the httpInterceptor config
    AuthModule.forRoot({
      domain: 'dev-66ke8ng4sr6cp2ms.us.auth0.com',
      clientId: 'tzMbXHkCWSUTZXcwTxJRXyN6RerWon75',
      authorizationParams: {
        redirect_uri: window.location.origin,

        // Request this audience at user authentication time
        audience: 'https://api.UnitOfWork.com',

        // Request this scope at user authentication time
        scope: 'read:current_user',
      },
      // The AuthHttpInterceptor configuration
      httpInterceptor: {
        allowedList: [
          // // Attach access tokens to any calls to '/api' (exact match)
          // '/api',

          // // Attach access tokens to any calls that start with '/api/'
          // '/api/*',
          // Match anything starting with /api/vehicles, but also allow for anonymous users.
          {
            uri: '/api/Vehicles/*',
            allowAnonymous: true,
          },

          // Match anything starting with /api/accounts, but also specify the audience and scope the attached
          // access token must have
          {
            uri: '/api/Vehicles/*',
            tokenOptions: {
              authorizationParams: {
                audience: 'https://api.UnitOfWork.com',
                scope: 'read:vehicles',
              },
            },
          },

          // Matching on HTTP method
          {
            uri: '/api/Vehicles',
            httpMethod: HttpMethod.Post,
            tokenOptions: {
              authorizationParams: {
                audience: 'https://api.UnitOfWork.com',
                scope: 'write:vehicles',
                // scope: 'write:admin',  
              },
            },
          },

          // Using an absolute URI
          {
            uri: 'dev-66ke8ng4sr6cp2ms.us.auth0.com/api/v2/users',
            tokenOptions: {
              authorizationParams: {
                audience: 'dev-66ke8ng4sr6cp2ms.us.auth0.com/api/v2/',
                scope: 'read:users',
              },
            },
          },
        ],
      },
    }),
  ],
  providers: [
    // Tilhører app.error-handler. ErrorHandler nedarver fra appErrorHandler.
    { provide: ErrorHandler, useClass: appErrorHandler },
    // Dette tilhører en flot toasty notifikation.
    { provide: NOTYF, useFactory: notyfFactory },
    // HTTP_INTERCEPTORS er til at kalde beskyttet API. multi er for at fortælle, at der kan være flere api'er
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    // TIlføjer mine servies
    VehicleService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
