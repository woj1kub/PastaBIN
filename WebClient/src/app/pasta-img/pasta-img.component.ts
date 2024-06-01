import { ChangeDetectorRef, Component } from '@angular/core';
import { PastaImagesService } from '../pasta-images.service';
import { PastaImageResponse } from '../model/pastaImageResponce.interface';

@Component({
  selector: 'app-pasta-img',
  templateUrl: './pasta-img.component.html',
  styleUrls: ['./pasta-img.component.css']
})
export class PastaImgComponent {
  imageSrc: string | null = null; // Zmienna przechowująca zdekodowany obraz

  constructor(private servicePastaImage: PastaImagesService,private cdr: ChangeDetectorRef) { }

  readPasta() {
    if (this.key.trim() !== '') {
      this.servicePastaImage.getPastaImageByKey(this.key, 0).subscribe({
        next: (response: PastaImageResponse) => {
          // Dekodowanie base64 stringa do formatu Data URI
          this.imageSrc = 'data:image/png;base64,' + response.image;
        },
        error: (error) => {
          console.error('Wystąpił błąd podczas odczytu obrazu:', error);
        }
      });
    } else {
      console.warn('Klucz nie może być pusty.');
    }
    this.cdr.detectChanges(); // ręczne odświeżenie widoku

  }

  key: string = ''; // Klucz pobierany z formularza
}
