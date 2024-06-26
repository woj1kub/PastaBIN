import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { cookRequest } from './model/cookRequest.interface';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root',
})
export class CookService {
  constructor(
    private httpClient: HttpClient,
    private authservice: AuthService
  ) {}
  private startURL: string = 'https://localhost:7023/Cook';

  deleteCook(): Observable<void> {
    return this.httpClient.delete<void>(
      this.startURL + '/delete/' + this.authservice.getUserID()
    );
  }

  addCook(cook: cookRequest): Observable<void> {
    return this.httpClient.post<void>(this.startURL + '/add/', cook, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
    });
  }

  updateCook(cook: cookRequest): Observable<void> {
    return this.httpClient.put<void>(
      this.startURL + '/update/' + this.authservice.getUserID(),
      cook,
      {
        headers: new HttpHeaders({
          'Content-Type': 'application/json',
        }),
      }
    );
  }
}
