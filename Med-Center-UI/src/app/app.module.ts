import { BrowserModule } from '@angular/platform-browser';
import { NgModule , CUSTOM_ELEMENTS_SCHEMA} from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import { RouterModule } from '@angular/router';
import { DxDataGridModule } from 'devextreme-angular';

import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { NavComponent } from './nav/nav.component';
import { LoginComponent } from './login/login.component';
import { PatientListComponent } from './patient-list/patient-list.component';
import { PatientModifyComponent } from './patient-modify/patient-modify.component';
import { appRoutes } from './routes';
import { PatientAddComponent } from './patient-add/patient-add.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
   declarations: [
      AppComponent,
      UserComponent,
      NavComponent,
      LoginComponent,
      PatientListComponent,
      PatientModifyComponent,
      PatientAddComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      DxDataGridModule,
      RouterModule.forRoot(appRoutes),
      BrowserAnimationsModule
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
