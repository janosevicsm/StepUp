import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import {provideAnimations} from '@angular/platform-browser/animations';
import {routes} from './app/app.routes';
import {provideRouter} from '@angular/router';

bootstrapApplication(AppComponent, {
  providers: [
    provideRouter(routes),
    provideAnimations()
  ]
}).then(r => {});
