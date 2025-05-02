import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { provideRouter } from '@angular/router';
import { provideAnimations } from '@angular/platform-browser/animations';
import { routes } from './app/app.routes';

const appConfig = {
  providers: [provideRouter(routes), provideAnimations()]
};

bootstrapApplication(AppComponent, appConfig)
  .catch(err => console.error(err));
