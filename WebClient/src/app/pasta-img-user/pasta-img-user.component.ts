import { ChangeDetectorRef, Component, Input } from '@angular/core';
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
  constructor(private router: Router , private pastaservice:PastaService) { }

  public onSettingsClick():void {
    this.router.navigate(['/pastaSettings/'+this.pastaimg.idBind])
  }
  public onDeleteClick():void {
    this.pastaservice.deletePasta(this.pastaimg.idBind)
  }
}
