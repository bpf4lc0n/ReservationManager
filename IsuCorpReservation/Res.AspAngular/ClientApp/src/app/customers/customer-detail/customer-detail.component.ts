import { Component, OnInit, Input } from '@angular/core';
import { ContactType } from 'src/app/models/contacttype.model';
import { ContactTypeService } from 'src/app/services/contacttype.service';
import { Customer} from '../../models/customer.model';
import { CustomerService } from '../../services/customer.service';

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrls: ['./customer-detail.component.css']
})
export class CustomerDetailComponent implements OnInit {
 @Input() customer : Customer;
 ctTypes : ContactType[];

  constructor(private customerService : CustomerService,  private ctTypeService : ContactTypeService) { }

  ngOnInit() {
     this.ctTypes = this.ctTypeService.getContactType();
     this.customerService.customerSelected.next(this.customer);
     if(!this.customer) {
        this.customer = this.customerService.getCustomerDefault();
    }

    /*
  onCustomerNameValidated(){    
    // check if customer exists
    this.customer = this.customerService.getCustomerByName(this.reserve.Customer.Name);
    // if not exist create  a new one
    if(this.customer) {
      this.reserve.Customer 
    }
    else{ 
      this.customerService.getCustomerDefault();
      this.customerService.addCustomer(this.customer);  
    }  
   }*/
  }


  getColAdjusment():number{
    return (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent) )? 1 : 4 ;
   }
}
