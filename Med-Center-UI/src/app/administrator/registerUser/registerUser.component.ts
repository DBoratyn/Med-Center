import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-registerUser',
  templateUrl: './registerUser.component.html',
  styleUrls: ['./registerUser.component.css']
})
export class RegisterUserComponent implements OnInit {

  user: any = {};

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  addUser() {
    this.authService.register(this.user);
  }

}
