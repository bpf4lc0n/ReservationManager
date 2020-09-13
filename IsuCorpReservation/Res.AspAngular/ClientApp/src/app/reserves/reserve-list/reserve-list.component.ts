import { Component, OnInit, Output, EventEmitter, OnDestroy, ViewChild } from '@angular/core';
import { Reserve } from '../../models/reserve.model';
import { ReserveService } from '../../services/reserve.service';
import { Subscription } from 'rxjs';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import {Sort} from '@angular/material/sort';
import { GetReserveOutput } from 'src/app/models/getReserveOutput.model.';

@Component({
  selector: 'app-reserve-list',
  templateUrl: './reserve-list.component.html',
  styleUrls: ['./reserve-list.component.css']
})
export class ReserveListComponent implements OnInit, OnDestroy {
  getReserveOutput : GetReserveOutput;  
  Reserves : Reserve[];
  sortedData: Reserve[];

  selectedColumn : string;
  pos : number;
  dataSource: MatTableDataSource<Reserve>;

  columnDefinitions = [
    { def: 'Icon', showMobile: false },
    { def: 'Restaurant', showMobile: true },
    { def: 'Ranking', showMobile: false },
    { def: 'Favorite', showMobile: true },
    { def: 'Edit', showMobile: true },
    ];

  //@ViewChild(MatPaginator, {static:false}) paginator: MatPaginator;
  @ViewChild(MatSort, {static:false}) sort: MatSort;

  constructor(private reserveService : ReserveService) { 
    this.getReserves();
  }

  ngOnInit() {
    
  }

  getReserves() {
    this.reserveService.getReserves().subscribe(data => {this.getReserveOutput = data; console.log('data', data); console.log('data', data.reserves);
    console.log('reserves', this.getReserveOutput); console.log('reserves', this.getReserveOutput.reserves)});
  }

  ngAfterViewInit() {
    //this.dataSource.paginator = this.paginator;
    //this.dataSource.sort = this.sort;
  }  

  ngOnDestroy() : void {
      
  }

  onFavorite(res : Reserve){
    res.FavoriteStatus = !res.FavoriteStatus;
  }

  onRate(res : Reserve, value : number){
    res.Ranking = value;
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

  changeSortedColumn() {
    const sortState: Sort = {active: this.selectedColumn, direction: 'asc'};
    this.sort.active = sortState.active;
    this.sort.direction = sortState.direction;
    this.sort.sortChange.emit(sortState);    
  }
}