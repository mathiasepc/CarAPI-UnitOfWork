import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VehicleFormComponent } from './Component/vehicle-form/vehicle-form.component';
import { VehicleListComponent } from './Component/vehicle-list/vehicle-list.component';
import { AuthGuard } from '@auth0/auth0-angular';

const routes: Routes = [
  // sætter index til at være vehicles
  { path: '', 
    redirectTo: 'vehicles', 
    pathMatch: "full"
  },
  { path: 'vehicles/new', 
    component:VehicleFormComponent, 
    // canActivate er til for at fortælle kun authenticated users
    canActivate: [AuthGuard] 
  },
  { path: 'vehicles/:id', 
    component:VehicleFormComponent
  },
  { path: 'vehicles', 
    component:VehicleListComponent 
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
