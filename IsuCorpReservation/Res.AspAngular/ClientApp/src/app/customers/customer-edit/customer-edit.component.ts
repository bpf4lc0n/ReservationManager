import { Component, OnInit, Input } from '@angular/core';
import { CustomerTypeViewModel } from 'src/app/models/customertype.model';
import { ContactTypeService } from 'src/app/services/contacttype.service';
import { CustomerViewModel} from '../../models/customer.model';
import { CustomerService } from '../../services/customer.service';

@Component({
  selector: 'app-customer-edit',
  templateUrl: './customer-edit.component.html',
  styleUrls: ['./customer-edit.component.css']
})
export class CustomerEditComponent implements OnInit {
  @Input() customer : CustomerViewModel;
  ctTypes : CustomerTypeViewModel[];

  constructor(private customerService : CustomerService, 
     private ctTypeService : ContactTypeService) { }

  ngOnInit() {
     this.getContactTypes();
    }

  getContactTypes() {
      this.ctTypeService.getCustomerTypes().subscribe(data => {this.ctTypes = data; console.log('data', data); console.log('customers_type', this.ctTypes)});
    }

  getColAdjusment():number{
    return (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent) )? 1 : 4 ;
   }
}
