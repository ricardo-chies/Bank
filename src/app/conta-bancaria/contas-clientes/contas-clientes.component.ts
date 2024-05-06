import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-contas-clientes',
  templateUrl: './contas-clientes.component.html',
  styleUrls: ['./contas-clientes.component.css']
})
export class ContasClientesComponent implements OnInit {
  clientes: any[] = []; // Inicialize a propriedade com um array vazio

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.obterClientesSaldos();
  }

  obterClientesSaldos() {
    this.http.get<any[]>('https://localhost:44324/api/v1.0/contas/saldos')
      .subscribe(data => {
        this.clientes = data;
      });
  }
}