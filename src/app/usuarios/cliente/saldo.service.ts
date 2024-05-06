import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SaldoService {
  private apiUrl = 'https://localhost:44324/api/v1.0/contas/saldos/';

  constructor(private http: HttpClient) {}

  buscarSaldo(cpf: string): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}${cpf}`);
  }
}
