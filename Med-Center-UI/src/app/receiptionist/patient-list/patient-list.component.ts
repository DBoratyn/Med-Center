import { Component, OnInit } from '@angular/core';
import { DxDataGridModule } from 'devextreme-angular';
import { PatientService } from '../../_services/patient.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-patient-list',
  templateUrl: './patient-list.component.html',
  styleUrls: ['./patient-list.component.css']
})
export class PatientListComponent implements OnInit {
  listOfPatients: any = {};
  baseUrl = 'http://localhost:5000/api/patient/';

  currentFilter: any;

  constructor(public patientService: PatientService, private http: HttpClient, private router: Router) {}

  ngOnInit() {
    this.getPatients();
  }

  getPatients() {
    this.patientService.getPatients().subscribe(response => {
      this.listOfPatients = response;
      console.log(response);
    });
  }

  AppointPatient(e){
    console.log(e);
    localStorage.setItem("Name", e.data.name);
    localStorage.setItem("Surname", e.data.surname);

    if (e.data.houseNumber !== null && e.data.houseNumber !== undefined && e.data.houseNumber !== ""){
      localStorage.setItem("Address", e.data.houseNumber);
    }

    if (e.data.apartmentNumber !== null && e.data.apartmentNumber !== undefined && e.data.apartmentNumber !== ""){
      localStorage.setItem("Address", e.data.apartmentNumber);
    }
    
    localStorage.setItem("Pesel", e.data.pesel);

    this.router.navigateByUrl('/appointmentadd');
  }
}
