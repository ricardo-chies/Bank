using Bancario.Domain.Entities;
using Bancario.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bancario.Infrastructure.Repositories
{
    public class MovimentacaoFinanceiraRepository : RepositoryBase<MovimentacaoFinanceira>, IMovimentacaoFinanceiraRepository
    {
        public MovimentacaoFinanceiraRepository(DataBaseContext context) : base(context)
        {

        }

        public async Task<List<MovimentacaoFinanceira>> ObterMovimentacoesConta(int idConta)
        {
            return await _context.Set<MovimentacaoFinanceira>()
                .Where(m => m.IdContaOrigem == idConta)
                .ToListAsync();
        }
    }
}
