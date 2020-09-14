import { ReserveViewModel } from "./reserve.model";

export class RestaurantViewModel{
    public Id : number;
    public Name : string = '';
    public Icon : string= "";
    public ReserveDetails : ReserveViewModel[];
    public UpdateDate : Date;   
    public CreatedDate : Date;

    constructor(name : string)
    {
        this.Name = name;
        this.UpdateDate = new Date();
        this.CreatedDate = new Date();
    }
}