import { Component, OnInit } from '@angular/core';
import { VehicleService } from 'src/app/services/vehicle.service';
import { ActivatedRoute, Router } from '@angular/router';
import { forkJoin } from 'rxjs';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css'],
})
export class VehicleFormComponent implements OnInit {
  makes: any[] = [];
  models: any[] = [];
  features: any[] = [];
  // Indeholder valgte fra make select.
  vehicle: any = {
    features: [],
    contact: {},
  };

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private vehicleService: VehicleService
  ) {
    // Konfigurere at det er id, som skal igennem ruten
    route.params.subscribe((p) => {
      this.vehicle.id = p['id'];
    });
  }

  ngOnInit(): void {
    var sources = [
      this.vehicleService.getMakes(),
      this.vehicleService.getFeatures()
    ];

    // Bruger forkJoin til at hente flere async metoder, som leverer data.
    forkJoin(sources).subscribe({
      next: (data) => {
        this.makes = data[0];
        this.features = data[1];
      }
    });

    if(this.vehicle.id){
      console.log("Vehicle id: " + this.vehicle.id);
      this.vehicleService.getVehicle(this.vehicle.id).subscribe({
        next: (v) =>{
          if(v.status == 400)
            this.router.navigate(['/']);
          else
            this.vehicle = v;         
        }
      });

    }
  }




















  
  // change event metoden.
  onMakeChange() {
    var selectedMake = this.makes.find((m) => m.id == this.vehicle.makeId);
    this.models = selectedMake ? selectedMake.models : [];

    // refresher modelId
    delete this.vehicle.modelId;
  }

  onFeatureToggle(featureId: any, $event: Event) {
    const inputElement = $event.target as HTMLInputElement;
    if (inputElement?.checked) this.vehicle.features.push(featureId);
    else {
      var index = this.vehicle.features.indexOf(featureId);
      this.vehicle.features.splice(index, 1);
    }
  }

  submit() {
    this.vehicle.isRegistered = Boolean(this.vehicle.isRegistered);
    this.vehicleService.create(this.vehicle).subscribe({
      next: (answer) => {
        console.log(answer);
      },
    });
  }
}
