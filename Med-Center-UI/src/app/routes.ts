import {Routes} from '@angular/router';
import { PatientListComponent } from './patient-list/patient-list.component';
import { PatientAddComponent } from './patient-add/patient-add.component';

export const appRoutes: Routes = [
    {path: 'receptionisthome', component: PatientListComponent},
    {path: 'receptionistAdd', component: PatientAddComponent}
]