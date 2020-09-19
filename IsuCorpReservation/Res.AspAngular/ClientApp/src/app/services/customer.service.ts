import { CustomerViewModel } from "../models/customer.model";
import { Observable, Subject } from "rxjs";
import {FormControl, FormGroup, Validators} from '@angular/forms';
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
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
      fc_CustomerId : new FormControl(null),
      fc_name : new FormControl('', Validators.required),
      fc_contacttype : new FormControl(''),
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

  getCustomersByPage(sortOrder = 'asc',
    pageNumber = 0, pageSize = 3):  Observable<CustomerViewModel[]> {

    return this.http.get<CustomerViewModel[]>('/api/Customer/ByPage', {
        params: new HttpParams() 
            .set('sortOrder', sortOrder)
            .set('pageNumber', pageNumber.toString())
            .set('pageSize', pageSize.toString())
    }).pipe();
  }

  getCustomersById(customerId : number) : Observable<CustomerViewModel> {
    return this.http.get<CustomerViewModel>(this.appUrl+'api/Customer/' + customerId);
  }

  getCustomerByName(customerName : string): Observable<CustomerViewModel>{    
    return this.http.get<CustomerViewModel>(this.appUrl+'api/Customer/GetCustomersByName/' + customerName).pipe();
  }

  AddCustomer(customer)  : Observable<CustomerViewModel>
  { 
      var Customer = new CustomerViewModel(customer.fc_name, customer.fc_Telephone, customer.fc_DateBirth, 
        customer.fc_Description, customer.fc_contacttype);
  
      return this.http.post<CustomerViewModel>(this.appUrl +'api/Customer',
          JSON.stringify(Customer), this.httpOptions).pipe()  
  }  

  AddCustomerDirect(customer)  : Observable<CustomerViewModel>
  { 
      return this.http.post<CustomerViewModel>(this.appUrl +'api/Customer',
          JSON.stringify(customer), this.httpOptions).pipe()  
  }  
  
  EditCustomer(id : number, customer)  
  {    
    const customerNew = new CustomerViewModel(customer.fc_name, customer.fc_Telephone, customer.fc_DateBirth, 
      customer.fc_Description, customer.fc_contacttype);
      customerNew.id = id;

    return this.http.put<CustomerViewModel>(this.appUrl+'api/Customer/' + id,
          JSON.stringify(customerNew), this.httpOptions).pipe()       
  } 

  DeleteEmployee(customer)  
  {  
      return this.http.delete<CustomerViewModel>(this.appUrl+'api/Customer/'+ customer.id).pipe();    
  }  
}