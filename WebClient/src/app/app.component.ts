import { Component } from '@angular/core';
import { AuthService } from './auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'WebClient';
  constructor(private authServiece:AuthService){
  };
  logOut():void{
    this.authServiece.logOut();
  }
  IsUserAuthenticated(): any {
    return this.authServiece.IsUserAuthenticated();
  }
  username():string{
    return this.authServiece.getUserName();
  }
}
