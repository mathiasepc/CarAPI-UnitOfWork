import { VehicleService } from './../../services/vehicle.service';
import { Vehicle } from './../../Models/vehicle';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.css']
})
export class VehicleListComponent implements OnInit {
  vehicles: Vehicle[] | undefined;

  constructor(private VehicleService: VehicleService) {}

  ngOnInit(): void {
    this.VehicleService.getVehicles()
    .subscribe(vehicles => this.vehicles = vehicles);
  }

}
