import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CustomerViewModel } from 'src/app/models/customer.model';
import { CustomerTypeViewModel } from 'src/app/models/customertype.model';
import { ContactTypeService } from 'src/app/services/contacttype.service';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-customer-create',
  templateUrl: './customer-create.component.html',
  styleUrls: ['./customer-create.component.css']
})
export class CustomerCreateComponent implements OnInit {
  ctTypes : CustomerTypeViewModel[];
  customer : CustomerViewModel;
  reserveCustomerForm : FormGroup ;  
  
  constructor(public fb : FormBuilder, 
    private customerService : CustomerService, 
    private ctService : ContactTypeService) {     
  }

  ngOnInit() {

    this.getContactType();
    
    this.reserveCustomerForm = this.fb.group({
      $key : new FormControl(null),
      fc_CustomerId : new FormControl(null),
      fc_name : new FormControl('', Validators.required),
      fc_contacttype : new FormControl(''),
      fc_Birthday : new FormControl(new Date(), Validators.required),
      fc_Telephone : new FormControl('', [Validators.required, Validators.minLength(8)]),
      fc_Description : new FormControl('')
    })  
  }

  getContactType() {
    this.ctService.getCustomerTypes().subscribe(data => {this.ctTypes = data; 
      console.log('data', data); console.log('contact-type', this.ctTypes)});
  }

  getColAdjusment():number{
    return (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent) )? 1 : 4 ;
   }
}
