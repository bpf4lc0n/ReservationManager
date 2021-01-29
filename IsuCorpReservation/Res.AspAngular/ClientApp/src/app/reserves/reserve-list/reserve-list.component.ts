import { Component, OnInit, ViewChild } from '@angular/core';
import { ReserveViewModel } from '../../models/reserve.model';
import { ReserveService } from '../../services/reserve.service';
import { ReserveSort } from 'src/app/models/reserveSort.model';
import {tap, map} from 'rxjs/operators';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { MatPaginator, MatTableDataSource, PageEvent } from '@angular/material';
import { DeviceDetectorService } from 'ngx-device-detector';

@Component({
  selector: 'app-reserve-list',
  templateUrl: './reserve-list.component.html',
  styleUrls: ['./reserve-list.component.css']
})
export class ReserveListComponent implements OnInit {
  listForm   : FormGroup;
  config: any;
  Reserves : ReserveViewModel[];
  dataSource : MatTableDataSource<ReserveViewModel>; 
  @ViewChild(MatPaginator, {static: false, read: true}) paginator: MatPaginator;

  sortingSelected : ReserveSort;
  sortingValues : ReserveSort[] = [
    {sorting : 'By Date Ascending', direction : 'ASC', field : 'DateReserve', option : 1 },
    {sorting : 'By Date Descending', direction : 'DESC', field : 'DateReserve', option : 2},
    {sorting : 'By Alphabetic Ascending', direction : 'ASC', field : 'Restaurant', option : 3},
    {sorting : 'By Alphabetic Descending', direction : 'DESC', field : 'Restaurant', option : 4},
    {sorting : 'By Ranking', direction : 'ASC', field : 'Ranking', option : 5}
  ]  

  columnDefinitions = [
    { def: 'Icon', showMobile: false },
    { def: 'Restaurant', showMobile: true },
    { def: 'Ranking', showMobile: false },
    { def: 'Favorite', showMobile: true },
    { def: 'Edit', showMobile: true },
    ];


  constructor(
    private reserveService : ReserveService,
    public fb: FormBuilder, 
    private deviceService: DeviceDetectorService) { 

      this.sortingSelected = new ReserveSort('By Date Ascending', 'ASC', 'DateReserve', 1);

      this.listForm = this.fb.group({
        fc_SortValue : new FormControl('')
      })

      this.config = {
        itemsPerPage: 8,
        currentPage: 1,
        totalItems: 300
      };
      
      this.getReserves();
  }
  ngOnInit(): void {
    //throw new Error('Method not implemented.');
  }

  getReserves() {
    this.reserveService.getReservesPage(this.sortingSelected.field, this.sortingSelected.direction, this.config.currentPage, this.config.itemsPerPage).pipe(
      tap(res=>console.log(res)),
      map((resData : ReserveViewModel[])=> {
        this.Reserves = resData;
         this.dataSource = new MatTableDataSource(resData); 
         this.dataSource.paginator = this.paginator;})
    ).subscribe()  
     , err=>{console.log(err);  
     } 

     this.reserveService.getReservesCount().subscribe(data => this.config.totalItems = data);
  }

  onPaginationChange(event : PageEvent){
    this.config.currentPage = event.pageIndex + 1;
    this.getReserves();
  }

  onFavorite(res : ReserveViewModel){
    res.favoriteStatus = !res.favoriteStatus;
    this.reserveService.EditReserve(res.id, res) 
        .subscribe(arg => {console.log('Reserve Favorite status is update successfully')});
  }

  onRate(res : ReserveViewModel, value : number){
    res.ranking = value;
    this.reserveService.EditReserve(res.id, res) 
        .subscribe(arg => {console.log('Reserve Ranking is update successfully')});
  }
 
  getIsMobile() : boolean{
  return this.deviceService.isMobile() ;
  }

  getDisplayedColumns(): string[] {
    const isMobile = this.getIsMobile();
    return this.columnDefinitions
    .filter(cd => !isMobile || cd.showMobile)
    .map(cd => cd.def);
    }

  changeSortedColumn(event: Event) { 
    console.log(this.listForm.value.fc_SortValue);
    if (this.listForm.value.fc_SortValu !== this.sortingSelected.option) {
      this.sortingSelected = this.sortingValues[this.listForm.value.fc_SortValue - 1];
      this.getReserves();
    }
  }
}
