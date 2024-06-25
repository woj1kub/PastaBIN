import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PastaSharingSettingsRequest } from './model/pastaSharingSettingsRequest';
import { PastaSharingSettingsResponse } from './model/pastaSharingSettingsResponce.interface';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class PastaSharingSettingsService {

  constructor(private httpClient:HttpClient, private authservice:AuthService) { }
  private startURL:string='https://localhost:7023/PastaSharingSettings';
  addPastaSharingSettings(pastasharing : PastaSharingSettingsRequest ):Observable<void>
  {
    return this.httpClient.post<void>(this.startURL +'/add/' +this.authservice.getUserID() , pastasharing, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }
  UpdatePastaSharingSettings(date:string,pastaGroupID: string|null ):Observable<void>
  {
    return this.httpClient.post<void>(this.startURL +'/update/'+this.authservice.getUserID()+'/'+pastaGroupID, date, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }
  deletePastaSharingSettings(pastaGroupID: string|null):Observable<void>
  {
    return this.httpClient.delete<void>(this.startURL+'/delete/'+ this.authservice.getUserID() +'/'+ pastaGroupID);
  }
  getPastaSharingSettings(pastaBindID: string|null):Observable<PastaSharingSettingsResponse[]>
  {
    return this.httpClient.get<PastaSharingSettingsResponse[]>(this.startURL+'/get/'+ this.authservice.getUserID() +'/'+ pastaBindID);
  }
}
