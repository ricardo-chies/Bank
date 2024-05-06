import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-criar-conta-bancaria',
  templateUrl: './criar-conta-bancaria.component.html',
  styleUrls: ['./criar-conta-bancaria.component.css']
})
export class CriarContaBancariaComponent implements OnInit {
  cliente: any = {
    cpf: '',
    nome: '',
    email: '',
    senha: '',
    codigoTipoUsuario: '2'
  };

  conta: any = {
    cpf: this.cliente.cpf,
    saldo: 0,
    status: 'A'
  };

  contaConcluida: boolean = false;
  erroConta: string = '';

  constructor(private http: HttpClient, private location: Location, private route: ActivatedRoute) { }

  ngOnInit() {}

  abrirConta() {
    this.http.post<any>('https://localhost:44324/api/v1.0/usuarios', this.cliente)
    .subscribe(response => {
      console.log('Resposta do cliente:', response);
      if (response === true) {
        // Atribuir o valor de cliente.cpf a conta.cpf antes de criar a conta
        this.conta.cpf = this.cliente.cpf;
  
        this.http.post<any>('https://localhost:44324/api/v1.0/contas', this.conta)
          .subscribe(response => {
            console.log('Resposta da abertura:', response);
            if (response === true) {
              this.contaConcluida = true;
              this.erroConta = '';
            } else {
              this.erroConta = 'Não foi possível realizar a abertura';
              this.contaConcluida = true;
            }
          }, error => {
            console.error('Erro ao realizar abertura:', error);
          });
  
      } else {
        this.erroConta = 'Não foi possível realizar a abertura';
        this.contaConcluida = true;
      }
    }, error => {
      console.error('Erro ao realizar abertura:', error);
    });
  }

  voltar() {
    this.location.back();
  }

  novaAbertura() {
    this.cliente = {
      cpf: '',
      nome: '',
      email: '',
      senha: '',
      codigoTipoUsuario: '2'
    };
    this.conta = {
      cpf: '',
      saldo: 0,
      status: 'A'
    };
    this.contaConcluida = false;
    this.erroConta = '';
  }
}
