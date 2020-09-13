import { Reserve } from "./reserve.model";

export interface GetReserveOutput {
    reserves: Reserve[];
}

export interface GetReserveInput {
    DateReserve : Date;
    RestaurantId : number;
    CustomerId : number;
}
