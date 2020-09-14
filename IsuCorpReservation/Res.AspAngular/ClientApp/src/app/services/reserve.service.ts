import { Injectable, Inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable, Subject } from 'rxjs';
import { ReserveViewModel } from "../models/reserve.model";
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
    providedIn : 'root',
})
export class ReserveService{
    reserveViewModel: ReserveViewModel[];
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
    
    getReserves() : Observable<ReserveViewModel[]> {
        return this.http.get<ReserveViewModel[]>(this.appUrl+'api/Reserves');
    }

    initializeFormGroup() {
        this.form.setValue({
            $key : null,
            fc_Restaurant : "",
            fc_Date : new Date()
        });
    }

    getReserveDefault(){
        return new ReserveViewModel(new Date(2020, 9, 17, 10, 0, 0, 0), '-', '-', '(000) 00 000 000', new Date(), '...');
    }
}