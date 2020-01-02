import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-service-list',
  templateUrl: './service-list.component.html',
  styleUrls: ['./service-list.component.css']
})
export class ServiceListComponent implements OnInit {

  listOfServices: any = {};
  currentFilter: any;

  serviceToUpdate: any = {};
  serviceToAdd: any = {};
  constructor( private authService: AuthService) { }

  ngOnInit() {
    this.authService.getDoctorServices(this.authService.getName()).subscribe( response => {
      response.sort((a,b) => 0 - (a > b ? -1 : 1));
      this.listOfServices = response;
    })
  }

  addRow(e) {
    console.log(e);
    this.serviceToAdd.nameOfTreatment = e.data.nameOfTreatment;
    this.serviceToAdd.specialization = e.data.specialization;
    this.serviceToAdd.price = e.data.price;

    if(this.serviceToAdd.nameOfTreatment === undefined || this.serviceToAdd.nameOfTreatment === null) {
      this.serviceToAdd.nameOfTreatment = "";
    }

    if(this.serviceToAdd.specialization === undefined || this.serviceToAdd.specialization === null) {
      this.serviceToAdd.specialization = "";
    }

    if(this.serviceToAdd.price === undefined || this.serviceToAdd.price === null) {
      this.serviceToAdd.price = 0;
    }

    this.serviceToAdd.DoctorName  = this.authService.getName();

    this.authService.addService(this.serviceToAdd);

    this.serviceToAdd = {};
  }

  deleteRow(e) {
    const idToDelete = e.data.id;
    this.authService.deleteDoctorService(idToDelete).subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    })
  }

  updateRow(e) { 
    console.log(e);
    this.serviceToUpdate.id = e.oldData.id;
    if (e.newData.nameOfTreatment === undefined) {
      this.serviceToUpdate.nameOfTreatment = e.oldData.nameOfTreatment;
    } else {
      this.serviceToUpdate.nameOfTreatment = e.newData.nameOfTreatment;
    }
    if (e.newData.specialization === undefined) {
      this.serviceToUpdate.specialization = e.oldData.specialization;
    } else {
      this.serviceToUpdate.specialization = e.newData.specialization;
    }
    if (e.newData.price === undefined) {
      this.serviceToUpdate.price = e.oldData.price;
    } else {
      this.serviceToUpdate.price = e.newData.price;
    }

    this.serviceToUpdate.DoctorName = this.authService.getName();

    this.authService.updateService(this.serviceToUpdate);
    this.serviceToUpdate = {};
  }

}
