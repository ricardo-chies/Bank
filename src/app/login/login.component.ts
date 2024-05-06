import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  cpf: string = '';
  senha: string = '';
  errorMessage: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  login() {
    this.authService.login(this.cpf, this.senha).subscribe(response => {
      console.log('Resposta do login:', response);
      if (response === null) {
        alert('Usuário não localizado.');
      } else if (response.codigoTipoUsuario === 1) {
        this.router.navigate(['/gerente']);
      } else if (response.codigoTipoUsuario === 2) {
        this.router.navigate(['/cliente'], { queryParams: { nome: response.nome, cpf: response.cpf, codigoTipoUsuario: response.codigoTipoUsuario } });
      } else {
        alert('Usuário não localizado.');
      }
    }, (error: HttpErrorResponse) => {
      console.error('Erro ao fazer login:', error);
      if (error.status === 204) {
        alert('Usuário não localizado.');
      } else {
        alert('Erro ao fazer login. Por favor, tente novamente mais tarde.');
      }
    });
  }
}