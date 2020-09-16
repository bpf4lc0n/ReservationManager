import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { ReservesComponent } from "./reserves/reserves.component";
import { CustomersComponent } from "./customers/customers.component";
import { ReserveCustomerCreateComponent } from "./reserves/reserve-customer-create/reserve-customer-create.component";
import { CustomerEditComponent } from "./customers/customer-edit/customer-edit.component";
import { ReserveStartComponent } from "./reserves/reserve-start/reserve-start.component";
import { ReserveEditComponent } from "./reserves/reserve-edit/reserve-edit.component";
import { CustomerCreateComponent } from "./customers/customer-create/customer-create.component";
import { CustomerListComponent } from "./customers/customer-list/customer-list.component";

const appRoutes : Routes =[
    { path: '', redirectTo: '/reserves-list', pathMatch: 'full' }, 
    { path: 'reserves-list', component: ReservesComponent, children :[
        { path: '', component: ReserveStartComponent},  
        { path: ':id/edit', component: ReserveEditComponent}
    ]},
    { path: 'reserve-create', component: ReserveCustomerCreateComponent},
    // Create Contact Form banner:  List and Edit
    // When the user clicks on list, create a list page that starts after the banner
    /*
    { path: 'customer-create', component: CustomerCreateComponent, children :[ 
        { path: 'customers-list', component: CustomersComponent },
        { path: 'id/edit', component: CustomerEditComponent }
    ]},
    { path: 'customer-edit', component: CustomerEditComponent} // in a different page
    */
    { path: 'customers-list', component: CustomerListComponent},
    { path: 'customers-edit', component: CustomerEditComponent},
    { path: 'customers-create', component: CustomerCreateComponent}
];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})

export class AppRoutingModule{

}