import { Component, Input } from '@angular/core';
import { PastaSharingSettingsService } from '../pasta-sharing-settings.service';
import { PastaSharingSettingsResponse } from '../model/pastaSharingSettingsResponce.interface';

@Component({
  selector: 'app-pasta-sharing-settings',
  templateUrl: './pasta-sharing-settings.component.html',
  styleUrl: './pasta-sharing-settings.component.css'
})
export class PastaSharingSettingsComponent {
  @Input() IDBind!:string|null;
  data:PastaSharingSettingsResponse[]=[];
  constructor(private pss:PastaSharingSettingsService){
    this.getData();
  }

  private getData():void{
    
    this.pss.getPastaSharingSettings(1 , this.IDBind).subscribe({
      next: (res) =>{
        this.data=res;
      },
      error: (err) => console.error(err),
      complete:()=> console.log('complete')
    });
  }
  
}
