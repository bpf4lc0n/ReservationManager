export class ContactType{
    public Id : number;
    public Name : string = '';

    constructor(name : string)
    {
        this.Name = name;
    }
}