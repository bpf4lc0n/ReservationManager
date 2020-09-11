import { Component, OnInit } from '@angular/core';
import { Customer } from '../../models/customer.model';
import { CustomerService } from '../../services/customer.service';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {
  customers : Customer[];

  constructor(private customerService : CustomerService) {     
  }

  ngOnInit() {
    this.customers = this.customerService.getCustomers()
  }

}
