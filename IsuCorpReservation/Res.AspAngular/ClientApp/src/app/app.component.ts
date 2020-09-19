import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'Reservation Manager App';

  constructor(public translate : TranslateService){
    this.translate.addLangs(['en', 'es']);
    this.translate.setDefaultLang('es')
  }

  changeLanguage(lang : string){
    this.translate.use(lang);
  }

}
