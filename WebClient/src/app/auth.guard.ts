import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  Router,
} from '@angular/router';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean {
    if (this.authService.IsUserAuthenticated()) {
      return true;
    } else {
      console.log('User is not authenticated.');
      this.router.navigate(['/']); // Przekieruj użytkownika na stronę logowania
      return false;
    }
  }
}
