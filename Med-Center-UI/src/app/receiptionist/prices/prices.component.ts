import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-prices',
  templateUrl: './prices.component.html',
  styleUrls: ['./prices.component.css']
})
export class PricesComponent implements OnInit {

  listOfPrices: any = {};
  currentFilter: any;

  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.authService.getAllServices().subscribe(response => {
      this.listOfPrices = response;
      console.log(response);
    });
  }

}
