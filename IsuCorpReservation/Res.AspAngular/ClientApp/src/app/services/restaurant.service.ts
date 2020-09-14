import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { RestaurantViewModel } from "../models/restaurant.model";

@Injectable({
    providedIn : 'root',
})
export class RestaurantService{
    appUrl : string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.appUrl = baseUrl;  
    }    
        
    getCustomerTypes() : Observable<RestaurantViewModel[]> {
        return this.http.get<RestaurantViewModel[]>(this.appUrl+'api/Restaurant');
    }
}