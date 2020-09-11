import { Component, OnInit, Output, EventEmitter, OnDestroy, ViewChild } from '@angular/core';
import { Reserve } from '../../models/reserve.model';
import { ReserveService } from '../../services/reserve.service';
import { Subscription } from 'rxjs';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import {Sort} from '@angular/material/sort';

@Component({
  selector: 'app-reserve-list',
  templateUrl: './reserve-list.component.html',
  styleUrls: ['./reserve-list.component.css']
})
export class ReserveListComponent implements OnInit, OnDestroy {
  reserves : Reserve[];
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

  private igChangeSub : Subscription;

  @ViewChild(MatPaginator, {static:false}) paginator: MatPaginator;
  @ViewChild(MatSort, {static:false}) sort: MatSort;

  constructor(private reserveService : ReserveService) { }

  ngOnInit() {
    this.reserves = this.reserveService.getReserves();
    this.igChangeSub = this.reserveService.reservesChanged.subscribe(
      (reserves : Reserve[]) => { this.reserves = reserves }
    )
    this.dataSource = new MatTableDataSource(this.reserves);
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }  

  ngOnDestroy() : void {
      this.igChangeSub.unsubscribe();
  }

  onFavorite(res : Reserve){
    res.Favorite = !res.Favorite;
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