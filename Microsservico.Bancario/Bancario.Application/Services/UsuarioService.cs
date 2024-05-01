using Bancario.Domain.Entities;
using Bancario.Domain.Interfaces;

namespace Bancario.Application.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public Usuario BuscarPorId(int id)
        {
            return null;
        }
    }
}
