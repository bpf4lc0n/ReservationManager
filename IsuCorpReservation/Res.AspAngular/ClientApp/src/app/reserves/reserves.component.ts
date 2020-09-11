import { Component, OnInit } from '@angular/core';
import { ReserveService } from '../services/reserve.service';

@Component({
  selector: 'app-reserves',
  templateUrl: './reserves.component.html',
  styleUrls: ['./reserves.component.css'],
  providers: [ReserveService]
})
export class ReservesComponent implements OnInit {
  
  constructor() { }

  ngOnInit() {
    
  }
}
