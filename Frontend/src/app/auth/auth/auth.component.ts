import {Component, OnInit} from '@angular/core';
import {AbstractControl, FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {AuthService} from '../auth.service';
import {Router} from '@angular/router';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import {CommonModule, NgIf} from '@angular/common';


@Component({
  selector: 'app-auth',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    NgIf,
  ],
  templateUrl: './auth.component.html',
  styleUrl: './auth.component.css'
})
export class AuthComponent implements OnInit {
  hideLoginPassword: boolean = true;
  hideRegisterPassword: boolean = true;
  hideRegisterConfirmPassword: boolean = true;
  rightPanelActive = false;
  hideLogin = false;

  switchToRegister() {
    this.rightPanelActive = true;
  }

  switchToLogin() {
    this.rightPanelActive = false;
    this.hideLogin = false;
  }

  onTransitionEnd() {
    if (this.rightPanelActive) {
      this.hideLogin = true;
    }
  }

  constructor(private authService: AuthService, private router: Router) {
  }

  validatePasswordMatch = (control: AbstractControl): {[key: string]: any} | null => {
    const password = this.registrationForm?.get('password')?.value as string;
    const passwordConfirm = control.value as string;

    if (password !== passwordConfirm) {
      return {passwordMatch: true};
    }

    return null;
  };

  loginForm = new FormGroup({
    mail: new FormControl('', [Validators.email, Validators.required]),
    password: new FormControl('', [Validators.minLength(3), Validators.required]),
  });

  registrationForm = new FormGroup({
    name: new FormControl('', [
      Validators.required,
      Validators.pattern('^[a-zA-Z]*$')]),
    surname: new FormControl('', [
      Validators.required,
      Validators.pattern('^[a-zA-Z]*$')]),
    email: new FormControl('', [
      Validators.required,
      Validators.email]),
    password: new FormControl('', [
      Validators.minLength(8),
      Validators.required]),
    confirmPassword: new FormControl('', [
      Validators.required,
      this.validatePasswordMatch])
  });

  ngOnInit(): void {
  }

  logIn() {
    if (this.loginForm.valid) {
      const credentials = {
        email: this.loginForm.value.mail!,
        password: this.loginForm.value.password!,
      };

      this.authService.login(credentials).subscribe({
        next: (response) => {
          localStorage.setItem('user', response.token);
          this.authService.setUserLogged();
          this.router.navigate(['home']).then(() => {});
        },
        error: (err) => {
          alert('Login failed: ' + err.message);
        },
      });
    }
  }

  register() {

  }

  changePasswordState(type: String){
    switch (type) {
      case 'login':
        this.hideLoginPassword = !this.hideLoginPassword;
        break;
      case 'register':
        this.hideRegisterPassword = !this.hideRegisterPassword;
        break;
      case 'registerConfirm':
        this.hideRegisterConfirmPassword = !this.hideRegisterConfirmPassword;
        break;
    }

  }

}
