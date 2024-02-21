import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Environment } from '../Environment/Environment';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class MakeService {
  private baseURL = Environment.APIurl;

  constructor(private http: HttpClient) { }

  getMakes(): Observable<any[]>{
    return this.http.get<any[]>(this.baseURL + 'Make/makes');
  }
}
