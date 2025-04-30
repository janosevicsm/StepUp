import { Routes } from '@angular/router';
import {AuthComponent} from './auth/auth/auth.component';

export const routes: Routes = [
  { path: '', component: AuthComponent },
  { path: 'auth', component: AuthComponent },
];
