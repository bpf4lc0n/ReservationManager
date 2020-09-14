import { Component, Input, OnInit } from '@angular/core';
import { CustomerViewModel } from '../../models/customer.model';
import { CustomerService } from '../../services/customer.service';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {
  customers : CustomerViewModel[];
  columnDefinitions = ['Contact_name', 'Phone_number','Birth_date', 'Contact_type '];

  constructor(private customerService : CustomerService) {     
  }

  ngOnInit() {
    this.getCustomers();
  }

  getCustomers() {
    this.customerService.getCustomers().subscribe(data => {this.customers = data; console.log('data', data); console.log('customers', this.customers)});
  }

}
