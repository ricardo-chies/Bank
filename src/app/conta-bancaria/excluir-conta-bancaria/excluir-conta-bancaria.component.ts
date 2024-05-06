import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Location } from '@angular/common';

@Component({
  selector: 'app-excluir-conta-bancaria',
  templateUrl: './excluir-conta-bancaria.component.html',
  styleUrls: ['./excluir-conta-bancaria.component.css']
})
export class ExcluirContaBancariaComponent {
  numeroConta: string = '';
  mensagemVerificacao: string = '';
  mensagemInativacao: string = '';
  mensagemExclusao: string = '';
  mostrarMensagemRetorno: boolean = false;

  constructor(private http: HttpClient, private location: Location) { }

  verificarConta() {
    this.http.get<any[]>(`https://localhost:44324/api/v1.0/contas/${this.numeroConta}/movimentacoes`)
      .subscribe(
        movimentacoes => {
          if (movimentacoes.length > 0) {
            this.mensagemVerificacao = 'Foi encontrado registro de movimentações, deseja inativar a conta?';
            this.mensagemExclusao = '';
          } else {
            this.mensagemVerificacao = 'Nenhuma movimentação encontrada, deseja excluir a conta ?';
          }
        },
        error => {
          console.error('Erro ao verificar conta:', error);
          this.mensagemVerificacao = 'Ocorreu um erro ao verificar a conta. Por favor, tente novamente mais tarde.';
          this.mensagemExclusao = 'Ocorreu um erro ao verificar a conta. Por favor, tente novamente mais tarde.';
        }
      );
  }

  inativarConta() {
    this.http.put(`https://localhost:44324/api/v1.0/contas/${this.numeroConta}`, {})
      .subscribe(
        (response: any) => {
          if (response) {
            this.mensagemInativacao = 'Conta inativada com sucesso.';
          } else {
            this.mensagemInativacao = 'Não foi possível inativar a conta.';
          }
          this.mostrarMensagemRetorno = true;
        },
        error => {
          console.error('Erro ao inativar conta:', error);
          this.mensagemInativacao = 'Ocorreu um erro ao inativar a conta. Por favor, tente novamente mais tarde.';
          this.mostrarMensagemRetorno = true;
        }
      );
  }

  excluirConta() {
    this.http.delete(`https://localhost:44324/api/v1.0/contas/${this.numeroConta}`)
      .subscribe(
        (response: any) => {
          if (response) {
            this.mensagemExclusao = 'Conta excluída com sucesso.';
          } else {
            this.mensagemExclusao = 'Não foi possível excluir a conta.';
          }
          this.mostrarMensagemRetorno = true;
        },
        error => {
          console.error('Erro ao excluir conta:', error);
          this.mensagemExclusao = 'Ocorreu um erro ao excluir a conta. Por favor, tente novamente mais tarde.';
          this.mostrarMensagemRetorno = true;
        }
      );
  }

  voltar() {
    this.location.back();
  }
}
