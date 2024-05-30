import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { PastaComponent } from './pasta/pasta.component';
import { PastaAddComponent } from './pasta-add/pasta-add.component';
import { PastaHistoryComponent } from './pasta-history/pasta-history.component';
import { PastaSharingComponent } from './pasta-sharing/pasta-sharing.component';
import { PastaSharingSettingsComponent } from './pasta-sharing-settings/pasta-sharing-settings.component';
import { PastaSharingGroupsComponent } from './pasta-sharing-groups/pasta-sharing-groups.component';
import { SettingsComponent } from './settings/settings.component';
import { PastaImagesComponent } from './pasta-images/pasta-images.component';
import { PastaTextsComponent } from './pasta-texts/pasta-texts.component';
import { HttpClientModule } from '@angular/common/http';
import { NewPastaTextComponent } from './new-pasta-text/new-pasta-text.component';
import { NewPastaImageComponent } from './new-pasta-image/new-pasta-image.component';
import { PastaSettingsComponent } from './pasta-settings/pasta-settings.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { MatNativeDateModule } from '@angular/material/core';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegistrationComponent,
    PastaComponent,
    PastaAddComponent,
    PastaHistoryComponent,
    PastaSharingComponent,
    PastaSharingSettingsComponent,
    PastaSharingGroupsComponent,
    SettingsComponent,
    PastaImagesComponent,
    PastaTextsComponent,
    NewPastaTextComponent,
    NewPastaImageComponent,
    PastaSettingsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserModule,
    BrowserAnimationsModule,
    MatDatepickerModule,
    MatInputModule,
    MatNativeDateModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
