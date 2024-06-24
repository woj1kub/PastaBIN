import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PastaImageRequest } from './model/pastaImageRequst.interface';
import { Observable } from 'rxjs';
import { PastaImageResponseWithoutImage } from './model/PastaImageResponseWithoutImage.interface';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class PastaImagesService {


  constructor(private httpClient: HttpClient, private authservice:AuthService) { }
  private startURL: string = 'https://localhost:7023/PastaImg';

  addPastaImage(pastaImage: PastaImageRequest): Observable<string> {
    return this.httpClient.post<string>(`${this.startURL}/add/${this.authservice.getUserID()}`, pastaImage, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }

  getPastaImageByUser(): Observable<PastaImageResponseWithoutImage[]> {
    return this.httpClient.get<PastaImageResponseWithoutImage[]>(`${this.startURL}/getByUser/${this.authservice.getUserID()}`);
  }
  
  getPastaImageByKey(key: string): Observable<Blob> {
    return this.httpClient.get(`${this.startURL}/getByKey/${key}/${this.authservice.getUserID()}`, { responseType: 'blob' });
  }
  getPastaImageByBindID(bindID: number): Observable<Blob> {
    return this.httpClient.get(`${this.startURL}/getByBindID/${bindID}`, { responseType: 'blob' });
  }
  
  getPastaImageByUserFromSharing(): Observable<PastaImageResponseWithoutImage[]> {
    return this.httpClient.get<PastaImageResponseWithoutImage[]>(`${this.startURL}/getByUserFromPastaSharing/${this.authservice.getUserID()}`);
  }
}
