import { Customer } from "../models/customer.model";
import { Subject } from "rxjs";
import {FormControl, FormGroup} from '@angular/forms';

export class CustomerService{
    customerChanged = new Subject<Customer[]>();
    customerSelected = new Subject<Customer>();

    private customers : Customer[] = [
        new Customer('Joan', '(000) 00 000 000', new Date(), '...'),
        new Customer('Renaldo', '(000) 11 111 111', new Date(), 'Toda la vida comiendo pan')
      ]

    form : FormGroup = new FormGroup({
        $key : new FormControl(null),
        fc_name : new FormControl(''),
        fc_contacttype : new FormControl(''),
        fc_Birthday : new FormControl(new Date()),
        fc_Telephone : new FormControl(''),
        fc_Description : new FormControl('')
    })

      getCustomers() {
          return this.customers.slice();
      }

      getCustomerDefault() {
        return new Customer('Default', 'Default', new Date(), '...');
    }

      addCustomer(customer : Customer){
          this.customers.push(customer);
          this.customerChanged.next(this.getCustomers());
      }

     getCustomerByName(name : string){
        return this.getCustomerDefault();
      }
}