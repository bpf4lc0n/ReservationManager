import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { CustomerTypeViewModel } from 'src/app/models/customertype.model';
import { ContactTypeService } from 'src/app/services/contacttype.service';
import { CustomerViewModel } from '../../models/customer.model';
import { CustomerService } from '../../services/customer.service';
import { CustomerDeleteDialog } from '../customer-delete-dialog/customer-delete-dialog.component';
import { DeviceDetectorService } from 'ngx-device-detector';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {
  customers : CustomerViewModel[];
  ctTypes : CustomerTypeViewModel[];
  columnDefinitions = [
    { def: 'Contact_name', showMobile: true },
    { def: 'Phone_number', showMobile: false },
    { def: 'Birth_date', showMobile: false },
    { def: 'Contact_type', showMobile: false },
    { def: 'Edit', showMobile: true },
    { def: 'Delete', showMobile: true }
    ];  

  dataSource : MatTableDataSource<CustomerViewModel>; 
  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: false}) sort: MatSort;
  
  constructor(private customerService : CustomerService,
    private ctService : ContactTypeService,
    public dialog: MatDialog,
    private deviceService: DeviceDetectorService) {  
  }

  ngOnInit() {
    this.getContactType();
    this.getCustomers();    
  }
  
  getContactType() {
    this.ctService.getCustomerTypes().subscribe(data => this.ctTypes = data);
  }

  getCustomers() {
    this.customerService.getCustomers().subscribe(data => {
      this.customers = data; 
      this.dataSource = new MatTableDataSource<CustomerViewModel>(this.customers); 
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;});
  }

  openDialog(customer : CustomerViewModel){ 
    const dialogRef = this.dialog.open(CustomerDeleteDialog, {
      width: '250px',
      data: customer
    });

    dialogRef.afterClosed().subscribe(result => {      
      if(result > 0)
        this.deleteCustomers(customer);
    });    
  }
  
  deleteCustomers(customer : CustomerViewModel) {
    this.customerService.DeleteEmployee(customer).subscribe(data => this.getCustomers());
  }

  getIsMobile() : boolean {
    return this.deviceService.isMobile()
  }

  getDisplayedColumns(): string[] {
    const isMobile = this.getIsMobile();
    return this.columnDefinitions
    .filter(cd => !isMobile || cd.showMobile)
    .map(cd => cd.def);
    }
}
