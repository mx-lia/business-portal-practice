import { Component } from '@angular/core';

import { LanguageService } from './modules/core/services/language.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';

  constructor(languageService: LanguageService) {
    languageService.setLanguage();
  }
}
