import { CustomerTypeViewModel } from "./customertype.model";

export class CustomerViewModel{
    public id : number;
    public name : string = '';
    public contactTypeId : number;
    public contactType : CustomerTypeViewModel;
    public telephone : string = '';
    public dateBirth : Date;
    public description : string = '';

    constructor(name : string, phone : string, dateBirth : Date, desc : string, cTypeId : number)
    {
        this.name = name;
        this.telephone = phone;
        this.dateBirth = (!dateBirth) ? new Date(): dateBirth;
        this.description = desc;
        this.contactTypeId = (!cTypeId) ? 0 : cTypeId;
    }
}