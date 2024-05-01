using Bancario.Domain.Entities;
using Bancario.Domain.Interfaces;

namespace Bancario.Infrastructure.Repositories
{
    public class MovimentacaoFinanceiraRepository : RepositoryBase<MovimentacaoFinanceira>, IMovimentacaoFinanceiraRepository
    {
        public MovimentacaoFinanceiraRepository(DataBaseContext context) : base(context)
        {

        }
    }
}
