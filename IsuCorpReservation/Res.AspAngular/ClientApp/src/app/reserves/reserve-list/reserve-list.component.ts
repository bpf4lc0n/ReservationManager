import { Component, OnInit, ViewChild } from '@angular/core';
import { ReserveViewModel } from '../../models/reserve.model';
import { ReserveService } from '../../services/reserve.service';
import { ReserveSort } from 'src/app/models/reserveSort.model';
import {tap, map} from 'rxjs/operators';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { MatPaginator, MatTableDataSource, PageEvent } from '@angular/material';

@Component({
  selector: 'app-reserve-list',
  templateUrl: './reserve-list.component.html',
  styleUrls: ['./reserve-list.component.css']
})
export class ReserveListComponent implements OnInit {
  Reserves : ReserveViewModel[];
  dataSource : MatTableDataSource<ReserveViewModel>; 
  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;

  sortingSelected : ReserveSort;
  sortingValues : ReserveSort[] = [
    {sorting : 'By Date Ascending', direction : 'ASC', field : 'DateReserve', option : 1 },
    {sorting : 'By Date Descending', direction : 'DESC', field : 'DateReserve', option : 2},
    {sorting : 'By Alphabetic Ascending', direction : 'ASC', field : 'Restaurant', option : 3},
    {sorting : 'By Alphabetic Descending', direction : 'DESC', field : 'Restaurant', option : 4},
    {sorting : 'By Ranking', direction : 'ASC', field : 'Ranking', option : 5}
  ]

  listForm   : FormGroup;
  config: any;

  selectedColumn : string;
  pos : number;

  columnDefinitions = [
    { def: 'Icon', showMobile: false },
    { def: 'Restaurant', showMobile: true },
    { def: 'Ranking', showMobile: false },
    { def: 'Favorite', showMobile: true },
    { def: 'Edit', showMobile: true },
    ];


  constructor(private reserveService : ReserveService,
    public fb: FormBuilder) { 

      this.sortingSelected = new ReserveSort('By Date Ascending', 'ASC', 'DateReserve', 1);

      this.listForm = this.fb.group({
        fc_SortValue : new FormControl('')
      })

      this.config = {
        itemsPerPage: 10,
        currentPage: 1,
        totalItems: 300
      };
      
      this.getReserves();
  }

  ngOnInit() {
    
  }

  getReserves() {
    this.reserveService.getReservesPage(this.sortingSelected.field, this.sortingSelected.direction, this.config.currentPage, this.config.itemsPerPage).pipe(
      tap(res=>console.log(res)),
      map((resData : ReserveViewModel[])=> {this.Reserves = resData; this.dataSource = new MatTableDataSource(resData); this.dataSource.paginator = this.paginator; this.dataSource.paginator.length = 300;})
    ).subscribe()  
     , err=>{console.log(err);  
     } 
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }  

  pageChanged(event){
    this.config.currentPage = event;
    console.log('page ' + event)
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
 
 getIsMobile():boolean{
  return ( /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent) ) ;
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
