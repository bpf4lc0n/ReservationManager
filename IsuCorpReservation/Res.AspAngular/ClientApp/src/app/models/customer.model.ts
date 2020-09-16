import { CustomerTypeViewModel } from "./customertype.model";
import { ReserveViewModel } from "./reserve.model";

export class CustomerViewModel{
    public id : number;
    public name : string = '';
    public contactTypeId : number;
    public contactType : CustomerTypeViewModel;
    public telephone : string = '';
    public dateBirth : Date;
    public description : string = '';

    constructor(name : string, phone : string, dateBirth : Date, desc : string)
    {
        this.name = name;
        this.telephone = phone;
        this.dateBirth = dateBirth;
        this.description = desc;
        this.contactType = new CustomerTypeViewModel("Type 3")
    }
}