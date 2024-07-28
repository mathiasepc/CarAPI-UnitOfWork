import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Environment } from '../Environment/Environment';


@Injectable({
  providedIn: 'root'
})
export class VehicleService {
  private baseURL = Environment.APIurl;

  constructor(
    private http: HttpClient) { }

  getMakes(): Observable<any[]>{
    return this.http.get<any[]>(this.baseURL + 'Make');
  }

  getFeatures(): Observable<any[]>{
    return this.http.get<any[]>(this.baseURL + 'Feature');
  }

  create(vehicle: {}): Observable<any>{
    return this.http.post(this.baseURL + 'Vehicles', vehicle);
  }

getVehicles(filter: any): Observable<any> {
  return this.http.get(this.baseURL + 'Vehicles?' + this.toQueryString(filter));
}

// Konverterer et objekt til en query string.
toQueryString(obj: any): string {
  var parts = [];

  for (var property in obj) {
    // Henter værdien af egenskaben
    var value = obj[property];

    // Hvis værdien ikke er null eller undefined
    if (value != null || value != undefined) {
      // Tilføjer variablens navn og værdien på variablen til parts arrayet
      parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
    }
  }

  // Samler alle dele i parts arrayet til en enkelt query string, adskilt af '&'
  return parts.join('&');
}


  getVehicle(id: any): Observable<any> {
    return this.http.get(this.baseURL + 'Vehicles/' + id);
  }
  
  delete(id: string): Observable<any>{
    return this.http.delete(this.baseURL + 'Vehicles/' + id);
  }
}
