import { ChangeDetectorRef, Component } from '@angular/core';
import { PastaImagesService } from '../pasta-images.service';

@Component({
  selector: 'app-pasta-img-user',
  templateUrl: './pasta-img-user.component.html',
  styleUrl: './pasta-img-user.component.css'
})
export class PastaImgUserComponent {
  constructor(private servicePastaImage: PastaImagesService,private cdr: ChangeDetectorRef) { }

}
