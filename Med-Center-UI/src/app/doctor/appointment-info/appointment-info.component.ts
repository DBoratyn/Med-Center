import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from 'src/app/_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-appointment-info',
  templateUrl: './appointment-info.component.html',
  styleUrls: ['./appointment-info.component.css']
})
export class AppointmentInfoComponent implements OnInit {

  AppointmentId: any;

  listOfSickness: any = {};
  VisitInfo:any = {};
  listOfMedicines: any = {};

  addSicknessToAdd: any = {};

  constructor(private auth: AuthService, private router: Router) { }

  ngOnInit() {
    this.AppointmentId = localStorage.getItem("AppointmentId");
    this.getListOfSickness();
    this.getListOfMedicines();
    console.log("ree");
  }

  backButton(){
    console.log("Back");
   this.router.navigateByUrl('/appointments');
  }

  deleteRowVisit(e) {

  }

  addRowVisit(e) {
    console.log(e);
  }

  updateRowVisit(e) {

  }

  addRow(e) {
    console.log(e);
    this.addSicknessToAdd.sicknessName = e.data.sicknessName;
    this.addSicknessToAdd.sicknessDescription = e.data.sicknessDescription;
    this.addSicknessToAdd.cured = false;
    this.addSicknessToAdd.appointmentId = this.AppointmentId;

    this.auth.addSickness(this.addSicknessToAdd, this.AppointmentId);
  }

  deleteMedicineRow(e) {
    const idToDelete = e.data.id;
    this.auth.DeleteMedicine(idToDelete).subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    })
  }

  deleteRow(e) {
    const idToDelete = e.data.id;
    this.auth.DeleteSickness(idToDelete).subscribe(response => {
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

     this.oldData.Id = this.oldData.id;
     if (this.newData.sicknessDescription !== undefined) {
       this.oldData.sicknessDescription = this.newData.sicknessDescription;
     }

     if (this.newData.sicknessName !== undefined) {
       this.oldData.sicknessName = this.newData.sicknessName;
     }

     if (this.newData.cured !== undefined) {
       this.oldData.cured = this.newData.cured;
     }

    console.log(e);
    console.log(this.oldData);

    this.auth.updateSickness(this.oldData);

  }

  getListOfMedicines() {
    this.auth.getAllMedicine(this.AppointmentId).subscribe (response => {
      this.listOfMedicines = response;
      console.log("MEDS");
      console.log(this.listOfMedicines);
    },error => { console.log(error)});
  }

  getListOfSickness() {
    this.auth.getAllSickness(this.AppointmentId).subscribe( response => {
      this.listOfSickness = response;
      console.log("listOfSickness");
      console.log(this.listOfSickness);
    },error => { console.log(error)});
  }


}
