import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-appointments',
  templateUrl: './appointments.component.html',
  styleUrls: ['./appointments.component.css']
})
export class AppointmentsComponent implements OnInit {

  currentFilter:any;
  listOfAppointments: any = {};
  name: any;
  AppointmentIdToSend: any;
  constructor(private authservice: AuthService, private router: Router) { }

  ngOnInit() {
    this.getData();
  }

  openInfo(e) {
   this.AppointmentIdToSend = e.data.id;
   localStorage.setItem("AppointmentId", this.AppointmentIdToSend);
   this.router.navigateByUrl('/appointmentInfo');
  }

  getData() {
    this.authservice.GetDoctorAppointments(localStorage.getItem("name")).subscribe(response => {
      console.log(response);
      this.listOfAppointments = response;
      this.listOfAppointments.forEach(element => {
        element.startDate = new Date(element.startDate);
        if (element.paid === false) {
          element.paid = "N";
        } else {
          element.paid = "Y";
        }
      });
    });
  }
}
