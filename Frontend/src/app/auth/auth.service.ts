import { Injectable } from '@angular/core';
import {BehaviorSubject, Observable} from 'rxjs';
import {JwtHelperService} from '@auth0/angular-jwt';
import {HttpClient} from '@angular/common/http';
import {environment} from '../environment/environment';
import {LoginDto, RegisterDto, TokenDto, UserDto} from '../shared/model';


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  userLogged$ = new BehaviorSubject<string>("");
  userLoggedState$ = this.userLogged$.asObservable();

  constructor(private http: HttpClient) {}

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

  getUserId(): number {
    if (this.isLoggedIn()) {
      const token: string | null = localStorage.getItem('user');
      if (!token) return -1;

      const helper = new JwtHelperService();
      const decoded = helper.decodeToken(token);
      const id = decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
      return Number(id); // cast to number
    }
    return -1;
  }

  getUserMail(): string {
    if (this.isLoggedIn()) {
      const token: string | null = localStorage.getItem('user');
      if (!token) return '';

      const helper = new JwtHelperService();
      const decoded = helper.decodeToken(token);
      return decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"] || '';
    }
    return '';
  }

  login(credentials: LoginDto): Observable<TokenDto> {
    return this.http.post<TokenDto>(environment.apiHost + 'user/login', credentials);
  }

  register(credentials: RegisterDto): Observable<UserDto> {
    return this.http.post<UserDto>(environment.apiHost + 'user/register', credentials);
  }

  logout(): void {
    localStorage.removeItem("user");
    this.setUserLogged();
  }
}
