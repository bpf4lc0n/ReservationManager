import { ContactType } from "../models/contacttype.model";

export class ContactTypeService{

    private types : ContactType[] = [
        new ContactType('Type 1'),
        new ContactType('Type 2'),
        new ContactType('Type 3')
      ]

    getContactType(){
        return this.types.slice();
    }
}