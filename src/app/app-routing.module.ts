import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from './login/login.component';
import { GerenteComponent } from './usuarios/gerente/gerente.component';
import { ClienteComponent } from './usuarios/cliente/cliente.component';
import { ExtratoComponent } from './movimentacao/extrato-periodo/extrato.component';
import { MovimentacoesComponent } from './movimentacao/movimentacoes/movimentacoes.component';
import { ContasClientesComponent } from './conta-bancaria/contas-clientes/contas-clientes.component';
import { MovimentarContaComponent } from './movimentacao/movimentar-conta/movimentar-conta.component';
import { ExtratoContaComponent } from './movimentacao/extrato-conta/extrato-conta.component';
import { CriarContaBancariaComponent } from './conta-bancaria/criar-conta-bancaria/criar-conta-bancaria.component';
import { ExcluirContaBancariaComponent } from './conta-bancaria/excluir-conta-bancaria/excluir-conta-bancaria.component';

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'gerente', component: GerenteComponent },
  { path: 'cliente', component: ClienteComponent },
  { path: 'extrato', component: ExtratoComponent },
  { path: 'movimentacoes', component: MovimentacoesComponent },
  { path: 'contas-clientes', component: ContasClientesComponent },
  { path: 'movimentar-conta', component: MovimentarContaComponent },
  { path: 'extrato-conta', component: ExtratoContaComponent },
  { path: 'criar-conta-bancaria', component: CriarContaBancariaComponent },
  { path: 'excluir-conta-bancaria', component: ExcluirContaBancariaComponent },
  { path: '**', redirectTo: '/login' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
