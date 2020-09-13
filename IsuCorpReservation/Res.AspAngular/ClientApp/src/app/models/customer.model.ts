import { CustomerType } from "./contacttype.model";
import { Reserve } from "./reserve.model";

export class Customer{
    public Id : number;
    public Name : string = '';
    public ContactTypeId : number;
    public ContactType : CustomerType;
    public Telephone : string = '';
    public DateBirth : Date;
    public Description : string = '';
    public UpdateDate : Date;   
    public CreatedDate : Date;
    public Reserves : Reserve[];

    constructor(name : string, phone : string, dateBirth : Date, desc : string)
    {
        this.Name = name;
        this.Telephone = phone;
        this.DateBirth = dateBirth;
        this.Description = desc;
        this.ContactType = new CustomerType("Type 3")
        this.UpdateDate = new Date();
        this.CreatedDate = new Date();
    }
}