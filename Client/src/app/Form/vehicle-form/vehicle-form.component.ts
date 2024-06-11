import { Component, OnInit } from '@angular/core';
import { VehicleService } from 'src/app/services/vehicle.service';


@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makes: any[] = [];
  models: any[] = [];
  features: any[] = [];
  // Indeholder valgte fra make select.
  vehicle: any = {
    features: [],
    contact: {}
  };

  constructor(private vehicleService: VehicleService){}

  ngOnInit(): void {
    //Henter make og relateret modeller. Relateret modeller kommer i models.
    this.vehicleService.getMakes().subscribe({
      next:(makes => {
        console.log(makes)
        this.makes = makes;
      }),
      error:(error =>{
        console.log(error);
      })
    });

    this.vehicleService.getFeatures().subscribe({
      next:(features => {
        this.features = features
        this.features.forEach(feature => console.log(feature))
      }),
      error:(error => console.log(error))
    })
  }

  // change event metoden.
  onMakeChange(){
    var selectedMake = this.makes.find(m => m.id == this.vehicle.makeId);
    this.models = selectedMake ? selectedMake.models : [];
    
    // refresher modelId
    delete this.vehicle.modelId;
  }

  onFeatureToggle(featureId: any, $event: Event) {
    const inputElement = $event.target as HTMLInputElement;
    if (inputElement?.checked)
      this.vehicle.features.push(featureId);
    else{
      var index = this.vehicle.features.indexOf(featureId);
      this.vehicle.features.splice(index, 1);
    }
  }

  submit(){
    this.vehicle.isRegistered = Boolean(this.vehicle.isRegistered);
    this.vehicleService.create(this.vehicle).subscribe(x => {
      console.log(x);
    });
  }
}
