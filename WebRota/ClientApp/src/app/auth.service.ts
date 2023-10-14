import { Injectable } from '@angular/core';

import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  public token: string | undefined;
  private baseUrl = 'https://localhost:7003/api/Users/login'; // URL do serviço de autenticação
  private isAuthenticated: boolean = false;
  constructor(private http: HttpClient) { }

  login(email: string, password: string): Observable<any> {
    const params = new HttpParams();
    var url = `${this.baseUrl}?email=${email}&password=${password}`;
    this.isAuthenticated = true;
    return this.http.post<any>(url,params);
  }

  isAuthenticatedUser() {
    return this.isAuthenticated;
  }

  getToken() {
    // Recupere o token de localStorage ou de onde você o armazenou.
    var token = localStorage.getItem('token');
    return token;
  }

  logout() {
    // Remova o token quando o usuário sair.
    localStorage.removeItem('token');
  }
}
