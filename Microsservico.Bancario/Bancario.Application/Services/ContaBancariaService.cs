using Bancario.Application.Interfaces;
using Bancario.Domain.Entities;
using Bancario.Domain.Interfaces;

namespace Bancario.Application.Services
{
    public class ContaBancariaService : IContaBancariaService
    {
        private readonly IContaBancariaRepository _repository;

        public ContaBancariaService(IContaBancariaRepository repository)
        {
            _repository = repository;
        }

        public ContaBancaria BuscarPorId(int id)
        {
            return null;
        }
    }
}
