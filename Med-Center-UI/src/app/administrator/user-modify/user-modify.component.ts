import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-user-modify',
  templateUrl: './user-modify.component.html',
  styleUrls: ['./user-modify.component.css']
})
export class UserModifyComponent implements OnInit {

  @Input() selector: any;
  @Input() user: any;
  
  @Output()
  uploaded = new EventEmitter<string>();

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  modifyUser() {
    this.user.username = this.selector;
    this.authService.updateUser(this.user);
    this.uploaded.emit('complete');
  }

}
