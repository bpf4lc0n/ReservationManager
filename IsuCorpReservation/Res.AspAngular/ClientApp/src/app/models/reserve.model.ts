import { CustomerViewModel } from "../models/customer.model";

export class ReserveViewModel{
    public id : number;
    public restaurant : string;
    public dateReserve : Date;
    public ranking : number;
    public favoriteStatus : boolean;
    public customerId : number;
    public customer : CustomerViewModel;

    constructor(date : Date, restaurant : string, custId : number)
    {
        this.dateReserve = (!date) ? new Date(): date;
        this.restaurant = restaurant;
        this.customerId = custId;
    }
}

