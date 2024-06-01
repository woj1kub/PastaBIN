import { ChangeDetectorRef, Component } from '@angular/core';

@Component({
  selector: 'app-pasta',
  templateUrl: './pasta.component.html',
  styleUrl: './pasta.component.css'
})
export class PastaComponent {
  constructor(private cdr: ChangeDetectorRef) {}
  showTextComponent: string = 'true';
  toggleComponent(value: string) {
    this.showTextComponent = value;
    this.cdr.detectChanges(); // ręczne odświeżenie widoku
  }
}
