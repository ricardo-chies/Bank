import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ExtratoContaService } from './extrato-conta.service';

@Component({
  selector: 'app-extrato-conta',
  templateUrl: './extrato-conta.component.html',
  styleUrls: ['./extrato-conta.component.css']
})
export class ExtratoContaComponent implements OnInit {
  dataInicio: string = '';
  dataFim: string = '';
  movimentacoes: any[] = [];
  conta: number | null = null;

  constructor(
    private extratoService: ExtratoContaService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
  }

  buscarExtratoConta() {
    if (!this.conta) {
      console.error('Erro: Número da conta não fornecido.');
      return;
    }

    this.extratoService.buscarExtratoConta(this.conta)
      .subscribe(
        (response: any[]) => {
          this.movimentacoes = response;
        },
        (error: any) => {
          console.error('Erro ao buscar extrato:', error);
        }
      );
  }
}
