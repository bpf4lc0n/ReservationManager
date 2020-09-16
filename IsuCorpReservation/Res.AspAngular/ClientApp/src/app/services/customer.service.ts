import { CustomerViewModel } from "../models/customer.model";
import { Observable, Subject } from "rxjs";
import {FormControl, FormGroup, Validators} from '@angular/forms';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";

@Injectable({
  providedIn : 'root',
})
export class CustomerService{
     appUrl : string;
     httpOptions = {
      headers : new HttpHeaders({
          'Content-Type' : 'application/json'
      })
  };
      
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

  getCustomersById(id : number) : Observable<CustomerViewModel> {
    return this.http.get<CustomerViewModel>(this.appUrl+'api/Customer/'+id);
  }

  getCustomerByName(name : string): Observable<CustomerViewModel>{
    let headers = new Headers();
    headers.append('Content-Type', 'application/json');
    headers.append('name', name);

    return this.http.get<CustomerViewModel>(this.appUrl+'api/GetCustomersByName').pipe()  
  }

  AddCustomer(customer)  : Observable<CustomerViewModel>
  { 
      var Customer = new CustomerViewModel(customer.fc_name, customer.fc_Telephone, customer.fc_DateBirth, customer.fc_Description, customer.fc_contacttype);
  
      return this.http.post<CustomerViewModel>(this.appUrl +'api/Customer',
          JSON.stringify(Customer), this.httpOptions).pipe()  
  }  

  EditCustomer(id : number, customer)  
  {    
    const cust = new CustomerViewModel(customer.fc_name, customer.fc_Telephone, customer.fc_DateBirth, customer.fc_Description, customer.fc_contacttype);
    cust.id = id;

    return this.http.put<CustomerViewModel>(this.appUrl+'api/Customer/' + id,
          JSON.stringify(cust), this.httpOptions).pipe()       
  } 

  DeleteEmployee(customer)  
  {  
      return this.http.delete<CustomerViewModel>(this.appUrl+'api/Customer/'+ customer.id).pipe();    
  }  
}