import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { ReservesComponent } from "./reserves/reserves.component";
import { CustomersComponent } from "./customers/customers.component";
import { ReserveCustomerCreateComponent } from "./reserves/reserve-customer-create/reserve-customer-create.component";
import { CustomerDetailComponent } from "./customers/customer-detail/customer-detail.component";
import { ReserveStartComponent } from "./reserves/reserve-start/reserve-start.component";
import { ReserveEditComponent } from "./reserves/reserve-edit/reserve-edit.component";

const appRoutes : Routes =[
    { path: '', redirectTo: '/reserves', pathMatch: 'full' }, 
    { path: 'reserves', component: ReservesComponent, children :[
        { path: '', component: ReserveStartComponent},  
        { path: 'new', component: ReserveCustomerCreateComponent}, 
        { path: ':id', component: ReserveEditComponent},
        { path: ':id/edit', component: ReserveEditComponent}
    ]},
    { path: 'customers', component: CustomersComponent},
    { path: 'reserve-create', component: ReserveCustomerCreateComponent},
    { path: 'customer-create', component: CustomerDetailComponent}
];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})

export class AppRoutingModule{

}