import { Reserve } from "./reserve.model";

export class Restaurant{
    public Id : number;
    public Name : string = '';
    public Icon : string= "";
    public ReserveDetails : Reserve[];
    public UpdateDate : Date;   
    public CreatedDate : Date;

    constructor(name : string)
    {
        this.Name = name;
        this.UpdateDate = new Date();
        this.CreatedDate = new Date();
    }
}