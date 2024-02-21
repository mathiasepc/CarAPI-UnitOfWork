import { Component, OnInit } from '@angular/core';
import { MakeService } from 'src/app/services/make.service';


@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makes: any[] = [];
  models: any[] = [];
  // Indeholder valgte fra make select.
  vehicle: any = {};

  constructor(private makeService: MakeService){}

  ngOnInit(): void {
    this.makeService.getMakes().subscribe(makes =>
      this.makes = makes);
  }

  // change event metoden.
  onMakeChange(){
    var selectedMake = this.makes.find(m => m.id == this.vehicle.make);
    this.models = selectedMake ? selectedMake.models : [];
  }
}
