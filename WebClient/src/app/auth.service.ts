import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

export interface DecodeToken {
  'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'?: string;
  'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'?: string;
}

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private jwtHelper: JwtHelperService) {}

  IsUserAuthenticated(): boolean {
    const token = localStorage.getItem('jwt');
    return !!token && !this.jwtHelper.isTokenExpired(token);
  }

  private getDecodedToken(): DecodeToken | null {
    const token = localStorage.getItem('jwt');
    if (token) {
      try {
        return this.jwtHelper.decodeToken(token);
      } catch (error) {
        console.error('Invalid token:', error);
        return null;
      }
    }
    return null;
  }

  getUserID(): string {
    const decodedToken = this.getDecodedToken();
    return decodedToken &&
      decodedToken[
        'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'
      ]
      ? decodedToken[
          'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'
        ]!
      : '0';
  }

  getUserName(): string {
    const decodedToken = this.getDecodedToken();
    return decodedToken &&
      decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name']
      ? decodedToken[
          'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'
        ]!
      : '';
  }

  logOut() {
    localStorage.removeItem('jwt');
  }
}
