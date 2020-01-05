import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: any = {};

  constructor(public authService: AuthService, private router: Router) {}

  ngOnInit() {}

  login() {
    this.authService.login(this.model).subscribe(
      next => {
        console.log('login success');
        
    
    if(localStorage.getItem("role") === "Receiptionist") {
      this.router.navigateByUrl('/receptionisthome');
    }
    
    if(localStorage.getItem("role") === "Doctor") {
      this.router.navigateByUrl('/appointments');
    }
    
    if(localStorage.getItem("role") === "Administrator") {
      this.router.navigateByUrl('/addUsers');
    }
      },
      error => {
        console.log('error trying to login');
      }
    );
  }
}
