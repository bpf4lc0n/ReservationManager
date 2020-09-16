import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material';
import { ActivatedRoute } from '@angular/router';
import { CustomerTypeViewModel } from 'src/app/models/customertype.model';
import { ContactTypeService } from 'src/app/services/contacttype.service';
import { CustomerViewModel} from '../../models/customer.model';
import { CustomerService } from '../../services/customer.service';

@Component({
  selector: 'app-customer-edit',
  templateUrl: './customer-edit.component.html',
  styleUrls: ['./customer-edit.component.css']
})
export class CustomerEditComponent implements OnInit {  ctTypes : CustomerTypeViewModel[];
  customer : CustomerViewModel;
  reserveCustomerForm : FormGroup ;  
  
  constructor(public fb : FormBuilder, 
    private customerService : CustomerService, 
    private ctService : ContactTypeService,
    private route : ActivatedRoute,
    private _snackBar: MatSnackBar) {     
  }

  ngOnInit() {
    const id = this.route .snapshot.params['id'];

    this.getContactType();
    
    this.reserveCustomerForm = this.fb.group({
      $key : new FormControl(null),
      fc_name : new FormControl('', Validators.required),
      fc_contacttype : new FormControl(''),
      fc_Birthday : new FormControl(new Date(), Validators.required),
      fc_Telephone : new FormControl('', [Validators.required, Validators.minLength(8)]),
      fc_Description : new FormControl('')
    })  

    this.getCustomers(id);
  }

  getCustomers(id : number) {
    this.customerService.getCustomersById(id).subscribe(data => {
      this.customer = data; 
      this.reserveCustomerForm.setValue({
        $key: data.id,
        fc_name : data.name,
        fc_contacttype: data.contactTypeId,
        fc_Birthday: data.dateBirth,
        fc_Telephone: data.telephone,
        fc_Description: data.description
     }); 
      console.log('data', data); console.log('customer', this.customer)});
  }

  getContactType() {
    this.ctService.getCustomerTypes().subscribe(data => {this.ctTypes = data});
  }

  getColAdjusment():number{
    return (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent) )? 1 : 4 ;
   }

   submitForm() {
    this.customerService.EditCustomer(this.customer.id, this.reserveCustomerForm.value)
      .subscribe(
        data => {
          this.openSnackBar('Customer edited');
        },
        error => {
          this.openSnackBar('The edit action failed. ' + error.message);
        }
      );
  }
  
  openSnackBar(message: string) {
    this._snackBar.open(message, 'Ok', {
      duration: 1500,
    });
  }
}