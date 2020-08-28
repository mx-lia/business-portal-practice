import { Injectable } from '@angular/core';
import {TranslateService} from '@ngx-translate/core';

@Injectable({ providedIn: 'root' })
export class LanguageService {
    constructor(private translateService: TranslateService) { }

    storeLanguage(lang: string) {
        localStorage.setItem('language', lang);
    }

    getStoredLanguage(): string {
        return localStorage.getItem('language');
    }

    changeLanguage(lang: string) {
        this.translateService.setDefaultLang(lang);
        this.translateService.use(lang);
        this.storeLanguage(lang);
    }

    setLanguage() {
        const lang = this.getStoredLanguage();
        if (lang) {
            this.translateService.setDefaultLang(lang);
            this.translateService.use(lang);
        }
        else {
            this.translateService.setDefaultLang('en');
            this.translateService.use('en');
            this.storeLanguage('en');
        }
    }
}
