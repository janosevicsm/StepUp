import { Routes } from '@angular/router';
import {AuthComponent} from './auth/auth/auth.component';
import {HomeComponent} from './core/home/home.component';
import {WorkoutsComponent} from './workouts/workouts/workouts.component';
import {ProgressComponent} from './progress/progress/progress.component';

export const routes: Routes = [
  { path: '', component: AuthComponent },
  { path: 'auth', component: AuthComponent },
  { path: 'home', component: HomeComponent },
  { path: 'workouts', component: WorkoutsComponent },
  { path: 'progress', component: ProgressComponent },
];
