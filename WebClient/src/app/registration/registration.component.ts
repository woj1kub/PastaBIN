import { Component } from '@angular/core';
import { CookService } from '../cook.service';
import { cookRequest } from '../model/cookRequest.interface';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {
  login: string = '';
  email: string = '';
  password: string = '';
  confirmPassword: string = '';

  constructor(private cookService: CookService) {}

  submitRegistration() {
    if (this.password !== this.confirmPassword) {
      alert('Passwords do not match');
      return;
    }

    const cook: cookRequest = {
      login: this.login,
      email: this.email,
      password: this.password
    };

    this.cookService.addCook(cook).subscribe(
      () => {
        this.resetForm();
      },
      (error) => {
        console.error('Error occurred during registration:', error);
      }
    );
  }

  resetForm() {
    this.login = '';
    this.email = '';
    this.password = '';
    this.confirmPassword = '';
  }
}
