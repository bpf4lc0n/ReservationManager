import { Component, OnInit, Input, ElementRef, ViewChild } from '@angular/core';
import { Reserve } from '../../models/reserve.model';
import { ReserveService } from '../../services/reserve.service';
import { Customer } from 'src/app/models/customer.model';
import { ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'app-reserve-customer-create',
  templateUrl: './reserve-customer-create.component.html',
  styleUrls: ['./reserve-customer-create.component.css']
})
export class ReserveCustomerCreateComponent implements OnInit {
  id : number;
  editMode = false;
  reserve : Reserve;

  constructor(
    private reserveService : ReserveService,         
    private route : ActivatedRoute) { }

  ngOnInit() {
    

    this.route.params.subscribe(
      (param : Params) =>{
        this.id = +param['id'];
        this.editMode = param['id'] != null;
        this.reserve = this.reserveService.getReserve(this.id);
      }
    );  
    
    if(!this.reserve) {
      this.reserve = this.reserveService.getReserveDefault();
    }    
  }

  onAddReserve() {
    this.reserveService.addReserve(this.reserve);
    this.reserve = this.reserveService.getReserveDefault();
}

getColAdjusment():number{
  return (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent) )? 1 : 4 ;
 }
}
