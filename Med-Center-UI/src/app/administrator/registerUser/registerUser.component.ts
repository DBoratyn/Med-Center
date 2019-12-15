import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registerUser',
  templateUrl: './registerUser.component.html',
  styleUrls: ['./registerUser.component.css']
})
export class RegisterUserComponent implements OnInit {

  user: any = {};

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
  }

  addUser() {
    if (this.user.role !== 'Doctor') {
      this.user.profession = null;
    }
    this.authService.register(this.user);
    this.router.navigateByUrl('/userslist');
  }

}
