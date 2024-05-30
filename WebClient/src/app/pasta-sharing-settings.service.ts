import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PastaSharingSettingsRequest } from './model/pastaSharingSettingsRequest.interface';
import { PastaSharingSettingsResponse } from './model/pastaSharingSettingsResponce.interface';

@Injectable({
  providedIn: 'root'
})
export class PastaSharingSettingsService {

  constructor(private httpClient:HttpClient) { }
  private startURL:string='https://localhost:7023/PastaSharingSettings';
  addPastaSharingSettings(pastaImage : PastaSharingSettingsRequest ):Observable<void>
  {
    return this.httpClient.post<void>(this.startURL +'/add/', pastaImage, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }
  UpdatePastaSharingSettings(date:string,cookID: number,pastaGroupID: number ):Observable<void>
  {
    return this.httpClient.post<void>(this.startURL +'/update/'+cookID+'/'+pastaGroupID, date, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }
  deletePastaSharingSettings(cookID: number,pastaGroupID: number):Observable<void>
  {
    return this.httpClient.delete<void>(this.startURL+'/delete/'+ cookID +'/'+ pastaGroupID);
  }
  getPastaSharingSettings(cookID: number,pastaGroupID: number):Observable<PastaSharingSettingsResponse>
  {
    return this.httpClient.delete<PastaSharingSettingsResponse>(this.startURL+'/get/'+ cookID +'/'+ pastaGroupID);
  }
}
