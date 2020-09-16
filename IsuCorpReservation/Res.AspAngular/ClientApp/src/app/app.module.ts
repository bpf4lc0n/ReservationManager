import '../polyfills';

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HttpClient, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { CustomersComponent } from './customers/customers.component';
import { CustomerListComponent } from './customers/customer-list/customer-list.component';
import { CustomerEditComponent } from './customers/customer-edit/customer-edit.component';
import { ReservesComponent } from './reserves/reserves.component';
import { ReserveListComponent } from './reserves/reserve-list/reserve-list.component';
import { ReserveEditComponent } from './reserves/reserve-edit/reserve-edit.component';
import { CustomerService } from './services/customer.service';
import { ReserveService } from './services/reserve.service';
import { ReserveCustomerCreateComponent } from './reserves/reserve-customer-create/reserve-customer-create.component';
import { AppRoutingModule } from './app-routing.module';
import { ReserveStartComponent } from './reserves/reserve-start/reserve-start.component';
import { DropDownDirective } from './shared/dropdown.directive';
import { ContactTypeService } from './services/contacttype.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import {ReactiveFormsModule} from '@angular/forms';
import {MatNativeDateModule, MatTableModule, MatPaginatorModule, MatFormFieldModule, MatSelectModule, MatGridListModule, MatInputModule, MatIconModule, MatToolbarModule, MatMenuModule, MatDialogModule, MatSpinner, MatProgressSpinnerModule, MatDatepickerModule, MatCardModule, MatProgressBarModule, MatSnackBarModule} from '@angular/material';

import {TranslateHttpLoader} from "@ngx-translate/http-loader";
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { CKEditorModule } from 'ckeditor4-angular';
import { HeaderMenuComponent } from './header/header-menu.component';
import { CustomerCreateComponent } from './customers/customer-create/customer-create.component';
import { CustomerDeleteDialog } from './customers/customer-delete-dialog/customer-delete-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HeaderMenuComponent,
    CustomersComponent,
    CustomerListComponent,
    CustomerCreateComponent,
    CustomerEditComponent,
    ReservesComponent,
    ReserveListComponent,
    ReserveEditComponent,
    ReserveCustomerCreateComponent,
    ReserveStartComponent,
    DropDownDirective, 

    CustomerDeleteDialog
  ],  
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    
    HttpClientModule,
    MatNativeDateModule,
    ReactiveFormsModule,

    MatTableModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MatSelectModule,
    MatGridListModule,
    MatInputModule,
    MatIconModule,
    MatToolbarModule,
    MatMenuModule,
    MatDialogModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatDatepickerModule,
    MatCardModule,
    MatSnackBarModule,

    TranslateModule.forRoot({
      loader:{
        provide : TranslateLoader,
        useFactory : HttpLoaderFactory,
        deps : [HttpClient]
      }
    }),
    CKEditorModule
  ],
  //entryComponents: [ReserveListComponent],
  entryComponents: [CustomerDeleteDialog],
  providers: [CustomerService, ReserveService, ContactTypeService],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function HttpLoaderFactory(http: HttpClient){
  return new TranslateHttpLoader(http, '../../assets/i18n/', '.json');
}