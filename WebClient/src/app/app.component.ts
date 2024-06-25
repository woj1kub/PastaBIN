import { Component } from '@angular/core';
import { AuthService } from './auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'WebClient';
  constructor(private authServiece:AuthService , private router:Router){
  };
  logOut():void{
    this.authServiece.logOut();
    this.router.navigate(["/"]);
  }
  IsUserAuthenticated(): any {
    return this.authServiece.IsUserAuthenticated();
  }
  username():string{
    return this.authServiece.getUserName();
  }
}
