import { Component, Input, OnInit } from '@angular/core';
import { PastaGroupSharingResponse } from '../model/pastaGroupSharingResponce.interface';
import { PastaSharingGroupsService } from '../pasta-sharing-groups.service';
import { PastaGroupSharingRequest } from '../model/pastaGroupSharingRequest.interface';

@Component({
  selector: 'app-pasta-sharing-groups',
  templateUrl: './pasta-sharing-groups.component.html',
  styleUrls: ['./pasta-sharing-groups.component.css']
})
export class PastaSharingGroupsComponent implements OnInit {

  @Input() IDBind!: string | null;
  groupKey: string = '';
  endSharingDate: string = '';

  data: PastaGroupSharingResponse[] = [];
 
  constructor(private pss: PastaSharingGroupsService) {}
  Delete(arg0: number) {
    this.pss.deletePastaGroupSharing(arg0.toString()).subscribe();
    this.getData();
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
      },
      error: (err) => console.error(err),
      complete: () => console.log('complete')
    });
  }
}
