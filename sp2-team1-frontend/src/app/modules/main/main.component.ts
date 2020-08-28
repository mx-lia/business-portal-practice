import { LanguageService } from './../core/services/language.service';
import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';

import { AuthService } from '../core/services/auth.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {

  userName: string;
  isAdmin: boolean;

  constructor(
    private authService: AuthService,
    private router: Router,
    public languageService: LanguageService) {
  }

  ngOnInit(): void {
    const user = this.authService.getUser();
    this.isAdmin = user.roleId === 1;
    this.userName = user.userName;
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }

  changeLang(lang: string) {
    this.languageService.changeLanguage(lang);
  }

}
