import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-user-card',
  templateUrl: './user-card.component.html',
  styleUrls: ['./user-card.component.css']
})
export class UserCardComponent implements OnInit {
  popupVisible = false;
  hovering: boolean;

  @Input() user: any;

  @Output()
  uploaded = new EventEmitter<string>();

  constructor(private http: HttpClient) {
    this.hovering = false;
   }

  ngOnInit() {
  }

  refreshData(event) {
    this.uploaded.emit('complete');
  }

  deleteUser() {
    this.http.delete('http://localhost:5000/api/auth/remove/' + this.user.username).subscribe(response => {
      console.log(response);
      this.uploaded.emit('complete');
    }, error => {
      console.log(error);
    });
  }

  showModify() {
    this.popupVisible = true;
  }

}
