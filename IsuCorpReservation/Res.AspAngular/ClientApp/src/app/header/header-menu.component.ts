import { Component, Input } from "@angular/core";
import { ActivatedRoute, ActivationEnd, NavigationEnd, NavigationStart, Router } from "@angular/router";
import { Observable } from "rxjs";

@Component({
    selector:'app-header-menu',
    templateUrl:'./header-menu.component.html',
    styleUrls: ['./header-menu.component.css'],
})
export class HeaderMenuComponent{
    mainLabel : string;
    buttonLabel : string;
    dirRef : string;

    constructor(private router : Router){  
        router.events.subscribe(Event => {
            if(Event instanceof NavigationStart) {
            }
            if(Event instanceof NavigationEnd) {
                this.mainLabel = Event.url.includes("reserves-list") ? "Reservations List" : "Create Reservation" ;
                this.buttonLabel = Event.url.includes("reserves-list") ? "CREATE RESERVE" : "RESERVATIONS LIST";
                this.dirRef = Event.url.includes("reserves-list") ? "/reserve-create" : "/reserves-list";
            }
            // NavigationEnd
            // NavigationCancel
            // NavigationError
            // RoutesRecognized
         });
    }
    

    getIsMobile():boolean{
        console.log("Is mobile change");
        return ( /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent) ) ;
       }
}