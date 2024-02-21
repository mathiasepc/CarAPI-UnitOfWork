import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';

// Sider på hjemmesiden
import { AppComponent } from './app.component';
import { VehicleFormComponent } from './Form/vehicle-form/vehicle-form.component';
import { NavbarComponent } from './SharePages/navbar/navbar.component';

// Imports
import { HttpClientModule } from '@angular/common/http';

// Providers
import { MakeService } from './services/make.service';

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
    MakeService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
