import { FormsModule } from '@angular/forms';
import { ErrorHandler, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { NOTYF, notyfFactory } from './Shared/notyf.token';


// Sider på hjemmesiden
import { AppComponent } from './app.component';
import { VehicleFormComponent } from './Component/vehicle-form/vehicle-form.component';
import { NavbarComponent } from './Component/navbar/navbar.component';

// Imports
import { HttpClientModule } from '@angular/common/http';

// Providers
import { VehicleService } from './services/vehicle.service';
import { appErrorHandler } from './app.error-handler';
import { VehicleListComponent } from './Component/vehicle-list/vehicle-list.component';
import { PaginationComponent } from './Shared/pagination/pagination/pagination.component';


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
    FormsModule
  ],
  providers: [
    // Tilhører app.error-handler. ErrorHandler nedarver fra appErrorHandler.
    { provide: ErrorHandler, useClass: appErrorHandler },
    // TIlføjer mine servies
    VehicleService,
    // Dette tilhører en flot toasty notifikation.
    { provide: NOTYF, useFactory: notyfFactory }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
