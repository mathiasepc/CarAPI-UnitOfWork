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
  filter: any = {};

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
    this.filter = {};

    this.onFilterChange();
  }

  private populateVehicles(){
    this.VehicleService.getVehicles(this.filter)
    .subscribe(vehicles => this.vehicles = vehicles);
  }
}
