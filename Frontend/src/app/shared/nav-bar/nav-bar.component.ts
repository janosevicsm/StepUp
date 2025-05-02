import { Component } from '@angular/core';
import {MatToolbar} from '@angular/material/toolbar';
import {MatButton} from '@angular/material/button';
import {Router, RouterLink} from '@angular/router';

@Component({
  selector: 'app-nav-bar',
  imports: [
    MatToolbar,
    MatButton,
    RouterLink
  ],
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.css'
})
export class NavBarComponent {
  constructor(private router: Router) {}

  logout() {
    this.router.navigate(['/auth']).then(r => {
    });
  }
}
