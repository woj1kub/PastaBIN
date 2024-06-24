import { Component, Input, OnInit } from '@angular/core';
import { PastaSharingSettingsService } from '../pasta-sharing-settings.service';
import { PastaSharingSettingsResponse } from '../model/pastaSharingSettingsResponce.interface';
import { PastaSharingSettingsRequest } from '../model/pastaSharingSettingsRequest';

@Component({
  selector: 'app-pasta-sharing-settings',
  templateUrl: './pasta-sharing-settings.component.html',
  styleUrls: ['./pasta-sharing-settings.component.css']
})
export class PastaSharingSettingsComponent implements OnInit {
  @Input() IDBind!: string | null;
  cookLogin: string = '';
  endSharingDate: string = '';

  data: PastaSharingSettingsResponse[] = [];

  constructor(private pss: PastaSharingSettingsService) {}

  ngOnInit(): void {
    this.getData();
  }
  
  addPastaSharingSetting() {
    const newPastaSharingSetting: PastaSharingSettingsRequest = {
      cookLogin: this.cookLogin,
      endSharingDate: this.endSharingDate,
      pastaBindID: Number(this.IDBind)
    };
    this.pss.addPastaSharingSettings(newPastaSharingSetting).subscribe;
    this.cookLogin = '';
    this.endSharingDate = '';
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
  