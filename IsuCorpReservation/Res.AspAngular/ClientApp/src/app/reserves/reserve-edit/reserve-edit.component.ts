import { Component, OnInit, ViewChild, ElementRef, Input } from '@angular/core';
import { ReserveViewModel } from '../../models/reserve.model';
import { ReserveService } from '../../services/reserve.service';
import { ActivatedRoute, Params } from '@angular/router';
import { MatSnackBar } from '@angular/material';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-reserve-edit',
  templateUrl: './reserve-edit.component.html',
  styleUrls: ['./reserve-edit.component.css']
})
export class ReserveEditComponent implements OnInit {
  reserve : ReserveViewModel;
  id: number;
  reserveForm : FormGroup ;

  constructor(public fb : FormBuilder,
              private reserveService : ReserveService,
              private route: ActivatedRoute,
              private _snackBar: MatSnackBar) {     
  }

  ngOnInit() {     
    const id = this.route.snapshot.params['id'];

    this.reserveForm = this.fb.group({
      $key : new FormControl(null),
      fc_Date : new FormControl(new Date(), Validators.required),
      fc_Restaurant : new FormControl('', Validators.required)
    })  

    this.getReserve(id);
  }

  getReserve(id : number) {
    this.reserveService.getReserveById(id).subscribe(
      data => {
        this.reserve = data; 
        this.reserveForm.setValue({
          $key: data.id,
          fc_Date : data.dateReserve,
          fc_Restaurant: data.restaurant
        }); 
      },
      error => {
        this.openSnackBar('Error loading data: ' + error.message);
      }
    );
  }

submitForm() {
    
    this.reserve.dateReserve = this.reserveForm.value.fc_Date;
    this.reserve.restaurant = this.reserveForm.value.fc_Restaurant;

    this.reserveService.EditReserve(this.reserve.id, this.reserve)
      .subscribe(
        data => {
          this.openSnackBar('Reserve edited');
        },
        error => {
          this.openSnackBar(error);
        }
      );
  }

  openSnackBar(message: string) {
    this._snackBar.open(message, 'Ok', {
      duration: 1500,
    });
  }

  getColAdjusment():number{
    return (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent) )? 1 : 4 ;
   }
}
