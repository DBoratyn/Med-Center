import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(private auth: AuthService) { }

  appointmentsAdmitted: any= {};
  appointmentsAdmittedNotAdmitted: any= {};
  tempdata: any= {};
  ngOnInit() {
    this.auth.getAllAppointments().subscribe(response => {
      console.log(response);
      this.tempdata = response;
      this.tempdata.forEach(element => {
        element.startDate = new Date(element.startDate);
        element.startDate = element.startDate.toISOString().split('T')[0];
        element.endDate = new Date(element.endDate);
        element.endDate = element.endDate.toISOString().split('T')[0];
      });
      console.log(this.tempdata);
    })
  }

}
