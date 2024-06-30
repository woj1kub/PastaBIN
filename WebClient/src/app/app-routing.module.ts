import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PastaAddComponent } from './pasta-add/pasta-add.component';
import { RegistrationComponent } from './registration/registration.component';
import { PastaSettingsComponent } from './pasta-settings/pasta-settings.component';
import { LoginComponent } from './login/login.component';
import { PastaComponent } from './pasta/pasta.component';
import { PastaUserComponent } from './pasta-user/pasta-user.component';
import { AuthGuard } from './auth.guard';
import { SettingsComponent } from './settings/settings.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'addPasta', component: PastaAddComponent },
  { path: 'signUp', component: RegistrationComponent },
  { path: 'ustawienia', component: SettingsComponent },
  {
    path: 'pastaSettings/:pastaID',
    component: PastaSettingsComponent,
    canActivate: [AuthGuard],
  },
  { path: 'openPasta', component: PastaComponent },
  { path: 'pasty', component: PastaUserComponent, canActivate: [AuthGuard] },
  { path: '', redirectTo: 'addPasta', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
