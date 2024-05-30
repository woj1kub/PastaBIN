import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { cookRequest } from './model/cookRequest.interface';

@Injectable({
  providedIn: 'root'
})
export class CookService {

  constructor(private httpClient:HttpClient) { }
  private startURL:string='https://localhost:7023/Cook';

  deleteCook(cookID: number):Observable<void>
  {
    return this.httpClient.delete<void>(this.startURL+'/delete/' + cookID);
  }

  addCook(cook : cookRequest):Observable<void>
  {
    return this.httpClient.post<void>(this.startURL +'/add/' , cook, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }

  updateCook(cookID:number,cook : cookRequest):Observable<void>
  {
    return this.httpClient.put<void>(this.startURL +'/update/'+cookID , cook, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }
  
}
