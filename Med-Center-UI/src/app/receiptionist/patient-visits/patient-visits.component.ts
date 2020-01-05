import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-patient-visits',
  templateUrl: './patient-visits.component.html',
  styleUrls: ['./patient-visits.component.css']
})
export class PatientVisitsComponent implements OnInit {
  listOfAppointments: any;
  currentFilter: any;

  constructor(private authservice: AuthService) { }

  ngOnInit() {
    this.getData();
  }

  getData() {
    this.authservice.getAllAppointments().subscribe(response => {
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

  payVisit(e) {
    this.authservice.payAppointment(e.data.id).subscribe( () => {
      this.getData();
    });
    console.log(e);
  }

}
