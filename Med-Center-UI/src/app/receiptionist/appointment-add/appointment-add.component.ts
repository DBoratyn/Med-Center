import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from 'src/app/_services/auth.service';
import { DxSchedulerModule } from 'devextreme-angular';
import { Router } from '@angular/router';

@Component({
  selector: 'app-appointment-add',
  templateUrl: './appointment-add.component.html',
  styleUrls: ['./appointment-add.component.css']
})
export class AppointmentAddComponent implements OnInit {

  appointmentsData:any = {};
  currentDate = Date.now();
  resourcesData: any[];

  services: any[] = [];

  selecteddoctorspecialization: any;
  selecteddoctor: any;
  selectedspecialization: any;
  splitter: any;

  patientName: string = '';
  patientsurname: string = '';
  patientaddress: string = '';
  patientpesel: string = ''

  constructor(private authService: AuthService, private router: Router) { 
  }

  ngOnInit() {
    this.authService.getAllServices().subscribe( response => {
      this.services = response;
    });
    
    this.authService.getAllAppointments().subscribe(response => {
        this.appointmentsData = response;
        console.log(response);
    });
  }

  updateAppointment(e) {
    let appointment = e.newData;
    this.authService.updateAppointment(appointment);
  }

  deleteAppointment(e) {
      this.authService.deleteAppointment(e.appointmentData.id).subscribe(response => {
          console.log(response);
      }, error => {
          console.log(error);
      });
  }
  
  makeAppointment(e) {
    this.splitter = this.selecteddoctorspecialization.toString().split(" #");
    this.selectedspecialization = this.splitter[0];
    this.selecteddoctor = this.splitter[1];

    e.appointmentData.description = "Patient: \n" + this.patientsurname + "," + this.patientName 
    + "\n" + this.patientpesel + "\n" + this.patientaddress + "\n\nDoctor:\n" + this.selecteddoctorspecialization;

    e.appointmentData.patientName = this.patientName;
    e.appointmentData.patientSurname = this.patientsurname;
    e.appointmentData.patientaddress = this.patientaddress;
    e.appointmentData.patientpesel = this.patientpesel;
    e.appointmentData.specialization = this.selectedspecialization;
    e.appointmentData.doctor = this.selecteddoctor;
    console.log(e);
    
    let appointment = e.appointmentData;
    this.authService.addAppointment(appointment);
  }

  CheckForm(data) {
    
    var that = this,
        form = data.form,
        startDate = data.appointmentData.startDate;

    form.option("items", [{
        label: {
            text: "Title"
        },
        dataField: "text",
        colSpan:"2",
        editorType: "dxTextBox",
        editorOptions: {
            readOnly: false,
            width: "100%"
        }
    }
    ,{
      label: {
          text: "Description"
      },
      dataField: "description",
      colSpan:"2",
      editorType: "dxTextArea",
      editorOptions: {
          readOnly: true,
          autoResizeEnabled: "true",
          width: "100%",
      }
  }, {
        dataField: "startDate",
        colSpan:"2",
        editorType: "dxDateBox",
        editorOptions: {
            width: "100%",
            type: "datetime",
            onValueChanged: function(args) {
                startDate = args.value;
                /*form.getEditor("endDate")
                    .option("value", new Date (startDate.getTime() + 60 * 1000 ));*/
            }
        }
    }, {
        name: "endDate",
        colSpan:"2",
        dataField: "endDate",
        editorType: "dxDateBox",
        editorOptions: {
            width: "100%",
            type: "datetime",
            readOnly: false
        }
    }]);
  }

  InsertForm(data) {
    
    var that = this,
        form = data.form,
        startDate = data.appointmentData.startDate;

    form.option("items", [{
        label: {
            text: "Title"
        },
        dataField: "text",
        colSpan:"2",
        editorType: "dxTextBox",
        editorOptions: {
            readOnly: false,
            width: "100%"
        }
    },{
        dataField: "startDate",
        colSpan:"2",
        editorType: "dxDateBox",
        editorOptions: {
            width: "100%",
            type: "datetime",
            onValueChanged: function(args) {
                startDate = args.value;
                //form.getEditor("endDate")
                //    .option("value", new Date (startDate.getTime() + 60 * 1000 ));
            }
        }
    }, {
        name: "endDate",
        colSpan:"2",
        dataField: "endDate",
        editorType: "dxDateBox",
        editorOptions: {
            width: "100%",
            type: "datetime",
            readOnly: false
        }
    }]);

  }

  onAppointmentFormOpening(data) {
    if (data.appointmentData.description === undefined || data.appointmentData.description === "" 
    || data.appointmentData.description === null) {
      this.InsertForm(data);
    } else {
      this.CheckForm(data);
    }
}

}
