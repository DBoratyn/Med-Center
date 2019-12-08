import { Component } from '@angular/core';
import { AuthService } from '../app/_services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Medical Center';

  constructor(private authService: AuthService) { }

  isLoggedin() {
    return this.authService.loggedIn();
  }
}
