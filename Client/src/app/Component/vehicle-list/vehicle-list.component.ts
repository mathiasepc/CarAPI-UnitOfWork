import { VehicleService } from '../../services/vehicle.service';
import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { KeyValuePair } from 'src/app/Models/keyValuePair';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.css']
})
export class VehicleListComponent implements OnInit {
  // true = hvis du er logget ind. false = hvis du ikke er logget ind.
  isAuthenticated$ = this.auth.isAuthenticated$;
  // Så vi selv kan styrer pageSize.
  private readonly PAGE_SIZE = 5; 

  queryResult: any = {};
  make: KeyValuePair[] | undefined;
  query: any = {
    pageSize: this.PAGE_SIZE
  };
  columns = [
    { title: 'Id' },
    { title: 'Make', key: 'make', isSortable: true },
    { title: 'Model', key: 'model', isSortable: true },
    { title: 'Contact name', key: 'contactName', isSortable: true },
    { title: 'View model' }
  ];

  constructor(private vehicleService: VehicleService,
    private auth: AuthService
  ) { }

  ngOnInit() { 
    this.vehicleService.getMakes()
      .subscribe(makes => this.make = makes);

    this.populateVehicles();
  }

  // Her sætter vi this.vehicles udfra vores query
  private populateVehicles(){
    this.vehicleService.getVehicles(this.query)
    .subscribe(result => this.queryResult = result );
  }

  onFilterChange() {
    // Når filter ændres sættes page til 1
    this.query.page = 1; 
    this.populateVehicles();
  }

  resetFilter() {
    this.query = {
      page: 1,
      pageSize: this.PAGE_SIZE
    };
    
    this.populateVehicles();
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

  onPageChange(page: any) {
    this.query.page = page; 
    this.populateVehicles();
  }
}