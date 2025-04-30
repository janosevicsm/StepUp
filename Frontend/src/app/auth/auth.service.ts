import { Injectable } from '@angular/core';
import {BehaviorSubject} from 'rxjs';
import {JwtHelperService} from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  userLogged$ = new BehaviorSubject<string>("");
  userLoggedState$ = this.userLogged$.asObservable();

  constructor() { }

  isLoggedIn(): boolean {
    return localStorage.getItem('user') != null;
  }

  checkTokenValidity(){
    if (this.isLoggedIn()) {
      const accessTokenString: string | null = localStorage.getItem('user');
      const helper = new JwtHelperService();

      if (helper.isTokenExpired(accessTokenString)) {
        localStorage.removeItem("user");
        this.setUserLogged();
        window.location.href = "http://localhost:4200/";
      }
    }
  }

  setUserLogged(): void {
    this.userLogged$.next(this.getUserMail());
  }

  getUserMail(): string {
    if (this.isLoggedIn()) {
      const accessTokenString: any = localStorage.getItem('user');
      const accessToken = accessTokenString;
      const helper = new JwtHelperService();
      return helper.decodeToken(accessToken).email;
    }
    return '';
  }
}
