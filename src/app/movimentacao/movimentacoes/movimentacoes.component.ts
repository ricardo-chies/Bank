import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MovimentacoesService } from './movimentacoes.service';

@Component({
  selector: 'app-movimentacoes',
  templateUrl: './movimentacoes.component.html',
  styleUrls: ['./movimentacoes.component.css']
})
export class MovimentacoesComponent implements OnInit {
  movimentacoes: any[] = [];
  conta: number | null = null;
  loading: boolean = false;
  error: string | null = null;

  constructor(
    private route: ActivatedRoute,
    private movimentacoesService: MovimentacoesService
  ) {}

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.conta = params['conta'] || null;
      console.log('Conta:', this.conta)
      if (this.conta) {
        this.buscarMovimentacoes();
      }
    });
  }

  buscarMovimentacoes() {
    this.loading = true;
    this.error = null;
    this.movimentacoesService.buscarMovimentacoes(this.conta!).subscribe(
      (response) => {
        this.movimentacoes = response || [];
        this.loading = false;
      },
      (error) => {
        this.error = 'Erro ao buscar movimentações. Por favor, tente novamente mais tarde.';
        this.loading = false;
      }
    );
  }
}
