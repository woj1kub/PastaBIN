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
  onSettingsClick() {
    throw new Error('Method not implemented.');
  }
  onDeleteClick() {
    throw new Error('Method not implemented.');
  }
  constructor(private servicePastaImage: PastaImagesService,private cdr: ChangeDetectorRef) { }

}
