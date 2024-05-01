using Bancario.Domain.Entities;

namespace Bancario.Application.Dtos
{
    public class UsuarioDto
    {
        public string nome { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public int codigoTipoUsuario { get; set; }
    }
}
