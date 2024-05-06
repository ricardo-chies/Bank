import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { TableModule } from 'primeng/table';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { ClienteComponent } from './usuarios/cliente/cliente.component';
import { GerenteComponent } from './usuarios/gerente/gerente.component';
import { HttpClientModule } from '@angular/common/http';
import { AuthService } from './auth.service';
import { FormsModule } from '@angular/forms';
import {ButtonModule} from 'primeng/button';
import { ExtratoComponent } from './movimentacao/extrato-periodo/extrato.component';
import { MovimentacoesComponent } from './movimentacao/movimentacoes/movimentacoes.component';
import { ContasClientesComponent } from './conta-bancaria/contas-clientes/contas-clientes.component';
import { MovimentarContaComponent } from './movimentacao/movimentar-conta/movimentar-conta.component';
import { ExtratoContaComponent } from './movimentacao/extrato-conta/extrato-conta.component';
import { CriarContaBancariaComponent } from './conta-bancaria/criar-conta-bancaria/criar-conta-bancaria.component';
import { ExcluirContaBancariaComponent } from './conta-bancaria/excluir-conta-bancaria/excluir-conta-bancaria.component'

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ClienteComponent,
    GerenteComponent,
    ExtratoComponent,
    MovimentacoesComponent,
    ContasClientesComponent,
    MovimentarContaComponent,
    ExtratoContaComponent,
    CriarContaBancariaComponent,
    ExcluirContaBancariaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ButtonModule,
    TableModule
  ],
  providers: [AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
