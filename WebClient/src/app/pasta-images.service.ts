import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PastaImageRequest } from './model/pastaImageRequst.interface';
import { Observable } from 'rxjs';
import { PastaImageResponseWithoutImage } from './model/PastaImageResponseWithoutImage.interface';

@Injectable({
  providedIn: 'root'
})
export class PastaImagesService {
  getPastaImageByUserFromSharing(cookID: number): Observable<PastaImageResponseWithoutImage[]> {
    return this.httpClient.get<PastaImageResponseWithoutImage[]>(`${this.startURL}/getByUserFromPastaSharing/${cookID}`);
  }

  constructor(private httpClient: HttpClient) { }
  private startURL: string = 'https://localhost:7023/PastaImg';

  addPastaImage(pastaImage: PastaImageRequest, cookID: number | null): Observable<string> {
    return this.httpClient.post<string>(`${this.startURL}/add/${cookID}`, pastaImage, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }

  getPastaImageByUser(cookID: number): Observable<PastaImageResponseWithoutImage[]> {
    return this.httpClient.get<PastaImageResponseWithoutImage[]>(`${this.startURL}/getByUser/${cookID}`);
  }
  
  getPastaImageByKey(key: string, cookID: number): Observable<Blob> {
    return this.httpClient.get(`${this.startURL}/getByKey/${key}/${cookID}`, { responseType: 'blob' });
  }
}
