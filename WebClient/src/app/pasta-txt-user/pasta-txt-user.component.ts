import { Component, EventEmitter, Input, Output } from '@angular/core';
import { PastaTextResponse } from '../model/pastaTextResponce';

@Component({
  selector: '[app-pasta-txt-user]',
  templateUrl: './pasta-txt-user.component.html',
  styleUrl: './pasta-txt-user.component.css'
})
export class PastaTxtUserComponent {
  @Input('app-pasta-txt-user') pastatxt!: PastaTextResponse;
  public onSettingsClick():void {
    
  }
  public onDeleteClick():void {

  }
}
