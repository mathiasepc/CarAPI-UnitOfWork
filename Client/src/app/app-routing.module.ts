import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VehicleFormComponent } from './Form/vehicle-form/vehicle-form.component';

const routes: Routes = [
  { path: 'vehicles/new', component:VehicleFormComponent},
  { path: 'vehicles/:id', component:VehicleFormComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
