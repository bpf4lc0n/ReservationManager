import { CustomerViewModel } from "../models/customer.model";
import { RestaurantViewModel } from "./restaurant.model";

export class ReserveViewModel{
    public Id : number;
    public RestaurantId : number;
    public Restaurant : RestaurantViewModel;
    public DateReserve : Date;
    public Ranking : number;
    public FavoriteStatus : boolean;
    public CustomertId : number;
    public Customer : CustomerViewModel;  
    public UpdateDate : Date;   
    public CreatedDate : Date;

    constructor(date : Date, restaurant : string, name : string, phone : string, dateBirth : Date, desc : string)
    {
        this.Id = 0;        
        this.Customer = new CustomerViewModel(name, phone, dateBirth, desc);
        this.DateReserve = date;
        this.Ranking = 0;
        this.FavoriteStatus = false;
        this.Restaurant = new RestaurantViewModel(restaurant);
        this.UpdateDate = new Date();
        this.CreatedDate = new Date();
    }

    public RestaurantName(){
        return (this.Restaurant == null) ? "-" : this.Restaurant.Name;
    }
}

