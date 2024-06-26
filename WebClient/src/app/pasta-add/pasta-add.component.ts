import { ChangeDetectorRef, Component } from '@angular/core';

@Component({
  selector: 'app-pasta-add',
  templateUrl: './pasta-add.component.html',
  styleUrl: './pasta-add.component.css',
})
export class PastaAddComponent {
  constructor(private cdr: ChangeDetectorRef) {}
  showTextComponent: string = 'true';
  toggleComponent(value: string) {
    this.showTextComponent = value;
    this.cdr.detectChanges();
  }
}
