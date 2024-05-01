using Bancario.Domain.Entities;

namespace Bancario.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<Usuario> GetCpf(string cpf);
    }
}
