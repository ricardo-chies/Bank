using Bancario.Domain.Entities;

namespace Bancario.Domain.Interfaces
{
    public interface IContaBancariaRepository : IRepositoryBase<ContaBancaria>
    {
        Task<List<MovimentacaoFinanceira>> ObterExtratoPorPeriodo(int idConta, DateTime dataInicio, DateTime dataFim);
        Task<List<MovimentacaoFinanceira>> ObterExtratoPorConta(int idConta);
        Task<bool> InativarConta(int idConta);
    }
}
