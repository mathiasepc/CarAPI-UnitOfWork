import { FormsModule } from '@angular/forms';
import { ErrorHandler, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { NOTYF, notyfFactory } from './Shared/notyf.token';


// Sider på hjemmesiden
import { AppComponent } from './app.component';
import { VehicleFormComponent } from './Form/vehicle-form/vehicle-form.component';
import { NavbarComponent } from './SharePages/navbar/navbar.component';

// Imports
import { HttpClientModule } from '@angular/common/http';

// Providers
import { VehicleService } from './services/vehicle.service';
import { appErrorHandler } from './app.error-handler';

@NgModule({
  declarations: [
    AppComponent,
    VehicleFormComponent,
    NavbarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    // Tilhører app.error-handler. ErrorHandler nedarver fra appErrorHandler.
    { provide: ErrorHandler, useClass: appErrorHandler },
    VehicleService,
    // Dette tilhører en flot toasty notifikation.
    { provide: NOTYF, useFactory: notyfFactory }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
