import { Component } from '@angular/core';
import { PastaTextsService } from '../pasta-texts.service';
import { PastaTextResponse } from '../model/pastaTextResponce';

@Component({
  selector: 'app-pasta-texts',
  templateUrl: './pasta-texts.component.html',
  styleUrl: './pasta-texts.component.css'
})
export class PastaTextsComponent {
  constructor(private servicePastaText: PastaTextsService) {     
    this.getData();
  }
  public data: PastaTextResponse[]=[];

  private getData():void{
    
    this.servicePastaText.getPastaTextByUser(1).subscribe({
      next: (res) =>{
        this.data=res;
      },
      error: (err) => console.error(err),
      complete:()=> console.log('complete')
    });
  }
}
