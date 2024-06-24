import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PastaGroupSharingRequest } from './model/pastaGroupSharingRequest.interface';
import { Observable } from 'rxjs';
import { PastaGroupSharingResponse } from './model/pastaGroupSharingResponce.interface';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class PastaSharingGroupsService {
  constructor(private httpClient:HttpClient , private authservice:AuthService) { }
  private startURL:string='https://localhost:7023/PastaGroupSharing';
  addPastaGroupSharing(pastagroup : PastaGroupSharingRequest ):Observable<string>
  {
    return this.httpClient.post<string>(this.startURL +'/add/'+ this.authservice.getUserID(), pastagroup, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }

  UpdatePastaGroupSharing(date:string,pastaGroupID:  string|null ):Observable<void>
  {
    return this.httpClient.post<void>(this.startURL +'/update/'+this.authservice.getUserID()+'/'+pastaGroupID, date, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }
  deletePastaGroupSharing(pastaGroupID:  string|null):Observable<void>
  {
    return this.httpClient.delete<void>(this.startURL+'/delete/'+ this.authservice.getUserID() +'/'+ pastaGroupID);
  }
  getPastaGroupSharing(pastaBindID: string|null):Observable<PastaGroupSharingResponse[]>
  {
    return this.httpClient.get<PastaGroupSharingResponse[]>(this.startURL+'/get/'+ pastaBindID +'/'+ this.authservice.getUserID());
  }

}
