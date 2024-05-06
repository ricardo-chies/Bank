import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-movimentar-conta',
  templateUrl: './movimentar-conta.component.html',
  styleUrls: ['./movimentar-conta.component.css']
})
export class MovimentarContaComponent implements OnInit {
  contaOrigem: number = 0;
  codigoTipoUsuario: number = 0;
  movimentacao: any = {
    contaOrigem: 0,
    contaDestino: 0,
    valor: 0,
    dataMovimentacao: new Date().toISOString(),
    descricao: ''
  };
  movimentacaoConcluida: boolean = false;
  erroMovimentacao: string = '';

  constructor(private http: HttpClient, private location: Location, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.queryParams.subscribe((params: Params) => {
      const contaOrigem = params['conta'];
      this.codigoTipoUsuario = parseInt(params['codigoTipoUsuario'], 10);

      if (this.codigoTipoUsuario === 2) {
        this.contaOrigem = parseInt(contaOrigem, 10);
        this.movimentacao.contaOrigem = this.contaOrigem;
      }
    });
  }

  realizarMovimentacao() {
    this.movimentacao.dataMovimentacao = new Date().toISOString();

    this.http.post<any>('https://localhost:44324/api/v1.0/contas/movimentacoes', this.movimentacao)
      .subscribe(response => {
        console.log('Resposta da movimentação:', response);
        if (response === true) {
          this.movimentacaoConcluida = true;
          this.erroMovimentacao = '';
        } else {
          this.erroMovimentacao = 'Não foi possível realizar a movimentação';
          this.movimentacaoConcluida = true;
        }
      }, error => {
        console.error('Erro ao realizar movimentação:', error);
      });
  }

  voltar() {
    this.location.back();
  }

  novaMovimentacao() {
    this.movimentacao = {
      contaOrigem: 0,
      contaDestino: 0,
      valor: 0,
      dataMovimentacao: new Date().toISOString(),
      descricao: ''
    };
    this.movimentacaoConcluida = false;
    this.erroMovimentacao = '';
  }
}
