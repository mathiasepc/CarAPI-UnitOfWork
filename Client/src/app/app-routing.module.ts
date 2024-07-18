import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VehicleFormComponent } from './Form/vehicle-form/vehicle-form.component';
import { VehicleListComponent } from './Form/vehicle-list/vehicle-list.component';

const routes: Routes = [
  // sætter index til at være vehicles
  { path: '', redirectTo: 'vehicles', pathMatch: "full"},
  { path: 'vehicles/new', component:VehicleFormComponent},
  { path: 'vehicles/:id', component:VehicleFormComponent},
  { path: 'vehicles', component:VehicleListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
