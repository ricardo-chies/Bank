using Bancario.Domain.Entities;
using Bancario.Domain.Interfaces;

namespace Bancario.Application.Services
{
    public class MovimentacaoFinanceiraService
    {
        private readonly IMovimentacaoFinanceiraRepository _repository;

        public MovimentacaoFinanceiraService(IMovimentacaoFinanceiraRepository repository)
        {
            _repository = repository;
        }

        public MovimentacaoFinanceira BuscarPorId(int id)
        {
            return null;
        }
    }
}
