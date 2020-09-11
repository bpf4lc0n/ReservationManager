import { Restaurant } from "../models/restaurant.model";

export class RestaurantService{

    private types : Restaurant[] = [
        new Restaurant('Restaurant 1'),
        new Restaurant('Restaurant 2'),
        new Restaurant('Restaurant 3'),
        new Restaurant('Restaurant 4')
      ]

    getContactType(){
        return this.types.slice();
    }
}