import { Component,ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrl: './settings.component.css'
})
export class SettingsComponent {
  constructor(private cdr: ChangeDetectorRef) {}
  showTextComponent: string = '0';
  toggleComponent(value: string) {
    this.showTextComponent = value;
    this.cdr.detectChanges();
  }
}
