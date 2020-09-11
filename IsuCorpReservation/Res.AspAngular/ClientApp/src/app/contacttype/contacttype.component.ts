import { Component, OnInit } from '@angular/core';
import { ContactType } from '../models/contacttype.model';
import { ContactTypeService } from '../services/contacttype.service';

@Component({
  selector: 'app-contact-type',
  templateUrl: './contact-type.component.html'//,
  //styleUrls: ['./contact-type.component.less']
})
export class ContactTypeComponent implements OnInit {
    contactTypes : ContactType[];

  constructor(private contacttypeService : ContactTypeService) { }

  ngOnInit() {
    this.contactTypes = this.contacttypeService.getContactType();
  }

}