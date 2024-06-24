import { Component, Input } from '@angular/core';
import { PastaTextResponse } from '../model/pastaTextResponce';

@Component({
  selector: '[app-pasta-txt-user-from-sharing]',
  templateUrl: './pasta-txt-user-from-sharing.component.html',
  styleUrl: './pasta-txt-user-from-sharing.component.css'
})
export class PastaTxtUserFromSharingComponent {
  @Input('app-pasta-txt-user-from-sharing') pastatxt!: PastaTextResponse;
}
