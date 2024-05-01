using Bancario.Domain.Entities;
using Bancario.Domain.Interfaces;

namespace Bancario.Infrastructure.Repositories
{
    public class ContaBancariaRepository : RepositoryBase<ContaBancaria>, IContaBancariaRepository
    {
        public ContaBancariaRepository(DataBaseContext context) : base(context)
        {

        }
    }
}