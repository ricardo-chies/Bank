using Bancario.Domain.Entities;
using Bancario.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bancario.Infrastructure.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DataBaseContext context) : base(context)
        {

        }

        public async Task<Usuario> GetCpf(string cpf)
        {
            Expression<Func<Usuario, bool>> predicate = x => x.CPF == cpf;
            return await _context.Set<Usuario>().SingleOrDefaultAsync(predicate);
        }

        public async Task<Usuario> GetLogin(string cpf, string senha)
        {
            var usuario = await _context.Set<Usuario>()
                                         .SingleOrDefaultAsync(x => x.CPF == cpf && x.Senha == senha);
            return usuario;
        }

    }
}
