import { Component } from '@angular/core';
import { PastaTextsService } from '../pasta-texts.service';
import { PastaTextResponse } from '../model/pastaTextResponce';

@Component({
  selector: 'app-pasta-txt',
  templateUrl: './pasta-txt.component.html',
  styleUrl: './pasta-txt.component.css'
})
export class PastaTxtComponent {
  text: string = '';

  constructor(private servicePastaText: PastaTextsService) { }

  readPasta() {
    
    if (this.key !== '') {
      this.servicePastaText.getPastaTextByKey(this.key).subscribe({
        next: (response: PastaTextResponse) => {
          this.text = response.content; 
        },
        error: (error) => {
          console.error(error);
        }
      });
    }
  }

  key: string = '';
}
