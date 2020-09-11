import { ContactType } from "./contacttype.model";

export class Customer{
    public Id : number;
    public Name : string = '';
    public CtType : ContactType;
    public Telephone : string = '';
    public DateBirth : Date;
    public Description : string = '';

    constructor(name : string, phone : string, dateBirth : Date, desc : string)
    {
        this.Name = name;
        this.Telephone = phone;
        this.DateBirth = dateBirth;
        this.Description = desc;
        this.CtType = new ContactType("Type 3")
    }
}