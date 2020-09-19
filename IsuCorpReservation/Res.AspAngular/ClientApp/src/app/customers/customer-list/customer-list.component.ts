import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
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

  dataSource : MatTableDataSource<CustomerViewModel>; 
  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: false}) sort: MatSort;
  
  constructor(private customerService : CustomerService,
    public dialog: MatDialog) {  
  }

  ngOnInit() {
    this.getCustomers();    
  }

  ngAfterViewInit(){
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  getCustomers() {
    this.customerService.getCustomers().subscribe(data => {
      this.customers = data; 
      this.dataSource = new MatTableDataSource<CustomerViewModel>(this.customers); 
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;});
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
