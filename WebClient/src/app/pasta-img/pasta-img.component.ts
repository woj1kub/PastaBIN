import { ChangeDetectorRef, Component } from '@angular/core';
import { PastaImagesService } from '../pasta-images.service';

@Component({
  selector: 'app-pasta-img',
  templateUrl: './pasta-img.component.html',
  styleUrls: ['./pasta-img.component.css']
})
export class PastaImgComponent {
  imageSrc: string | null = null;

  constructor(private servicePastaImage: PastaImagesService, private cdr: ChangeDetectorRef) { }

  readPasta() {
    if (this.key.trim() !== '') {
      this.servicePastaImage.getPastaImageByKey(this.key).subscribe({
        next: (response: Blob) => {
          this.readFile(response);
        },
        error: (error) => {
          console.error('Wystąpił błąd podczas odczytu obrazu:', error);
        }
      });
    } else {
      console.warn('Klucz nie może być pusty.');
    }
  }
  downloadImage() {
    if (this.imageSrc) {
      const link = document.createElement('a');
      link.href = this.imageSrc;
      link.download = 'pobrane_zdjecie.jpg';
  
      document.body.appendChild(link);
      link.click();
  
      document.body.removeChild(link);
    }
  }
  
  key: string = '';


  private readFile(blob: Blob) {
    const reader = new FileReader();
    reader.onload = () => {
      this.imageSrc = reader.result as string;
      this.cdr.detectChanges();
    };
    reader.readAsDataURL(blob);
  }
}
