import {Routes} from '@angular/router';
import { PatientListComponent } from './receiptionist/patient-list/patient-list.component';
import { PatientAddComponent } from './receiptionist/patient-add/patient-add.component';
import { PricesComponent } from './receiptionist/prices/prices.component';
import { RegisterUserComponent } from './administrator/registerUser/registerUser.component';
import { UserListComponent } from './administrator/user-list/user-list.component';

export const appRoutes: Routes = [
    {path: 'receptionisthome', component: PatientListComponent},
    {path: 'receptionistAdd', component: PatientAddComponent},
    {path: 'prices', component: PricesComponent},
    {path: 'addUsers', component: RegisterUserComponent},
    {path: 'userslist', component: UserListComponent}
]