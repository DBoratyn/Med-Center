import { BrowserModule } from '@angular/platform-browser';
import { NgModule , CUSTOM_ELEMENTS_SCHEMA} from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import { RouterModule } from '@angular/router';
import { DxDataGridModule, DxPopupModule, DxButtonModule, DxTemplateModule, DxScrollViewModule, DxSchedulerModule } from 'devextreme-angular';

import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { NavComponent } from './nav/nav.component';
import { LoginComponent } from './login/login.component';
import { PatientListComponent } from './receiptionist/patient-list/patient-list.component';
import { PatientModifyComponent } from './receiptionist/patient-modify/patient-modify.component';
import { appRoutes } from './routes';
import { PatientAddComponent } from './receiptionist/patient-add/patient-add.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PricesComponent } from './receiptionist/prices/prices.component';
import { ReceiptionistComponent } from './receiptionist/receiptionist.component';
import { DoctorComponent } from './doctor/doctor.component';
import { AdministratorComponent } from './administrator/administrator.component';
import { RegisterUserComponent } from './administrator/registerUser/registerUser.component';
import { UserListComponent } from './administrator/user-list/user-list.component';
import { UserCardComponent } from './administrator/user-card/user-card.component';
import { UserModifyComponent } from './administrator/user-modify/user-modify.component';
import { ServiceListComponent } from './doctor/service-list/service-list.component';
import { AppointmentAddComponent } from './receiptionist/appointment-add/appointment-add.component';
import { PatientVisitsComponent } from './receiptionist/patient-visits/patient-visits.component';
import { AppointmentsComponent } from './doctor/appointments/appointments.component';
import { AppointmentInfoComponent } from './doctor/appointment-info/appointment-info.component';

@NgModule({
   declarations: [
      AppComponent,
      UserComponent,
      NavComponent,
      LoginComponent,
      PatientListComponent,
      PatientModifyComponent,
      PatientAddComponent,
      PricesComponent,
      ReceiptionistComponent,
      DoctorComponent,
      AdministratorComponent,
      RegisterUserComponent,
      UserListComponent,
      UserModifyComponent,
      UserCardComponent,
      ServiceListComponent,
      AppointmentAddComponent,
      PatientVisitsComponent ,
      AppointmentsComponent,
      AppointmentInfoComponent 
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      DxDataGridModule,
      RouterModule.forRoot(appRoutes),
      BrowserAnimationsModule,
      DxPopupModule,
      DxButtonModule,
      DxTemplateModule,
      DxScrollViewModule,
      DxSchedulerModule,
   ],
   schemas: [
      CUSTOM_ELEMENTS_SCHEMA
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
