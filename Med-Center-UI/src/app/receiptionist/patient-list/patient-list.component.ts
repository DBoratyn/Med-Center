import { Component, OnInit } from '@angular/core';
import { DxDataGridModule } from 'devextreme-angular';
import { PatientService } from '../../_services/patient.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-patient-list',
  templateUrl: './patient-list.component.html',
  styleUrls: ['./patient-list.component.css']
})
export class PatientListComponent implements OnInit {
  listOfPatients: any = {};
  baseUrl = 'http://localhost:5000/api/patient/';

  currentFilter: any;
  popupVisible = false;

  constructor(public patientService: PatientService, private http: HttpClient, private router: Router,
     private authService: AuthService) {}

  ngOnInit() {
    this.getPatients();
  }

  getPatients() {
    this.patientService.getPatients().subscribe(response => {
      this.listOfPatients = response;
      console.log(response);
    });
  }

  deleteRow(e) {
    console.log("REEEEEEEEEEEEEEEEEEEee");
    const idToDelete = e.data.id;
    this.authService.deletePatient(idToDelete).subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    })
  }

  newData: any;
  oldData: any;
  updateRow(e) {
     this.newData = e.newData;
     this.oldData = e.oldData;
     let updateData = this.oldData;

     for (var key in this.newData) {
      if (this.newData.hasOwnProperty(key)) {
         //console.log(key + " -> " + this.newData[key]);
         for (var oldKey in this.oldData) {
          if (oldKey === key) {
            updateData[oldKey] === this.newData[key];
          }
        }
      }
    }
    console.log(e);

    this.authService.updatePatient(this.oldData);

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
