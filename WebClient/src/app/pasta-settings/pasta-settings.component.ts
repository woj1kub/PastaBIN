import { ChangeDetectorRef, Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-pasta-settings',
  templateUrl: './pasta-settings.component.html',
  styleUrl: './pasta-settings.component.css'
})
export class PastaSettingsComponent {
  constructor(private cdr: ChangeDetectorRef,private route: ActivatedRoute) {}
  id!: string | null;
  showTextComponent: string = '0';
  toggleComponent(value: string) {
    this.showTextComponent = value;
    this.cdr.detectChanges();
  }
  
  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.id = params.get('pastaID');
    });
  }
}
