import { ChangeDetectorRef, Component, Input } from '@angular/core';
import { PastaImagesService } from '../pasta-images.service';
import { PastaImageResponse } from '../model/pastaImageResponce.interface';

@Component({
  selector: '[app-pasta-img-user-from-sharing]',
  templateUrl: './pasta-img-user-from-sharing.component.html',
  styleUrl: './pasta-img-user-from-sharing.component.css'
})
export class PastaImgUserFromSharingComponent {
  @Input('app-pasta-img-user-from-sharing') pastaimg!: PastaImageResponse;

  downloadImage() {
    if (this.pastaimg.image) {
      // Tworzymy link do obrazu
      const link = document.createElement('a');
      link.href = this.pastaimg.image;
      link.download = 'pobrane_zdjecie.jpg'; // Nazwa pliku do pobrania
  
      // Dodajemy link do DOM, aby móc uruchomić pobieranie
      document.body.appendChild(link);
      link.click();
  
      // Usuwamy link po pobraniu
      document.body.removeChild(link);
    }
  }
}
