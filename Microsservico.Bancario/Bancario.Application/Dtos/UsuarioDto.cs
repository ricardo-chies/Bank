using Bancario.Domain.Entities;

namespace Bancario.Application.Dtos
{
    public class UsuarioDto
    {
        public required string Cpf { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }
        public int CodigoTipoUsuario { get; set; }
    }
}
