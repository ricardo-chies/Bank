import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ExtratoService } from './extrato.service';

@Component({
  selector: 'app-extrato',
  templateUrl: './extrato.component.html',
  styleUrls: ['./extrato.component.css']
})
export class ExtratoComponent implements OnInit {
  dataInicio: string = '';
  dataFim: string = '';
  movimentacoes: any[] = [];
  conta: number | null = null;

  constructor(
    private extratoService: ExtratoService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.conta = params['conta'] || null;
    });
  }

  buscarExtrato() {
    if (!this.conta) {
      console.error('Erro: Número da conta não fornecido.');
      return;
    }

    this.extratoService.buscarExtrato(this.conta, this.dataInicio, this.dataFim)
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
