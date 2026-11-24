import { Injectable } from '@angular/core';
import { AdminLoginResponseDto } from '../Auth/admin-login/admin-login';

@Injectable({
  providedIn: 'root'
})
export class Token {

  private tokenKey = 'token';

  saveSession(response: AdminLoginResponseDto): void {
    sessionStorage.setItem(this.tokenKey, response.token);
  }

  getToken(): string | null {
    return sessionStorage.getItem(this.tokenKey);
  }

  clearSession(): void {
    sessionStorage.removeItem(this.tokenKey);
  }
}