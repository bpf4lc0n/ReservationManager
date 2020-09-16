import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { ReserveViewModel } from '../../models/reserve.model';
import { ReserveService } from '../../services/reserve.service';
import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';
import {Sort} from '@angular/material/sort';

@Component({
  selector: 'app-reserve-list',
  templateUrl: './reserve-list.component.html',
  styleUrls: ['./reserve-list.component.css']
})
export class ReserveListComponent implements OnInit, OnDestroy {
  Reserves : ReserveViewModel[];
  sortedData: ReserveViewModel[];

  selectedColumn : string;
  pos : number;
  dataSource: MatTableDataSource<ReserveViewModel>;

  columnDefinitions = [
    { def: 'Icon', showMobile: false },
    { def: 'Restaurant', showMobile: true },
    { def: 'Ranking', showMobile: false },
    { def: 'Favorite', showMobile: true },
    { def: 'Edit', showMobile: true },
    ];

  //@ViewChild(MatPaginator, {static:false}) paginator: MatPaginator;
  //@ViewChild(MatSort, {static:false}) sort: MatSort;

  constructor(private reserveService : ReserveService) { 
    this.getReserves();
  }

  ngOnInit() {
    
  }

  getReserves() {
    this.reserveService.getReserves().subscribe((data) => {  this.Reserves = data; this.sortedData = data})  
     ,err=>{console.log(err);  
     } 
  }

  ngAfterViewInit() {
    //this.dataSource.paginator = this.paginator;
    //this.dataSource.sort = this.sort;
  }  

  ngOnDestroy() : void {
      
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

  changeSortedColumn() {
    const sortState: Sort = {active: this.selectedColumn, direction: 'asc'};
    //this.sort.active = sortState.active;
    //this.sort.direction = sortState.direction;
    //this.sort.sortChange.emit(sortState);    
  }
}