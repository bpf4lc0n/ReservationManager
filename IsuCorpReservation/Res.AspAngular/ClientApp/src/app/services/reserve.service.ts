import { Injectable, Inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ReserveViewModel } from "../models/reserve.model";
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { Router } from '@angular/router';

@Injectable({
    providedIn : 'root',
})
export class ReserveService{
    reserveViewModel: Observable<ReserveViewModel[]>;
    newReserve:Observable<ReserveViewModel>;
    
    appUrl : string;  
    httpOptions = {
        headers : new HttpHeaders({
            'Content-Type' : 'application/json'
        })
    };

    reserveCustomerForm : FormGroup = new FormGroup({
        $key : new FormControl(null),
        fc_Restaurant : new FormControl('', Validators.required),
        fc_Date : new FormControl(new Date(), Validators.required),
        fc_CustomerId : new FormControl(null),
        fc_name : new FormControl('', Validators.required),
        fc_contacttype : new FormControl('', Validators.required),
        fc_Birthday : new FormControl(new Date(), Validators.required),
        fc_Telephone : new FormControl('', [Validators.required, Validators.minLength(8)]),
        fc_Description : new FormControl('')
    })
    

  constructor(private http: HttpClient, 
    @Inject('BASE_URL') baseUrl:
     string, 
     private router : Router) {
    this.appUrl = baseUrl;  
  }    
    
    getReserves() : Observable<ReserveViewModel[]> {
        return this.http.get<ReserveViewModel[]>(this.appUrl+'api/Reserves').pipe();
    }

    getReserveById(id : number) : Observable<ReserveViewModel> {
        return this.http.get<ReserveViewModel>(this.appUrl+'api/Reserves/'+id);
    }

    AddReserve(res)  : Observable<ReserveViewModel>
    { 
        var reserve = new ReserveViewModel( res.fc_Date, res.fc_Restaurant, 1 );
    
        return this.http.post<ReserveViewModel>(this.appUrl +'api/Reserves',
            JSON.stringify(reserve), this.httpOptions).pipe()  
    }  
  
    EditReserve(id : number, res : ReserveViewModel)  
    {          
        return this.http.put<ReserveViewModel>(this.appUrl+'api/Reserves/' + id,
            JSON.stringify(res), this.httpOptions).pipe()       
    } 

    DeleteEmployee(res : ReserveViewModel)  
    {  
        return this.http.delete<ReserveViewModel>(this.appUrl+'api/Reserves/' + res.id);    
    } 
}