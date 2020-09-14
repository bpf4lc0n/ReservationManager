import { CustomerViewModel } from "../models/customer.model";
import { Observable, Subject } from "rxjs";
import {FormControl, FormGroup, Validators} from '@angular/forms';
import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";

@Injectable({
  providedIn : 'root',
})
export class CustomerService{
     appUrl : string;
      
     constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.appUrl = baseUrl;  
      }   

    form : FormGroup = new FormGroup({
        $key : new FormControl(null),
        fc_name : new FormControl('', Validators.required),
        fc_contacttype : new FormControl('', Validators.required),
        fc_Birthday : new FormControl(new Date(), Validators.required),
        fc_Telephone : new FormControl('', [Validators.required, Validators.minLength(8)]),
        fc_Description : new FormControl('')
    })

    initializeFormGroup() {
      this.form.setValue({
          $key : null,
          fc_name : "",
          fc_contacttype : 0,
          fc_Birthday : new Date(),
          fc_Telephone : "",
          fc_Description : ""
      });
  }

    getCustomers() : Observable<CustomerViewModel[]> {
      return this.http.get<CustomerViewModel[]>(this.appUrl+'api/Customer');
  }

      getCustomerDefault() {
        return new CustomerViewModel('Default', 'Default', new Date(), '...');
    }

      addCustomer(customer : CustomerViewModel){
          
      }

     getCustomerByName(name : string){
        return this.getCustomerDefault();
      }
}