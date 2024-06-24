import { ChangeDetectorRef, Component } from '@angular/core';
import { PastaImagesService } from '../pasta-images.service';

@Component({
  selector: 'app-pasta-img',
  templateUrl: './pasta-img.component.html',
  styleUrls: ['./pasta-img.component.css']
})
export class PastaImgComponent {
  imageSrc: string | null = null; // Zmienna przechowująca zdekodowany obraz

  constructor(private servicePastaImage: PastaImagesService, private cdr: ChangeDetectorRef) { }

  readPasta() {
    if (this.key.trim() !== '') {
      this.servicePastaImage.getPastaImageByKey(this.key).subscribe({
        next: (response: Blob) => {
          this.readFile(response); // Obsługa przetworzonego strumienia binarnego
        },
        error: (error) => {
          console.error('Wystąpił błąd podczas odczytu obrazu:', error);
        }
      });
    } else {
      console.warn('Klucz nie może być pusty.');
    }
  }

  key: string = ''; // Klucz pobierany z formularza

  // Funkcja do przetwarzania strumienia binarnego na obraz
  private readFile(blob: Blob) {
    const reader = new FileReader();
    reader.onload = () => {
      this.imageSrc = reader.result as string;
      this.cdr.detectChanges(); // Ręczne odświeżenie widoku
    };
    reader.readAsDataURL(blob);
  }
}
