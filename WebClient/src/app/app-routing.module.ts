import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PastaAddComponent } from './pasta-add/pasta-add.component';
import { RegistrationComponent } from './registration/registration.component';
import { PastaSettingsComponent } from './pasta-settings/pasta-settings.component';
import { LoginComponent } from './login/login.component';
import { PastaComponent } from './pasta/pasta.component';
import { PastaUserComponent } from './pasta-user/pasta-user.component';

const routes: Routes = [
  {path:'login', component:LoginComponent},
  {path:'addPasta' , component:PastaAddComponent},
  {path:'signUp', component:RegistrationComponent},
  {path:'pastaSettings/:pastaID', component:PastaSettingsComponent},
  {path:'openPasta', component:PastaComponent},
  {path:'pasty' , component:PastaUserComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
