import { VehicleService } from './../../services/vehicle.service';
import { Vehicle } from './../../Models/vehicle';
import { Component, OnInit } from '@angular/core';
import { KeyValuePair } from 'src/app/Models/keyValuePair';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.css']
})
export class VehicleListComponent implements OnInit {
  vehicles: Vehicle[] | undefined;
  makes: KeyValuePair[] | undefined;
  // den vi sender til server ift. sortBy og pageing.
  query: any = {};

  constructor(private VehicleService: VehicleService) {}

  ngOnInit(): void {
    this.VehicleService.getMakes()
    .subscribe(makes => this.makes = makes);
    
    this.populateVehicles();
  }

  // Her laver vi filter for det man vælger fra dropdownlisten.
  onFilterChange(){
    this.populateVehicles();
  }

  resetFilter(){
    this.query = {};

    this.onFilterChange();
  }

  // Her sætter vi this.vehicles udfra vores query
  private populateVehicles(){
    for(var property in this.query){
      console.log('query property: ', this.query[property]);
    }
    this.VehicleService.getVehicles(this.query)
    .subscribe(vehicles => this.vehicles = vehicles);
  }

  // isSortAscending styrer om sorteringen er stigende eller faldende
  sortBy(columnName: any){
    if(this.query.sortBy === columnName){
      // For at kunne skifte mere end en gang, sætter vi isSortAscending til det modsatte.
      this.query.isSortAscending = !this.query.isSortAscending;
    }
    else{
      // Når en ny kolonne bliver sat, sættes sortBy til dette. 
      this.query.sortBy = columnName;
      this.query.isSortAscending = true;
    }

    this.populateVehicles();
  }
}



