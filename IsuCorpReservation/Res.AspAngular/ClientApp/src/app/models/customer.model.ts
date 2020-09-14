import { CustomerTypeViewModel } from "./customertype.model";
import { ReserveViewModel } from "./reserve.model";

export class CustomerViewModel{
    public Id : number;
    public Name : string = '';
    public ContactTypeId : number;
    public ContactType : CustomerTypeViewModel;
    public Telephone : string = '';
    public DateBirth : Date;
    public Description : string = '';
    public UpdateDate : Date;   
    public CreatedDate : Date;
    public Reserves : ReserveViewModel[];

    constructor(name : string, phone : string, dateBirth : Date, desc : string)
    {
        this.Name = name;
        this.Telephone = phone;
        this.DateBirth = dateBirth;
        this.Description = desc;
        this.ContactType = new CustomerTypeViewModel("Type 3")
        this.UpdateDate = new Date();
        this.CreatedDate = new Date();
    }
}