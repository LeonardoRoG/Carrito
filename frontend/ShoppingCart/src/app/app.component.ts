import { Component, OnInit, effect, inject } from '@angular/core';
import { AuthService } from './auth/auth.service';
import { Router } from '@angular/router';
import { AuthStatus } from './auth/interface/auth-status.enum';
import { User } from './auth/interface';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css', '../styles.css'],
})
export class AppComponent implements OnInit {
  private authService = inject(AuthService);
  private router = inject(Router);

  isAuthenticated: boolean = false;
  title = 'ShoppingCart';

  currentUserLogin?: User;

  constructor() {
    const userChangeEffect = effect(() => {
      switch (this.authService.authStatus()) {
        case AuthStatus.authenticated:
          this.isAuthenticated = true;
          this.currentUserLogin = this.authService.currentUser();
          break;
        case AuthStatus.notAuthenticated:
          this.isAuthenticated = false;
          this.currentUserLogin = this.authService.currentUser();
          break;
        default:
          this.isAuthenticated = false;
          this.currentUserLogin = this.authService.currentUser();
          break;
      }
    });
  }

  ngOnInit(): void {
    this.authService.checkStatus();

    if (this.authService.authStatus() === AuthStatus.authenticated) {
      this.isAuthenticated = true;
      this.currentUserLogin = this.authService.currentUser();
    }
  }

  logout() {
    this.authService.logout();
    this.router.navigateByUrl('/auth');
  }
}
