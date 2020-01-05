import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  role: any;

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
    this.role = this.authService.getRole();
  }

  logout() {
    this.router.navigateByUrl('/login');
    localStorage.removeItem('token');
    localStorage.removeItem('name');
    localStorage.removeItem('role');
    console.log('Logged out');
  }

}
