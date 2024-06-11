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
  vehicle: any = {};

  constructor(private vehicleS: VehicleService){}

  ngOnInit(): void {
    //Henter make og relateret modeller. Relateret modeller kommer i models.
    this.vehicleS.getMakes().subscribe({
      next:(makes => {
        console.log(makes)
        this.makes = makes;
      }),
      error:(error =>{
        console.log(error);
      })
    });

    this.vehicleS.getFeatures().subscribe({
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
  }
}
