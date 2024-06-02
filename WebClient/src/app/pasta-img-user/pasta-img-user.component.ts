import { ChangeDetectorRef, Component, Input } from '@angular/core';
import { PastaImagesService } from '../pasta-images.service';
import { PastaImageResponse } from '../model/pastaImageResponce.interface';

@Component({
  selector: '[app-pasta-img-user]',
  templateUrl: './pasta-img-user.component.html',
  styleUrl: './pasta-img-user.component.css'
})
export class PastaImgUserComponent {
  @Input('app-pasta-img-user') pastaimg!: PastaImageResponse;
  onSettingsClick() {
    throw new Error('Method not implemented.');
  }
  onDeleteClick() {
    throw new Error('Method not implemented.');
  }
  constructor(private servicePastaImage: PastaImagesService,private cdr: ChangeDetectorRef) { }

}
