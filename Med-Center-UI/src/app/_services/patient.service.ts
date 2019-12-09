import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PatientService {
  baseUrl = 'http://localhost:5000/api/patient/';
  patients: any = {};

  constructor(private http: HttpClient) { }

  getPatients(): Observable<any> {
   return this.http.get(this.baseUrl + 'getallpatients');
  }

  addPatient(patient: any) {
    this.http.post(this.baseUrl + 'addPatient', patient).subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    });
  }

}
