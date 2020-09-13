import { Component, OnInit, ViewChild, ElementRef, Input } from '@angular/core';
import { Reserve } from '../../models/reserve.model';
import { ReserveService } from '../../services/reserve.service';
import { ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'app-reserve-edit',
  templateUrl: './reserve-edit.component.html',
  styleUrls: ['./reserve-edit.component.css']
})
export class ReserveEditComponent implements OnInit {
  reserve : Reserve;
  id: number;

  constructor(private reserveService : ReserveService,
              private route: ActivatedRoute) {     
  }

  ngOnInit() {  
    /*   
    this.route.params.subscribe(
      (param : Params) =>{
        this.id = +param['id'];
        this.reserve = this.reserveService.getReserve(this.id);
      }
    );  
    */
  }
}
