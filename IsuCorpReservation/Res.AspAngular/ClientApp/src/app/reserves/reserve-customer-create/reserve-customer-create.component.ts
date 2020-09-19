import { Component, OnInit, Input, ElementRef, ViewChild } from '@angular/core';
import { ReserveViewModel } from '../../models/reserve.model';
import { ReserveService } from '../../services/reserve.service';
import { CustomerViewModel } from 'src/app/models/customer.model';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CustomerTypeViewModel } from 'src/app/models/customertype.model';
import { ContactTypeService } from 'src/app/services/contacttype.service';
import { MatSnackBar } from '@angular/material';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-reserve-customer-create',
  templateUrl: './reserve-customer-create.component.html',
  styleUrls: ['./reserve-customer-create.component.css']
})
export class ReserveCustomerCreateComponent implements OnInit {
  id : number;

  reserve : ReserveViewModel;
  customer : CustomerViewModel;
  customerExistent : CustomerViewModel;
  
  ctTypes : CustomerTypeViewModel[];
  reserveCustomerForm : FormGroup ;

  constructor(public fb : FormBuilder,
    private customerService : CustomerService, 
    private reserveService : ReserveService, 
    private ctService : ContactTypeService,
    private _snackBar: MatSnackBar) { }

  ngOnInit() {   
    this.getContactType();   
    this.reserveCustomerForm = this.fb.group({
      $key : new FormControl(null),
      fc_Restaurant : new FormControl('', Validators.required),
      fc_Date : new FormControl(new Date(), Validators.required),
      fc_CustomerId : new FormControl(null),
      fc_name : new FormControl('', Validators.required),
      fc_contacttype : new FormControl(''),
      fc_Birthday : new FormControl(new Date(), Validators.required),
      fc_Telephone : new FormControl('', [Validators.required, Validators.minLength(8)]),
      fc_Description : new FormControl('')
    })
    this.customer = new CustomerViewModel(this.reserveCustomerForm.value.fc_name, 
      this.reserveCustomerForm.value.fc_Telephone, this.reserveCustomerForm.value.fc_Birthday, 
      this.reserveCustomerForm.value.fc_Description, 1);
  }

  submitForm() {

    var reserve = new ReserveViewModel( this.reserveCustomerForm.value.fc_Date, 
      this.reserveCustomerForm.value.fc_Restaurant,  this.reserveCustomerForm.value.fc_contacttype );
    
    // if is a know customer must be check first
    if (this.customerExistent) {
        // if customer keep tha same (name is the only field to take into consideration in this case)
        if (this.compareValue(this.customerExistent.name, this.customer.name)) {
          // reference to the know customer
          reserve.customerId = this.customerExistent.id;
          // add the reserve
          this.AddReserve(reserve);
        }
        else {
          this.AddCustomerAndReserve(reserve);
        }
      }
      else {
        this.AddCustomerAndReserve(reserve);
      }
  }

  AddReserve(reserve){
    this.reserveService.AddReserveDirect(reserve).subscribe(
      dataRes => {
      this.openSnackBar('Reserve added');
      this.onClear();
    },
    error => {
      this.openSnackBar('The add action failed. ' + error.message);
    })
  }

  AddCustomerAndReserve(reserve : ReserveViewModel) {
      // add a new customer
      this.customer.description = this.reserveCustomerForm.value.fc_Description;
      this.customerService.AddCustomerDirect(this.customer).subscribe(data => {
        this.customerService.getCustomerByName(this.customer.name).subscribe(newCustomer => {
          this.customerExistent = newCustomer[0];
          // if successfully added,them add the reserve
          reserve.customerId = newCustomer[0].id;
          this.AddReserve(reserve);
        })      
    },
      error => {
        this.openSnackBar('The New Client action failed. ' + error.message);
      })
  }

  compareValue(value1: string, value2:string) : boolean {
    var cleanValue1 = value1.trim().toLowerCase();
    var cleanValue2 = value2.trim().toLowerCase();
    return cleanValue1 === cleanValue2;
  }
  
  initializeFormGroup() {
    this.reserveCustomerForm.setValue({
        $key : null,
        fc_Restaurant : "",
        fc_Date : new Date(),
        fc_CustomerId : 0,
        fc_name : "",
        fc_contacttype : 0,
        fc_Birthday :new Date(),
        fc_Telephone : "",
        fc_Description : "Keep your noise down"
    });
}

  onClear(){
     this.reserveCustomerForm.reset();
     this.initializeFormGroup();
  }

  getColAdjusment():number{
   return (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent) )? 1 : 4 ;
  }

  getContactType() {
    this.ctService.getCustomerTypes().subscribe(data => {this.ctTypes = data; 
      console.log('data', data); console.log('contact-type', this.ctTypes)});
  }

  openSnackBar(message: string) {
    this._snackBar.open(message, 'Ok', {
      duration: 1500,
    });
  }

  CustomerKnow(event : Event) {
      var inputName = (<HTMLInputElement>event.target).value;
      if (!this.customerExistent || inputName !== this.customerExistent.name){        
        this.customerService.getCustomerByName(inputName).subscribe(data=> {
          this.customerExistent = data[0];
          if(this.customerExistent) {
            this.customer.telephone = this.customerExistent.telephone;
            this.customer.dateBirth = this.customerExistent.dateBirth;
            }
           });
      }
  }
}
