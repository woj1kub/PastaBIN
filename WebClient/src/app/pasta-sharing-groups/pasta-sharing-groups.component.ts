import { Component, Input } from '@angular/core';
import { PastaGroupSharingResponse } from '../model/pastaGroupSharingResponce.interface';
import { PastaSharingGroupsService } from '../pasta-sharing-groups.service';

@Component({
  selector: 'app-pasta-sharing-groups',
  templateUrl: './pasta-sharing-groups.component.html',
  styleUrl: './pasta-sharing-groups.component.css'
})
export class PastaSharingGroupsComponent {
  @Input() IDBind!:string|null;
  data:PastaGroupSharingResponse[]=[];
  constructor(private pss:PastaSharingGroupsService){
    this.getData();
  }

  private getData():void{
    
    this.pss.getPastaGroupSharing(1 , this.IDBind).subscribe({
      next: (res) =>{
        this.data=res;
      },
      error: (err) => console.error(err),
      complete:()=> console.log('complete')
    });
  }
}
