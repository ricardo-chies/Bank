import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ExtratoService {
  private apiUrl = 'https://localhost:44324/api/v1.0/contas/extrato/';

  constructor(private http: HttpClient) {}

  buscarExtrato(numeroConta: number, dataInicio: string, dataFim: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}${numeroConta}/${dataInicio}/${dataFim}`);
  }
}
