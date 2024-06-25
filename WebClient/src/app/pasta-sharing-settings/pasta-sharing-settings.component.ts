import { Component, Input, OnInit } from '@angular/core';
import { PastaSharingSettingsService } from '../pasta-sharing-settings.service';
import { PastaSharingSettingsResponse } from '../model/pastaSharingSettingsResponce.interface';
import { PastaSharingSettingsRequest } from '../model/pastaSharingSettingsRequest';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-pasta-sharing-settings',
  templateUrl: './pasta-sharing-settings.component.html',
  styleUrls: ['./pasta-sharing-settings.component.css'],
  providers: [DatePipe]
})
export class PastaSharingSettingsComponent implements OnInit {

  @Input() IDBind!: string | null;
  cookLogin: string = '';
  endSharingDate: string = '';
  minDate: string;

  data: PastaSharingSettingsResponse[] = [];

  constructor(
    private pss: PastaSharingSettingsService,
    private datePipe: DatePipe
  ) {
    const now = new Date();
    const future = new Date(now.getTime() + 2 * 60000);
    this.minDate = this.datePipe.transform(future, 'yyyy-MM-ddTHH:mm') || '';
    this.endSharingDate = this.datePipe.transform(future, 'yyyy-MM-ddTHH:mm') || '';
  }

  ngOnInit(): void {
    this.getData();
  }
  Delete(arg0: number) {
    this.pss.deletePastaSharingSettings(arg0.toString()).subscribe(
      () => {
        console.log(`Deleted item with ID ${arg0} successfully`);
        this.getData(); 
      },
      error => {
        console.error(`Error deleting item with ID ${arg0}:`, error);
      }
    );
  }
  addPastaSharingSetting() {
    const dateObject = new Date(this.endSharingDate);

    const newPastaSharingSetting: PastaSharingSettingsRequest = {
      cookLogin: this.cookLogin,
      endSharingDate: dateObject,
      pastaBindID: Number(this.IDBind)
    };
    
    console.log(newPastaSharingSetting.cookLogin);
    console.log(newPastaSharingSetting.endSharingDate);
    console.log(newPastaSharingSetting.pastaBindID);
    this.pss.addPastaSharingSettings(newPastaSharingSetting).subscribe({
      next: () => {
          this.cookLogin = '';
          this.getData();
      },
      error: (err) => console.error('Error occurred:', err)
  });
  }

  private getData(): void {
    this.pss.getPastaSharingSettings(this.IDBind).subscribe({
      next: (res) => {
        this.data = res;
      },
      error: (err) => console.error(err),
      complete: () => console.log('complete')
    });
  }
  
}
  