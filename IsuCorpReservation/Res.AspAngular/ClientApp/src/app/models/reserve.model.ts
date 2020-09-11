import { Customer } from "../models/customer.model";
import { Restaurant } from "./restaurant.model";

export class Reserve{
    public Id : number;
    public Customer : Customer;
    public Date : Date;
    public Restaurant : Restaurant;
    public Ranking : number = 0;
    public Favorite : boolean = false;

    constructor(date : Date, restaurant : string, name : string, phone : string, dateBirth : Date, desc : string)
    {
        this.Id = 0;        
        this.Customer = new Customer(name, phone, dateBirth, desc);
        this.Date = date;
        this.Ranking = 0;
        this.Favorite = false;
        this.Restaurant = new Restaurant(restaurant);
    }
}