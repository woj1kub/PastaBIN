import { ChangeDetectorRef, Component } from '@angular/core';
import { PastaImageResponse } from '../model/pastaImageResponce.interface';
import { PastaImagesService } from '../pasta-images.service';
import { PastaImageResponseWithoutImage } from '../model/PastaImageResponseWithoutImage.interface';

@Component({
  selector: 'app-pasta-images',
  templateUrl: './pasta-images.component.html',
  styleUrls: ['./pasta-images.component.css']
})
export class PastaImagesComponent {
  constructor(private servicePastaImage: PastaImagesService, private cdr: ChangeDetectorRef) {     
    this.getData();
    this.getDataFromSharing();
  }

  public data: PastaImageResponse[] = [];
  public dataFromSharing: PastaImageResponse[] = [];

  private getData(): void {
    this.servicePastaImage.getPastaImageByUser(1).subscribe({
      next: (res: PastaImageResponseWithoutImage[]) => {
        this.data = res.map(item => ({
          idBind: item.idBind,
          image: '', // Zostanie uzupełnione później
          key: item.key,
          deleteDate: item.deleteDate,
          creationDate: item.creationDate
        }));

        // Wczytanie obrazów
        this.loadImages(this.data);
      },
      error: (err) => console.error(err),
      complete: () => console.log('complete')
    });
  }
  private getDataFromSharing(): void {
    this.servicePastaImage.getPastaImageByUserFromSharing(1).subscribe({
      next: (res: PastaImageResponseWithoutImage[]) => {
        this.dataFromSharing = res.map(item => ({
          idBind: item.idBind,
          image: '', // Zostanie uzupełnione później
          key: item.key,
          deleteDate: item.deleteDate,
          creationDate: item.creationDate
        }));

        // Wczytanie obrazów
        this.loadImages(this.dataFromSharing);
      },
      error: (err) => console.error(err),
      complete: () => console.log('complete')
    });
  }

  private loadImages(data:PastaImageResponse[]): void {
    data.forEach(item => {
      this.readPasta(item.idBind, item);
    });
  }

  private readPasta(bindID: number, item: PastaImageResponse): void {
      this.servicePastaImage.getPastaImageByBindID(bindID).subscribe({
        next: (response: Blob) => {
          this.readFile(response, item); // Obsługa przetworzonego strumienia binarnego
        },
        error: (error) => {
          console.error('Wystąpił błąd podczas odczytu obrazu:', error);
        }
      });
    
  }

  // Funkcja do przetwarzania strumienia binarnego na obraz
  private readFile(blob: Blob, item: PastaImageResponse): void {
    const reader = new FileReader();
    reader.onload = () => {
      item.image = reader.result as string;
      this.cdr.detectChanges(); // Ręczne odświeżenie widoku
    };
    reader.readAsDataURL(blob);
  }
}
