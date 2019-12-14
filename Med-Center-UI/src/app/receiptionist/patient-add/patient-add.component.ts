import { Component, OnInit } from '@angular/core';
import { PatientService } from '../../_services/patient.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-patient-add',
  templateUrl: './patient-add.component.html',
  styleUrls: ['./patient-add.component.css']
})
export class PatientAddComponent implements OnInit {

  patient: any = {};
  constructor(public patientService: PatientService, private http: HttpClient) {}

  ngOnInit() {
  }

  addPatient() {
    this.patientService.addPatient(this.patient);
  }

}
