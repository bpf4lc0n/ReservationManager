export class CustomerType{
    public Id : number;
    public ContactType : string = '';
    public UpdateDate : Date;   
    public CreatedDate : Date;

    constructor(name : string)
    {
        this.ContactType = name;
        this.UpdateDate = new Date();
        this.CreatedDate = new Date();
    }
}