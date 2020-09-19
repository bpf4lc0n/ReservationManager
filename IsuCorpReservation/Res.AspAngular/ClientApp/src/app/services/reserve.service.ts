import { Injectable, Inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ReserveViewModel } from "../models/reserve.model";
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { Router } from '@angular/router';
import { throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

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
    
    // standard get
    getReserves() : Observable<ReserveViewModel[]> {
        return this.http.get<ReserveViewModel[]>(this.appUrl+'api/Reserves').pipe();
    }

    // server base pagination with sorting include
    getReservesPage(sortField : string, sortOrder : string, pageIndex : number, pageSize : number) : Observable<ReserveViewModel[]> {
        let params = new HttpParams();
        // string field, string sortDirection, int pageIndex, int pageSize
        params = params.append('field', sortField);
        params = params.append('sortDirection', sortOrder);
        params = params.append('pageIndex', String(pageIndex));
        params = params.append('pageSize', String(pageSize));
        
        return this.http.get<ReserveViewModel[]>(this.appUrl+'api/Reserves/ByPage', {params}).pipe(
            map((reserves : ReserveViewModel[]) => reserves),
            catchError(err=>throwError(err))
        );
    }

    getReservesCount() : Observable<number> {
        return this.http.get<number>(this.appUrl+'api/Reserves/GetReservesCount').pipe();
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

    AddReserveDirect(res)  : Observable<ReserveViewModel>
    { 
        return this.http.post<ReserveViewModel>(this.appUrl +'api/Reserves',
            JSON.stringify(res), this.httpOptions).pipe()  
    } 
  
    EditReserve(id : number, res : ReserveViewModel)  
    {          
        return this.http.put<ReserveViewModel>(this.appUrl+'api/Reserves/' + id,
            JSON.stringify(res), this.httpOptions).pipe()       
    } 
}