import { ChangeDetectorRef, Component } from '@angular/core';

@Component({
  selector: 'app-pasta-user',
  templateUrl: './pasta-user.component.html',
  styleUrl: './pasta-user.component.css'
})
export class PastaUserComponent {
  constructor(private cdr: ChangeDetectorRef) {}
  showTextComponent: string = 'true';
  toggleComponent(value: string) {
    this.showTextComponent = value;
    this.cdr.detectChanges(); // ręczne odświeżenie widoku
  }
}

