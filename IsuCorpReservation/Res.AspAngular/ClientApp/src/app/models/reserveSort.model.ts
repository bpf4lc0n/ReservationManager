export class ReserveSort{
    public option : number;
    public sorting : string;
    public field : string;
    public direction : string;

    constructor(fsorting : string, fdirection : string, ffield : string, foption : number){
        this.sorting =fsorting;
        this.direction =fdirection;
        this.field =ffield;
        this.option = foption;
    }
}