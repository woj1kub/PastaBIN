import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PastaGroupSharingRequest } from './model/pastaGroupSharingRequest.interface';
import { Observable } from 'rxjs';
import { PastaGroupSharingResponse } from './model/pastaGroupSharingResponce.interface';

@Injectable({
  providedIn: 'root'
})
export class PastaSharingGroupsService {
  constructor(private httpClient:HttpClient) { }
  private startURL:string='https://localhost:7023/PastaGroupSharing';
  addPastaGroupSharing(pastaImage : PastaGroupSharingRequest ):Observable<void>
  {
    return this.httpClient.post<void>(this.startURL +'/add/', pastaImage, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }
  UpdatePastaGroupSharing(date:string,cookID: number,pastaGroupID:  string|null ):Observable<void>
  {
    return this.httpClient.post<void>(this.startURL +'/update/'+cookID+'/'+pastaGroupID, date, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }
  deletePastaGroupSharing(cookID: number,pastaGroupID:  string|null):Observable<void>
  {
    return this.httpClient.delete<void>(this.startURL+'/delete/'+ cookID +'/'+ pastaGroupID);
  }
  getPastaGroupSharing(cookID: number,pastaBindID: string|null):Observable<PastaGroupSharingResponse[]>
  {
    return this.httpClient.get<PastaGroupSharingResponse[]>(this.startURL+'/get/'+ cookID +'/'+ pastaBindID);
  }

}
