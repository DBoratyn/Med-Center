import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PriceService {
  baseUrl = 'http://localhost:5000/api/price/';
  patients: any = {};

  constructor(private http: HttpClient) { }

  getPrices(): Observable<any> {
   return this.http.get(this.baseUrl + 'getallprices');
  }

}
