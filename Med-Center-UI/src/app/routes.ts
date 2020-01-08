import {Routes} from '@angular/router';
import { PatientListComponent } from './receiptionist/patient-list/patient-list.component';
import { PatientAddComponent } from './receiptionist/patient-add/patient-add.component';
import { PricesComponent } from './receiptionist/prices/prices.component';
import { RegisterUserComponent } from './administrator/registerUser/registerUser.component';
import { UserListComponent } from './administrator/user-list/user-list.component';
import { ServiceListComponent } from './doctor/service-list/service-list.component';
import { AppointmentAddComponent } from './receiptionist/appointment-add/appointment-add.component';
import { PatientVisitsComponent } from './receiptionist/patient-visits/patient-visits.component';
import { AppointmentsComponent } from './doctor/appointments/appointments.component';
import { LoginComponent } from './login/login.component';
import { AppointmentInfoComponent } from './doctor/appointment-info/appointment-info.component';
import { PharmacyComponent } from './doctor/pharmacy/pharmacy.component';
import { DashboardComponent } from './administrator/dashboard/dashboard.component';

export const appRoutes: Routes = [
    {path: 'receptionisthome', component: PatientListComponent},
    {path: 'receptionistAdd', component: PatientAddComponent},
    {path: 'prices', component: PricesComponent},
    {path: 'addUsers', component: RegisterUserComponent},
    {path: 'servicelist', component: ServiceListComponent},
    {path: 'userslist', component: UserListComponent},
    {path: 'appointmentadd', component: AppointmentAddComponent},
    {path: 'listofvisits', component: PatientVisitsComponent},
    {path: 'appointments', component: AppointmentsComponent},
    {path: 'appointmentInfo', component: AppointmentInfoComponent},
    {path: 'login', component: LoginComponent},
    {path: 'pharmacy', component: PharmacyComponent},
    {path: 'dashboard', component: DashboardComponent}
]