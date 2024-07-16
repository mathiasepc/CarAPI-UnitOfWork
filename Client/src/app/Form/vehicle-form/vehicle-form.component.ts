import { Component, OnInit } from '@angular/core';
import { VehicleService } from 'src/app/services/vehicle.service';
import { ActivatedRoute, Router } from '@angular/router';
import { forkJoin, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { SaveVehicle } from 'src/app/Models/saveVehicle';
import { Vehicle } from 'src/app/Models/vehicle';

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
  vehicle: SaveVehicle = {
    id: '',
    modelId: '',
    makeId: '',
    isRegistered: false,
    features: [],
    contact: { name: '', email: '', phone: 0 }
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

    // der kom en toasty message hele tiden, da denne metode lå med de andre i source.
    // rykkede den derfor herned, så den kun kører hvis id er udfyldt.
    if (this.vehicle.id) {
      sources.push(
          this.vehicleService.getVehicle(this.vehicle.id).pipe(
              catchError(error => {
                  console.error('Error loading vehicle', error);
                  return of([]); // Returnerer null ved fejl
              })
          )
      );
  }

    // Bruger forkJoin til at hente flere async metoder, som leverer data.
    // Hvis en fejler, fejler alle.
    forkJoin(sources).subscribe({
      next: (data) => {
        this.makes = data[0];
        this.features = data[1];

        if (this.vehicle.id) {
          // hvis der er tom data i data[2] skift til index.
          if (data[2] === null || (Array.isArray(data[2]) && data[2].length === 0)) {
              this.router.navigate(['/']);
          }

          // Kontroller, om data[2] er en Vehicle-objekt eller en tom array. 
          // sæt til data[2] hvis ikke det er et array.
          const vehicleData = Array.isArray(data[2]) ? null : data[2];

          if(vehicleData !== null){
            this.setVehicle(vehicleData);
            this.populateModels();
          }
      }

      }
    }); 
  }

  // Sætter værdier som vi får fra ngOnInit.
  private setVehicle(v: Vehicle){
    this.vehicle.id = v.id;
    this.vehicle.makeId = v.make.id;
    this.vehicle.modelId = v.model.id;
    this.vehicle.isRegistered = v.isRegistered;
    this.vehicle.features = v.features.map(x => x.id);
    this.vehicle.contact = v.contact;
  }
  

  // change event metoden.
  onMakeChange() {
    this.populateModels();

    // refresher modelId
    this.vehicle.modelId = '';
  }

  private populateModels(){
    // matcher vehicle-objekt makeId med this.Makes' id.
    var selectedMake = this.makes.find((m) => m.id == this.vehicle.makeId);

    // sætter models hvis vi fandt en make.
    this.models = selectedMake ? selectedMake.models : [];
  }



  // Laver en event for checkbokse.
  onFeatureToggle(featureId: any, $event: Event) {
    const inputElement = $event.target as HTMLInputElement;

    if (inputElement?.checked) 
      this.vehicle.features.push(featureId);
    else {
      var index = this.vehicle.features.indexOf(featureId);
      this.vehicle.features.splice(index, 1);
    }
  }

  submit() {
    // Da Det ikke var en rigtig bool. Blev jeg nød til at konventere den til bool.
    this.vehicle.isRegistered = Boolean(this.vehicle.isRegistered);
    this.vehicleService.create(this.vehicle).subscribe({
      next: (answer) => {
        console.log(answer);
      },
    });
  }

  delete(){
    if(confirm("Are you sure")){
      this.vehicleService.delete(this.vehicle.id).subscribe({
        next: (answer) => {
          this.router.navigate(['/']);
        }
      });
      }
  }
}
