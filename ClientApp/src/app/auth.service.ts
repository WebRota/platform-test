import { Injectable } from '@angular/core';

import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  public token: string | undefined;
  private baseUrl = environment.apiUrl; // URL do serviço de autenticação
  private isAuthenticated: boolean = false;
  constructor(private http: HttpClient) { }

  login(email: string, password: string): Observable<any> {
    const params = new HttpParams();

    var url = `${this.baseUrl}api/Users/login?email=${email}&password=${password}`;
    this.isAuthenticated = true;
    var response =  this.http.post<any>(url,params);    
    return response;
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
