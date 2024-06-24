import { Component, Input, Output, EventEmitter } from '@angular/core';
import { PastaTextResponse } from '../model/pastaTextResponce';
import { Router } from '@angular/router';
import { PastaService } from '../pasta.service';

@Component({
  selector: '[app-pasta-txt-user]',
  templateUrl: './pasta-txt-user.component.html',
  styleUrls: ['./pasta-txt-user.component.css']
})
export class PastaTxtUserComponent {
  @Input('app-pasta-txt-user') pastatxt!: PastaTextResponse;
  @Output() pastaDeleted: EventEmitter<void> = new EventEmitter<void>();

  constructor(private router: Router, private pastaservice: PastaService) { }

  public onSettingsClick(): void {
    this.router.navigate(['/pastaSettings/' + this.pastatxt.idBind]);
  }

  public onDeleteClick(): void {
    console.log(this.pastatxt.idBind);
    this.pastaservice.deletePasta(this.pastatxt.idBind).subscribe(
      () => {
        console.log('Pasta została pomyślnie usunięta.');
        this.pastaDeleted.emit(); // Emit event on successful deletion
        this.router.navigate(['/pasty']); // Navigate to the list page
      },
      error => {
        console.error('Wystąpił błąd podczas usuwania pasty:', error);
      }
    );
  }
}
