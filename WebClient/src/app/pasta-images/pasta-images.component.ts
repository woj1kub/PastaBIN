import { ChangeDetectorRef, Component } from '@angular/core';
import { PastaImagesService } from '../pasta-images.service';
import { PastaImageResponseWithoutImage } from '../model/PastaImageResponseWithoutImage.interface';
import { PastaImageResponse } from '../model/pastaImageResponce.interface';

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
    this.servicePastaImage.getPastaImageByUser().subscribe({
      next: (res: PastaImageResponseWithoutImage[]) => {
        this.data = res.map(item => ({
          idBind: item.idBind,
          image: '',
          key: item.key,
          deleteDate: item.deleteDate,
          creationDate: item.creationDate
        }));

        this.loadImages(this.data);
      },
      error: (err) => console.error(err),
      complete: () => console.log('Complete')
    });
  }

  private getDataFromSharing(): void {
    this.servicePastaImage.getPastaImageByUserFromSharing().subscribe({
      next: (res: PastaImageResponseWithoutImage[]) => {
        this.dataFromSharing = res.map(item => ({
          idBind: item.idBind,
          image: '',
          key: item.key,
          deleteDate: item.deleteDate,
          creationDate: item.creationDate
        }));
        this.loadImages(this.dataFromSharing);
      },
      error: (err) => console.error(err),
      complete: () => console.log('Complete')
    });
  }

  private loadImages(data: PastaImageResponse[]): void {
    data.forEach(item => {
      this.readPasta(item.idBind, item);
    });
  }

  private readPasta(bindID: number, item: PastaImageResponse): void {
    this.servicePastaImage.getPastaImageByBindID(bindID).subscribe({
      next: (response: Blob) => {
        this.readFile(response, item);
      },
      error: (error) => {
        console.error('Error reading image:', error);
      }
    });
  }

  private readFile(blob: Blob, item: PastaImageResponse): void {
    const reader = new FileReader();
    reader.onload = () => {
      item.image = reader.result as string;
      this.cdr.detectChanges();
    };
    reader.readAsDataURL(blob);
  }
  
  public handlePastaDeleted(): void {
    // Re-fetch data after deletion
    this.getData();
    this.getDataFromSharing();
  }
}
