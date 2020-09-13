import { Customer } from "../models/customer.model";
import { Restaurant } from "./restaurant.model";

export class Reserve{
    public Id : number;
    public RestaurantId : number;
    public Restaurant : Restaurant;
    public DateReserve : Date;
    public Ranking : number = 0;
    public FavoriteStatus : boolean = false;
    public CustomertId : number;
    public Customer : Customer;  
    public UpdateDate : Date;   
    public CreatedDate : Date;

    constructor(date : Date, restaurant : string, name : string, phone : string, dateBirth : Date, desc : string)
    {
        this.Id = 0;        
        this.Customer = new Customer(name, phone, dateBirth, desc);
        this.DateReserve = date;
        this.Ranking = 0;
        this.FavoriteStatus = false;
        this.Restaurant = new Restaurant(restaurant);
        this.UpdateDate = new Date();
        this.CreatedDate = new Date();
    }
}

