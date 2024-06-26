import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PastaTextRequest } from './model/pastaTextRequst.interface';
import { PastaTextResponse } from './model/pastaTextResponce';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root',
})
export class PastaTextsService {
  constructor(
    private httpClient: HttpClient,
    private authservice: AuthService
  ) {}
  private startURL: string = 'https://localhost:7023/PastaTxt';
  addPastaText(pastaText: PastaTextRequest): Observable<string> {
    return this.httpClient.post<string>(
      this.startURL + '/add/' + this.authservice.getUserID(),
      pastaText,
      {
        headers: new HttpHeaders({
          'Content-Type': 'application/json',
        }),
      }
    );
  }
  getPastaTextByUser(): Observable<PastaTextResponse[]> {
    return this.httpClient.get<PastaTextResponse[]>(
      this.startURL + '/getByUser/' + this.authservice.getUserID()
    );
  }
  getPastaTextByUserFromSharing(): Observable<PastaTextResponse[]> {
    return this.httpClient.get<PastaTextResponse[]>(
      this.startURL + '/getByUserFromSharing/' + this.authservice.getUserID()
    );
  }
  getPastaTextByKey(key: string): Observable<PastaTextResponse> {
    return this.httpClient.get<PastaTextResponse>(
      this.startURL + '/getByKey/' + key + '/' + this.authservice.getUserID()
    );
  }
}
