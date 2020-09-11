import { FormControl, FormGroup } from '@angular/forms';
import { Subject } from 'rxjs';
import { Reserve } from "../models/reserve.model";

export class ReserveService{
    reservesChanged = new Subject<Reserve[]>();
    reserveSelected = new Subject<Reserve>();
    reserves: Reserve[] = [
        new Reserve(new Date(), 'Porto Rest', 'Joan', '(000) 00 000 000', new Date(), '...'),
        new Reserve(new Date(), 'Fish  & Ships', 'Renaldo', '(000) 11 111 111', new Date(), 'Toda la vida comiendo pan'),
        new Reserve(new Date(), 'Solari', 'Renaldo', '(000) 11 111 111', new Date(), 'Toda la vida comiendo pan'),
        new Reserve(new Date(), 'Chinese', 'Renaldo', '(000) 11 111 111', new Date(), 'Toda la vida comiendo pan'),
        new Reserve(new Date(), 'Spartans foon', 'Renaldo', '(000) 11 111 111', new Date(), 'Toda la vida comiendo pan'),
        new Reserve(new Date(), 'Taste and relax', 'Renaldo', '(000) 11 111 111', new Date(), 'Toda la vida comiendo pan'),
        new Reserve(new Date(), 'Ice cream delicious', 'Renaldo', '(000) 11 111 111', new Date(), 'Toda la vida comiendo pan'),
        new Reserve(new Date(), 'Colonial flavour', 'Renaldo', '(000) 11 111 111', new Date(), 'Toda la vida comiendo pan'),
        new Reserve(new Date(), 'Meet, meet and more meet for all the family ', 'Renaldo', '(000) 11 111 111', new Date(), 'Toda la vida comiendo pan')
    ];

    form : FormGroup = new FormGroup({
        $key : new FormControl(null),
        fc_Restaurant : new FormControl(''),
        fc_Date : new FormControl(new Date())
    })
    
    getReserves()
    {
        return this.reserves.slice();
    }

    getReserve(id:number){
        return this.reserves[id];
    }

    getReserveDefault(){
        return new Reserve(new Date(2020, 9, 17, 10, 0, 0, 0), '-', '-', '(000) 00 000 000', new Date(), '...');
    }

    addReserve(reserve : Reserve){
        this.reserves.push(reserve);
        this.reservesChanged.next(this.reserves.slice());
    }

    deleteSelectedReserve(){
        
    }
}