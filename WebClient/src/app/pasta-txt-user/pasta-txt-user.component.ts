import { Component, Input } from '@angular/core';
import { PastaTextResponse } from '../model/pastaTextResponce';
import { Router } from '@angular/router';
import { PastaService } from '../pasta.service';

@Component({
  selector: '[app-pasta-txt-user]',
  templateUrl: './pasta-txt-user.component.html',
  styleUrl: './pasta-txt-user.component.css'
})
export class PastaTxtUserComponent {
  @Input('app-pasta-txt-user') pastatxt!: PastaTextResponse;
  constructor(private router: Router , private pastaservice:PastaService) { }

  public onSettingsClick():void {
    this.router.navigate(['/pastaSettings/'+this.pastatxt.idBind])
  }
  public onDeleteClick():void {
    this.pastaservice.deletePasta(this.pastatxt.idBind)
  }
}
