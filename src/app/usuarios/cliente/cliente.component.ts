import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SaldoService } from './saldo.service';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.css']
})
export class ClienteComponent implements OnInit {
  nome: string | null = null;
  cpf: string | null = null;
  conta: number | null = null;
  saldo: number | null = null;
  codigoTipoUsuario: number | null = null;
  saldoOculto: boolean = true;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private saldoService: SaldoService
  ) {}

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.nome = params['nome'] || null;
      this.cpf = params['cpf'] || null;
      this.codigoTipoUsuario = params['codigoTipoUsuario'] || null;
      if (this.nome && this.cpf) {
        this.buscarSaldo();
      }
    });
  }

  buscarSaldo() {
    this.saldoService.buscarSaldo(this.cpf!).subscribe(
      (response) => {
        this.saldo = response?.saldo || null;
        this.conta = response?.conta || null;
        console.log('Saldo:', this.saldo)
      },
      (error) => {
        console.error('Erro ao buscar saldo:', error);
      }
    );
  }

  mostrarSaldo() {
    this.saldoOculto = false;
  }

  buscarExtrato() {
    if (this.conta) {
      this.router.navigate(['/extrato'], { queryParams: { conta: this.conta } });
    } else {
      console.error('Erro: Número da conta não disponível.');
    }
  }

  buscarMovimentacoes() {
    if (!this.conta) {
      console.error('Erro: Número da conta não fornecido.');
      return;
    }

    this.router.navigate(['/movimentacoes'], { queryParams: { conta: this.conta } });
  }

  movimentarConta() {
    this.router.navigate(['/movimentar-conta'], { queryParams: { conta: this.conta, codigoTipoUsuario: this.codigoTipoUsuario } });
  }
}
