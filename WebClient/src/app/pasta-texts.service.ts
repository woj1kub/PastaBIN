import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PastaTextRequest } from './model/pastaTextRequst.interface';
import { PastaTextResponse } from './model/pastaTextResponce';

@Injectable({
  providedIn: 'root'
})
export class PastaTextsService {

  constructor(private httpClient:HttpClient) { }
  private startURL:string='https://localhost:7023/PastaTxt';
  addPastaText(pastaText : PastaTextRequest , cookID:number | null ):Observable<string>
  {
    return this.httpClient.post<string>(this.startURL +'/add/'+cookID, pastaText, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }
  getPastaTextByUser(cookID:number):Observable<PastaTextResponse[]>
  {
    return this.httpClient.get<PastaTextResponse[]>(this.startURL+'/getByUser/'+cookID);
  }
  
  getPastaTextByKey( key:string , cookID:number):Observable<PastaTextResponse>
  {
    return this.httpClient.get<PastaTextResponse>(this.startURL+'/getByKey/'+key+'/'+cookID);
  }
}
