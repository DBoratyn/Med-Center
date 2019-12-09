import { Component, OnInit } from '@angular/core';
import { DxDataGridModule } from 'devextreme-angular';
import { PatientService } from '../_services/patient.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-patient-list',
  templateUrl: './patient-list.component.html',
  styleUrls: ['./patient-list.component.css']
})
export class PatientListComponent implements OnInit {
  listOfPatients: any = {};
  baseUrl = 'http://localhost:5000/api/patient/';

  constructor(public patientService: PatientService, private http: HttpClient) {}

  ngOnInit() {
    this.getPatients();
  }

  getPatients() {
    this.patientService.getPatients().subscribe(response => {
      this.listOfPatients = response;
    });
  }
}
