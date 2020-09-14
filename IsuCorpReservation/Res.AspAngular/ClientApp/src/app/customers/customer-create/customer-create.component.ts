import { Component, OnInit } from '@angular/core';
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

  constructor(private customerService : CustomerService, private ctService : ContactTypeService) {     
  }

  ngOnInit() {
    this.getContactType();
    this.customerService.initializeFormGroup();    
  }

  getContactType() {
    this.ctService.getCustomerTypes().subscribe(data => {this.ctTypes = data; 
      console.log('data', data); console.log('contact-type', this.ctTypes)});
  }

  getColAdjusment():number{
    return (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent) )? 1 : 4 ;
   }
}
