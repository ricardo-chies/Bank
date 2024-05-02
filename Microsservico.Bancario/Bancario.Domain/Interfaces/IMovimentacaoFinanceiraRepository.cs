using Bancario.Domain.Entities;

namespace Bancario.Domain.Interfaces
{
    public interface IMovimentacaoFinanceiraRepository : IRepositoryBase<MovimentacaoFinanceira>
    {
        Task<List<MovimentacaoFinanceira>> ObterMovimentacoesConta(int idConta);
    }
}
