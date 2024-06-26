import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PastaHistoryResponse } from './model/pastaHistoryResponce.interface';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root',
})
// Serwis odpowiedzialny za wspólne rzeczy - historia oraz usuwanie
export class PastaService {
  constructor(
    private httpClient: HttpClient,
    private authservice: AuthService
  ) {}
  private startURL: string = 'https://localhost:7023/Pasta';

  deletePasta(pastaBindID: number): Observable<void> {
    return this.httpClient.delete<void>(
      this.startURL + '/delete/' + pastaBindID
    );
  }
  getPastaHistory(
    pastaBindID: string | null
  ): Observable<PastaHistoryResponse[]> {
    return this.httpClient.get<PastaHistoryResponse[]>(
      this.startURL + '/history/' + pastaBindID
    );
  }
}
