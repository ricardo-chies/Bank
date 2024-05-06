import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl: string = 'https://localhost:44324/api/v1.0/usuarios/login';

  constructor(private http: HttpClient) { }

  login(cpf: string, senha: string): Observable<any> {
    const url = `${this.baseUrl}?cpf=${cpf}&senha=${senha}`;
    return this.http.get<any>(url);
  }
}
