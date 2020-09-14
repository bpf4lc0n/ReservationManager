import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { CustomerTypeViewModel } from "../models/customertype.model";

@Injectable({
    providedIn : 'root',
})
export class ContactTypeService{
    appUrl : string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.appUrl = baseUrl;  
    }    
        
    getCustomerTypes() : Observable<CustomerTypeViewModel[]> {
        return this.http.get<CustomerTypeViewModel[]>(this.appUrl+'api/CustomerType');
    }
}