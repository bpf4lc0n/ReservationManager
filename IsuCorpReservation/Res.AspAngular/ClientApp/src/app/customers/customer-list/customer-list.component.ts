import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatPaginator, MatSort } from '@angular/material';
import { CustomerViewModel } from '../../models/customer.model';
import { CustomerService } from '../../services/customer.service';
import { CustomerDeleteDialog } from '../customer-delete-dialog/customer-delete-dialog.component';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {
  customers : CustomerViewModel[];
  columnDefinitions = ['Contact_name', 'Phone_number','Birth_date', 'Contact_type', 'Edit', 'Delete'];

  resultsLength = 0;
  isLoadingResults = true;
  isRateLimitReached = false;

  //@ViewChild(MatPaginator) paginator: MatPaginator;
  //@ViewChild(MatSort) sort: MatSort;
  
  constructor(private customerService : CustomerService,
    public dialog: MatDialog) {     
  }

  ngOnInit() {
    this.getCustomers();
  }

  ngAfterViewInit(){
    //this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);    
  }

  getCustomers() {
    this.customerService.getCustomers().subscribe(data => {this.customers = data; console.log('data', data); console.log('customers', this.customers)});
  }

  openDialog(customer : CustomerViewModel){
    console.log('Customer to delete', customer);

    const dialogRef = this.dialog.open(CustomerDeleteDialog, {
      width: '250px',
      data: customer
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed', result);
      if(result > 0)
        this.deleteCustomers(customer);
    });    
  }
  
  deleteCustomers(customer : CustomerViewModel) {
    this.customerService.DeleteEmployee(customer).subscribe();
  }
}
