export class CustomerTypeViewModel{
    public id : number;
    public contactType : string;

    constructor(name : string)
    {
        this.contactType = name;
    }
}