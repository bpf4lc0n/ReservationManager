import { Component, Input } from "@angular/core";

@Component({
    selector:'app-header-menu',
    templateUrl:'./header-menu.component.html',
    styleUrls: ['./header-menu.component.css'],
})
export class HeaderMenuComponent{
    @Input() mainLabel : string;
    @Input() buttonLabel : string;
    @Input() dirRef : string;
}