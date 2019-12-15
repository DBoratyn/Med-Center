import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

  constructor(private authService: AuthService) { }

  listOfUsers: any;


  ngOnInit() {
    this.authService.getUsers().subscribe(response => {
      console.log(response);
      this.listOfUsers = response;
    });
  }

  refreshData(event) {
    this.authService.getUsers().subscribe(response => {
      console.log(response);
      this.listOfUsers = response;
    });
  }

}
