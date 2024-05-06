import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-gerente',
  templateUrl: './gerente.component.html',
  styleUrls: ['./gerente.component.css']
})
export class GerenteComponent {

  constructor(private router: Router) { }

  buscarClientesSaldos() {
    this.router.navigate(['/contas-clientes']);
  }

  movimentarConta() {
    this.router.navigate(['/movimentar-conta']);
  }

  buscarExtratoCliente() {
    this.router.navigate(['/extrato-conta']);
  }

  criarConta() {
    this.router.navigate(['/criar-conta-bancaria']);
  }

  excluirConta() {
    this.router.navigate(['/excluir-conta-bancaria']);
  }
}