import { Injectable, Inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable, Subject } from 'rxjs';
import { Reserve } from "../models/reserve.model";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { GetReserveOutput } from '../models/getReserveOutput.model.';

@Injectable({
    providedIn : 'root',
})
export class ReserveService{
    getReserveOutput: GetReserveOutput;
    appUrl : string;  
    httpOptions = {
        headers : new HttpHeaders({
            'Content-Type' : 'application-json'
        })
    };

    form : FormGroup = new FormGroup({
        $key : new FormControl(null),
        fc_Restaurant : new FormControl('', Validators.required),
        fc_Date : new FormControl(new Date(), Validators.required)
    })

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.appUrl = baseUrl;  
  }    
    
    getReserves() : Observable<GetReserveOutput> {
        return this.http.get<GetReserveOutput>(this.appUrl+'Reserves');
    }

    create() : Observable<GetReserveOutput>{
        return this.http.post<GetReserveOutput>(this.appUrl + 'Reserves/NewReserve', JSON.stringify() , this.httpOptions).pipe;
    }

    initializeFormGroup() {
        this.form.setValue({
            $key : null,
            fc_Restaurant : "",
            fc_Date : new Date()
        });
    }

    getReserveDefault(){
        return new Reserve(new Date(2020, 9, 17, 10, 0, 0, 0), '-', '-', '(000) 00 000 000', new Date(), '...');
    }
}