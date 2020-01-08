import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: "root"
})
export class AuthService {
  baseUrl = "http://localhost:5000/api/auth/";

  constructor(private http: HttpClient, private router: Router) {}

  register(user: any) {
    this.http.post(this.baseUrl + "register", user).subscribe(
      response => {
        console.log(response);
      },
      error => {
        console.log(error);
      }
    );
  }

  addService(service: any) {
    this.http.post(this.baseUrl + "AddDoctorService", service).subscribe(
      response => {
        console.log(response);
      },
      error => {
        console.log(error);
      }
    )
  }

  updatePatient(patient: any) {
    this.http.post(this.baseUrl + "updatePatient", patient).subscribe(
      response => {
        console.log(response);
      },
      error => {
        console.log(error);
      }
    )
  }

  updateService(service: any) {
    this.http.post(this.baseUrl + "updateDoctorService", service).subscribe(
      response => {
        console.log(response);
      },
      error => {
        console.log(error);
      }
    )
  }

  updateUser(user: any) {
    this.http.post(this.baseUrl + "updateUser", user).subscribe(
      response => {
        console.log(response);
      },
      error => {
        console.log(error);
      }
    );
  }

  deleteAppointment(id) {
    return this.http.post("http://localhost:5000/api/auth/DeleteAppointment/" + id + "/", id);
  }

  deleteVisit(id)
  {
    return this.http.post("http://localhost:5000/api/auth/DeleteVisit/" + id + "/", id);
  }

  updateAppointment(appointment) {
    return this.http.post(this.baseUrl + "updateAppointment", appointment).subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    });
  }

  updateSickness(sickness) {
    return this.http.post(this.baseUrl + "updateSickness", sickness).subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    });
  }
  
  updateVisit(visit) {
    return this.http.post(this.baseUrl + "updateVisit", visit).subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    });
  }

  
  addMedicine(medicine, id) {
    return this.http.post(this.baseUrl + "AddMedicine/" + id, medicine).subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    })
  }

  addSickness(sickness, id) {
    return this.http.post(this.baseUrl + "AddSickness/" + id, sickness).subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    })
  }

  addAppointment(appointment) {
    return this.http.post(this.baseUrl + "AddAppointment", appointment).subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    });
  }

  AddVisitInfo(visit, id) {
    return this.http.post(this.baseUrl + "AddVisitInfo/" + id, visit).subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    })
  }

  getAllAppointments() {
    return this.http.get(this.baseUrl + "GetAllAppointments" );
  }

  getAllAppointmentsByPesel(Pesel) {
    return this.http.get(this.baseUrl + "GetAllAppointmentsByPesel/" + Pesel );

  }

  getApiData(){

    return this.http.get("https://datadiscovery.nlm.nih.gov/resource/crzr-uvwg.json");
  }

  payAppointment(id) {
    return this.http.post(this.baseUrl + "PayAppointment/" + id, id);
  }

  getUsers(): Observable<any> {
    return this.http.get("http://localhost:5000/api/users/");
  }

  getAllServices(): Observable<any> {
    return this.http.get("http://localhost:5000/api/auth/GetAllDoctorServices/");
  }

  getAllSickness(AppointmentId): Observable<any> {
    return this.http.get("http://localhost:5000/api/auth/getAppointmentSickness/" + AppointmentId + '/');
  }

  getAllMedicine(AppointmentId) {
    return this.http.get("http://localhost:5000/api/auth/getAppointmentMedicine/" + AppointmentId + '/');
  }

  getAppointmentVisit(AppointmentId): Observable<any> {
    return this.http.get("http://localhost:5000/api/auth/getAppointmentVisit/" + AppointmentId + '/');
  }

  getDoctorServices(doctorName: string): Observable<any> {
    return this.http.get("http://localhost:5000/api/auth/GetDoctorServices/" + doctorName + '/');
  }

  GetDoctorAppointments(doctorName: string): Observable<any> {
    return this.http.get("http://localhost:5000/api/auth/GetDoctorAppointments/" + doctorName + '/');
  }

  deleteDoctorService(id: number) {
    return this.http.post("http://localhost:5000/api/auth/DeleteDoctorService/" + id + "/", id);
  }

  deletePatient(id: number) {
    return this.http.post("http://localhost:5000/api/auth/DeletePatient/" + id + "/", id);
  }

  DeleteSickness(id: number) {
    return this.http.post("http://localhost:5000/api/auth/DeleteSickness/" + id + "/", id);
  }

  DeleteMedicine(id: number) {
    return this.http.post("http://localhost:5000/api/auth/DeleteMedicine/" + id + "/", id);
  }

  login(model: any) {
    return this.http.post(this.baseUrl + "login", model).pipe(
      map((response: any) => {
        const user = response;
        if (user) {
          localStorage.setItem("token", user.token);
          const jwtData = user.token.split(".")[1];
          const decodedJwtJsonData = window.atob(jwtData);
          const decodedJwtData = JSON.parse(decodedJwtJsonData);
          localStorage.setItem("role", decodedJwtData.role);
          localStorage.setItem("name", decodedJwtData.unique_name);
        }
      })
    );
  }

  loggedIn() {
    const token = localStorage.getItem("token");
    return !!token;
  }

  getRole() {
    return localStorage.getItem("role");
  }

  getName() {
    return localStorage.getItem("name");
  }
}
