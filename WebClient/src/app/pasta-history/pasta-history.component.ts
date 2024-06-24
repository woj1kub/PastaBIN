import { Component, Input } from '@angular/core';
import { PastaHistoryResponse } from '../model/pastaHistoryResponce.interface';
import { PastaService } from '../pasta.service';

@Component({
  selector: 'app-pasta-history',
  templateUrl: './pasta-history.component.html',
  styleUrl: './pasta-history.component.css'
})
export class PastaHistoryComponent {
  @Input() IDBind!:string|null;
  data:PastaHistoryResponse[]=[];
  constructor(private ps:PastaService){
    this.getData();
  }

  private getData():void{
    
    this.ps.getPastaHistory(this.IDBind).subscribe({
      next: (res) =>{
        this.data=res;
      },
      error: (err) => console.error(err),
      complete:()=> console.log('complete')
    });
  }
}
