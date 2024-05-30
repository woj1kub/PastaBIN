import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PastaImageRequest } from './model/pastaImageRequst.interface';
import { Observable } from 'rxjs';
import { PastaImageResponse } from './model/pastaImageResponce.interface';

@Injectable({
  providedIn: 'root'
})
export class PastaImagesService {

  constructor(private httpClient:HttpClient) { }
  private startURL:string='https://localhost:7023/PastaImg';
  addPastaImage(pastaImage : PastaImageRequest, cookID:number | null ):Observable<string>
  {
    return this.httpClient.post<string>(this.startURL +'/add/'+ cookID, pastaImage, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }
  getPastaImageByUser(cookID:number):Observable<PastaImageResponse>
  {
    return this.httpClient.get<PastaImageResponse>(this.startURL+'/getByUser/'+cookID);
  }
  
  getPastaImageByKey( key:string , cookID:number):Observable<PastaImageResponse>
  {
    return this.httpClient.get<PastaImageResponse>(this.startURL+'/getByUser/'+key+'/'+cookID);
  }
}
