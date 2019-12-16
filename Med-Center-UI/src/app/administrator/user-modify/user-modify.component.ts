import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-user-modify',
  templateUrl: './user-modify.component.html',
  styleUrls: ['./user-modify.component.css']
})
export class UserModifyComponent implements OnInit {

  @Input() selector: any;
  @Input() user: any;

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  modifyUser() {
    console.log(this.user);
    this.user.username = this.selector;
    if ((this.user.profession === null || this.user.profession === undefined) && this.user.profession !== 'Doctor') {
      this.user.Profession = '';
    }
    this.authService.updateUser(this.user);
  }

}
