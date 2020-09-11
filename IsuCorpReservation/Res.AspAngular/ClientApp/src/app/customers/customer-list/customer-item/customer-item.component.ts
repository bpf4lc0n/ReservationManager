import { Component, OnInit, Input } from '@angular/core';
import { Customer } from '../../../models/customer.model';
import { CustomerService } from '../../../services/customer.service';


@Component({
  selector: 'app-customer-item',
  templateUrl: './customer-item.component.html',
  styleUrls: ['./customer-item.component.css']
})
export class CustomerItemComponent implements OnInit { 
  @Input() customer : Customer;

  constructor(private customerService: CustomerService) { }

  ngOnInit() {
  }

  onSelected(){
      this.customerService.customerSelected.next(this.customer);
  }
}