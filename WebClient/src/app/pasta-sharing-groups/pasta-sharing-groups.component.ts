import { Component, Input, OnInit } from '@angular/core';
import { PastaGroupSharingResponse } from '../model/pastaGroupSharingResponce.interface';
import { PastaSharingGroupsService } from '../pasta-sharing-groups.service';
import { PastaGroupSharingRequest } from '../model/pastaGroupSharingRequest.interface';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-pasta-sharing-groups',
  templateUrl: './pasta-sharing-groups.component.html',
  styleUrls: ['./pasta-sharing-groups.component.css'],
  providers: [DatePipe]

})
export class PastaSharingGroupsComponent implements OnInit {

  @Input() IDBind!: string | null;
  groupKey: string = '';
  endSharingDate: string = '';
  minDate: string;

  data: PastaGroupSharingResponse[] = [];
 
  constructor(private pss: PastaSharingGroupsService,
    private datePipe: DatePipe) {
      const now = new Date();
      const future = new Date(now.getTime() + 2 * 60000);
      this.minDate = this.datePipe.transform(future, 'yyyy-MM-ddTHH:mm') || '';
      this.endSharingDate = this.datePipe.transform(future, 'yyyy-MM-ddTHH:mm') || '';
  }
  Delete(arg0: number) {
    this.pss.deletePastaGroupSharing(arg0.toString()).subscribe({
      next: () => {
        console.log(`Item with ID ${arg0} deleted successfully`);
        this.getData(); 
      },
      error: (err) => {
        console.error(`Error deleting item with ID ${arg0}: `, err);
      }
    });
  }
  
  ngOnInit(): void {
    this.getData();
  }

  addGroupSharing() {
    const dateObject = new Date(this.endSharingDate);

    const newPastagroup: PastaGroupSharingRequest = {
      endSharingDate: dateObject,
      pastaBindID: Number(this.IDBind)
    };

    this.pss.addPastaGroupSharing(newPastagroup).subscribe({
      next: (Key: any) => {
        this.groupKey = Key.key;
        this.getData();
      },
      error: (error) => {
        console.error(error);
      }
    });

    this.endSharingDate = '';
  }

  private getData(): void {
    this.pss.getPastaGroupSharing(this.IDBind).subscribe({
      next: (res) => {
        this.data = res;
        const now = new Date();
        const future = new Date(now.getTime() + 2 * 60000);
        this.minDate = this.datePipe.transform(future, 'yyyy-MM-ddTHH:mm') || '';
        this.endSharingDate = this.datePipe.transform(future, 'yyyy-MM-ddTHH:mm') || '';
      },
      error: (err) => console.error(err),
      complete: () => console.log('complete')
    });
  }
}
