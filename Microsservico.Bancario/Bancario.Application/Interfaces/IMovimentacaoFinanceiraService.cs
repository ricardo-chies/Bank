using Bancario.Application.Dtos;

namespace Bancario.Application.Interfaces
{
    public interface IMovimentacaoFinanceiraService
    {
        Task<bool> CriarMovimentacao(MovimentacaoFinanceiraDto movimentacaoDto);
    }
}