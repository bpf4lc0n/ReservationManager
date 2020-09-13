import { Component, OnInit, Input, ElementRef, ViewChild } from '@angular/core';
import { Reserve } from '../../models/reserve.model';
import { ReserveService } from '../../services/reserve.service';
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
  }

  onAddReserve() {
    
   }

  onClear(){
     this.reserveService.form.reset();
     this.reserveService.initializeFormGroup();
  }

  getColAdjusment():number{
   return (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent) )? 1 : 4 ;
  }
}
