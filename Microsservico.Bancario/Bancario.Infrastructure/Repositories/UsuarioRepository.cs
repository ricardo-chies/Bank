using Bancario.Domain.Entities;
using Bancario.Domain.Interfaces;

namespace Bancario.Infrastructure.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DataBaseContext context) : base(context)
        {

        }
    }
}
