import { Component,ChangeDetectorRef } from '@angular/core';
import { CookService } from '../cook.service';
import { cookRequestPassChange } from '../model/cookRequest.interface';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrl: './settings.component.css'
})
export class SettingsComponent {
  newPassword: string = '';

  constructor(private cookService: CookService , private router:Router , private authServiece:AuthService) {}

  onChangePassword() {
    const confirmation = window.confirm('Are you sure you want to change your password?');

    if (confirmation) {
      const passwordChangeRequest: cookRequestPassChange = {
        password: this.newPassword,
      };

      this.cookService.updateCook(passwordChangeRequest).subscribe(
        () => {
          this.showNotification('Password changed successfully');
        }
      );
    }
  }

  onDeleteAccount() {
    const confirmation = window.confirm('Are you sure you want to delete your account?');

    if (confirmation) {
      this.cookService.deleteCook().subscribe(
        () => {
          this.showNotification('Account deleted successfully');
          this.authServiece.logOut();
          this.router.navigate(["/"]);
        }
      );
    }
  }

  showNotification(message: string) {
    const notification = document.createElement('div');
    notification.className = 'notification';
    notification.innerText = message;
    document.body.appendChild(notification);

    setTimeout(() => {
      notification.remove();
    }, 2000);
  }

}
