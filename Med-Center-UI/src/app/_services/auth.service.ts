import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = 'http://localhost:5000/api/auth/';

  constructor(private http: HttpClient) { }

  login(model: any) {
    return this.http.post(this.baseUrl + 'login', model)
      .pipe(
        map((response: any) => {
          const user = response;
          if (user) {
            localStorage.setItem('token', user.token);
            const jwtData = user.token.split('.')[1];
            const decodedJwtJsonData = window.atob(jwtData);
            const decodedJwtData = JSON.parse(decodedJwtJsonData);
            localStorage.setItem('role', decodedJwtData.role);
          }
        })
      );
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token;
  }

  getRole() {
    return localStorage.getItem('role');
  }
}
