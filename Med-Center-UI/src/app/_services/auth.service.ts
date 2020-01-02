import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: "root"
})
export class AuthService {
  baseUrl = "http://localhost:5000/api/auth/";

  constructor(private http: HttpClient) {}

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

  getUsers(): Observable<any> {
    return this.http.get("http://localhost:5000/api/users/");
  }

  getAllServices(): Observable<any> {
    return this.http.get("http://localhost:5000/api/auth/GetDoctorServices/");
  }

  getDoctorServices(doctorName: string): Observable<any> {
    return this.http.get("http://localhost:5000/api/auth/GetDoctorServices/" + doctorName + '/');
  }

  deleteDoctorService(id: number) {
    return this.http.post("http://localhost:5000/api/auth/DeleteDoctorService/" + id + "/", id);
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
