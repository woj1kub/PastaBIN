import { Component } from '@angular/core';
import { PastaTextsService } from '../pasta-texts.service';
import { PastaTextResponse } from '../model/pastaTextResponce';

@Component({
  selector: 'app-pasta-texts',
  templateUrl: './pasta-texts.component.html',
  styleUrls: ['./pasta-texts.component.css']
})
export class PastaTextsComponent {
  constructor(private servicePastaText: PastaTextsService) {
    this.getData();
    this.getDataFromSharing();
  }

  public data: PastaTextResponse[] = [];
  public dataFromSharing: PastaTextResponse[] = [];

  private getData(): void {
    this.servicePastaText.getPastaTextByUser().subscribe({
      next: (res) => {
        this.data = res;
      },
      error: (err) => console.error(err),
      complete: () => console.log('complete')
    });
  }

  private getDataFromSharing(): void {
    this.servicePastaText.getPastaTextByUserFromSharing().subscribe({
      next: (res) => {
        this.dataFromSharing = res;
      },
      error: (err) => console.error(err),
      complete: () => console.log('complete')
    });
  }

  public handlePastaDeleted(): void {
    // Re-fetch data after deletion
    this.getData();
    this.getDataFromSharing();
  }
}
