import { ChangeDetectorRef, Component, EventEmitter, Input, Output } from '@angular/core';
import { PastaImagesService } from '../pasta-images.service';
import { PastaImageResponse } from '../model/pastaImageResponce.interface';
import { PastaService } from '../pasta.service';
import { Router } from '@angular/router';

@Component({
  selector: '[app-pasta-img-user]',
  templateUrl: './pasta-img-user.component.html',
  styleUrl: './pasta-img-user.component.css'
})
export class PastaImgUserComponent {
  @Input('app-pasta-img-user') pastaimg!: PastaImageResponse;
  @Output() pastaDeleted: EventEmitter<void> = new EventEmitter<void>();
  constructor(private router: Router , private pastaservice:PastaService) { }

  public onSettingsClick():void {
    this.router.navigate(['/pastaSettings/'+this.pastaimg.idBind])
  }
  public onDeleteClick(): void {
    console.log(this.pastaimg.idBind);
    this.pastaservice.deletePasta(this.pastaimg.idBind).subscribe(
      () => {
        console.log('Pasta została pomyślnie usunięta.');
        this.pastaDeleted.emit(); 
        this.router.navigate(['/pasty']);
      },
      error => {
        console.error('Wystąpił błąd podczas usuwania pasty:', error);
      }
    );
  }
  downloadImage() {
    if (this.pastaimg.image) {
      const link = document.createElement('a');
      link.href = this.pastaimg.image;
      link.download = 'pobrane_zdjecie.jpg';
  
      document.body.appendChild(link);
      link.click();
  
      document.body.removeChild(link);
    }
  }
}
