using Bancario.Domain.Entities;
using Bancario.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bancario.Infrastructure.Repositories
{
    public class ContaBancariaRepository : RepositoryBase<ContaBancaria>, IContaBancariaRepository
    {
        public ContaBancariaRepository(DataBaseContext context) : base(context)
        {

        }

        public async Task<List<MovimentacaoFinanceira>> ObterExtratoPorPeriodo(int idConta, DateTime dataInicio, DateTime dataFim)
        {
            // Exemplo utilizando FromSqlRaw

            var sql = 
                @"
                   SELECT IdMovimentacao, IdContaOrigem, IdContaDestino, Valor, DataMovimentacao, Descricao
                   FROM movimentacao_financeira
                   WHERE DATE(DataMovimentacao) BETWEEN {1} AND {2} AND (IdContaOrigem = {0} OR IdContaDestino = {0})
                   ORDER BY DataMovimentacao DESC
                ";

            var movimentacoes = await _context.Movimentacao_Financeira
                .FromSqlRaw(sql, idConta, dataInicio.ToString("yyyy-MM-dd"), dataFim.ToString("yyyy-MM-dd"))
                .ToListAsync();

            return movimentacoes;
        }

        public async Task<List<MovimentacaoFinanceira>> ObterExtratoPorConta(int idConta)
        {
            // Exemplo usando LinQ

            var movimentacoes = await _context.Movimentacao_Financeira
                .Where(m => m.IdContaOrigem == idConta || m.IdContaDestino == idConta)
                .OrderByDescending(m => m.DataMovimentacao)
                .ToListAsync();

            return movimentacoes;
        }

    }
}
