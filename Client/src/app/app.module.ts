import { FormsModule } from '@angular/forms';
import { ErrorHandler, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';


// Sider på hjemmesiden
import { AppComponent } from './app.component';
import { VehicleFormComponent } from './Component/vehicle-form/vehicle-form.component';
import { NavbarComponent } from './Component/navbar/navbar.component';
import { VehicleListComponent } from './Component/vehicle-list/vehicle-list.component';
import { PaginationComponent } from './Shared/pagination/pagination/pagination.component';

// Providers
import { HttpClientModule } from '@angular/common/http';
import { NOTYF, notyfFactory } from './Shared/notyf.token';
import { VehicleService } from './services/vehicle.service';
import { appErrorHandler } from './app.error-handler';
import { AuthModule } from '@auth0/auth0-angular';


@NgModule({
  declarations: [
    AppComponent,
    VehicleFormComponent,
    NavbarComponent,
    VehicleListComponent,
    PaginationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    // konfigurer auth parameter for web app 
    AuthModule.forRoot({
      domain: 'dev-66ke8ng4sr6cp2ms.us.auth0.com',
      clientId: 'Rg8p9AsiK4CWv459DK6sTV9db6Rw4t2m',
      authorizationParams: {
        redirect_uri: window.location.origin,
        // api audience.
        // audience: 'https://api.car.com'
      }
    }),
  ],
  providers: [
    // Tilhører app.error-handler. ErrorHandler nedarver fra appErrorHandler.
    { provide: ErrorHandler, useClass: appErrorHandler },
    // Dette tilhører en flot toasty notifikation.
    { provide: NOTYF, useFactory: notyfFactory },
    // TIlføjer mine servies
    VehicleService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
