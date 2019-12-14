import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  role: any;

  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.role = this.authService.getRole();
  }

  logout() {
    localStorage.removeItem('token');
    console.log('Logged out');
  }

}
