import { Component } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  isAuthenticated$ = this.auth.isAuthenticated$;

  constructor(private auth: AuthService) {}

  login() {
    this.auth.loginWithRedirect();
  }

  logout() {
    this.auth.logout();
  }

}
