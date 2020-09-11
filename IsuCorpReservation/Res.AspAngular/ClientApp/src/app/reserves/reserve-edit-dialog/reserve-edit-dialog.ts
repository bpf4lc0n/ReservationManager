import {Component} from '@angular/core';
import {MatDialog} from '@angular/material/dialog';
import { ReserveEditDialogItem } from './reserve-edit-dialog-item';

/**
 * @title Dialog elements
 */
@Component({
  selector: 'reserve-edit-dialog',
  templateUrl: './reserve-edit-dialog.html',
})
export class ReserveEditDialog {

  constructor(public dialog: MatDialog) {}

  openDialog() {
    this.dialog.open(ReserveEditDialogItem);
  }
}


