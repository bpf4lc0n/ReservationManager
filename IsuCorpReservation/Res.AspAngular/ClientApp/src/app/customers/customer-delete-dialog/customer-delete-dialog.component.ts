import { Component, Inject } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { CustomerViewModel } from "src/app/models/customer.model";

@Component({
    selector: 'customer-delete-dialog',
    templateUrl: './customer-delete-dialog.component.html',
  })
export class CustomerDeleteDialog {
  
constructor(
      public dialogRef: MatDialogRef<CustomerDeleteDialog>,
      @Inject(MAT_DIALOG_DATA) public data: CustomerViewModel) {}
  
onNoClick(): void {
      this.dialogRef.close();
    }  
  }