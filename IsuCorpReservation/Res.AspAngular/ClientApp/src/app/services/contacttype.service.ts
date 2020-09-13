import { CustomerType } from "../models/contacttype.model";

export class ContactTypeService{

    private types : CustomerType[] = [
        new CustomerType('Type 1'),
        new CustomerType('Type 2'),
        new CustomerType('Type 3')
      ]

    getContactType(){
        return this.types.slice();
    }
}