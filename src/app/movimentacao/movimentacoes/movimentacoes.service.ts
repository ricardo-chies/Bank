import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MovimentacoesService {
  private apiUrl = 'https://localhost:44324/api/v1.0/contas/';

  constructor(private http: HttpClient) {}

  buscarMovimentacoes(conta: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}${conta}/movimentacoes`);
  }
}
