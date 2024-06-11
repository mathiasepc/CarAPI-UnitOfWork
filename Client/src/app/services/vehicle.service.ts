import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Environment } from '../Environment/Environment';


@Injectable({
  providedIn: 'root'
})
export class VehicleService {
  private baseURL = Environment.APIurl;

  constructor(private http: HttpClient) { }

  getMakes(): Observable<any[]>{
    return this.http.get<any[]>(this.baseURL + 'Make');
  }

  getFeatures(): Observable<any[]>{
    return this.http.get<any[]>(this.baseURL + 'Feature');
  }

  create(vehicle: {}): Observable<any>{
    return this.http.post(this.baseURL + 'Vehicles', vehicle)
  }
}
