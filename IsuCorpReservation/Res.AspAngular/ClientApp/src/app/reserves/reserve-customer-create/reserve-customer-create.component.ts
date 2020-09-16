import { Component, OnInit, Input, ElementRef, ViewChild } from '@angular/core';
import { ReserveViewModel } from '../../models/reserve.model';
import { ReserveService } from '../../services/reserve.service';
import { CustomerViewModel } from 'src/app/models/customer.model';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CustomerTypeViewModel } from 'src/app/models/customertype.model';
import { ContactTypeService } from 'src/app/services/contacttype.service';

@Component({
  selector: 'app-reserve-customer-create',
  templateUrl: './reserve-customer-create.component.html',
  styleUrls: ['./reserve-customer-create.component.css']
})
export class ReserveCustomerCreateComponent implements OnInit {
  id : number;
  reserve : ReserveViewModel;
  customer : CustomerViewModel;
  ctTypes : CustomerTypeViewModel[];
  reserveCustomerForm : FormGroup ;

  constructor(public fb : FormBuilder,
    private reserveService : ReserveService, private ctService : ContactTypeService) { }

  ngOnInit() {   
    this.getContactType();
    
    this.reserveCustomerForm = this.fb.group({
      $key : new FormControl(null),
      fc_Restaurant : new FormControl('', Validators.required),
      fc_Date : new FormControl(new Date(), Validators.required),
      fc_CustomerId : new FormControl(null),
      fc_name : new FormControl('', Validators.required),
      fc_contacttype : new FormControl(''),
      fc_Birthday : new FormControl(new Date(), Validators.required),
      fc_Telephone : new FormControl('', [Validators.required, Validators.minLength(8)]),
      fc_Description : new FormControl('')
    })
  }

  submitForm() {
    this.reserveService.AddReserve(this.reserveCustomerForm.value) 
        .subscribe(arg => {console.log('Reserve is created successfully')});
  }
  
  initializeFormGroup() {
    this.reserveCustomerForm.setValue({
        $key : null,
        fc_Restaurant : "",
        fc_Date : new Date(),
        fc_CustomerId : 0,
        fc_name : "",
        fc_contacttype : 0,
        fc_Birthday :new Date(),
        fc_Telephone : "",
        fc_Description : "Keep your noise down"
    });
}

  onClear(){
     this.reserveCustomerForm.reset();
     this.initializeFormGroup();
  }

  getColAdjusment():number{
   return (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent) )? 1 : 4 ;
  }

  getContactType() {
    this.ctService.getCustomerTypes().subscribe(data => {this.ctTypes = data; 
      console.log('data', data); console.log('contact-type', this.ctTypes)});
  }
}
