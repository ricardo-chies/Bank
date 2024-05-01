using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bancario.Domain.Entities
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public required string CPF { get; set; }
        public required string NomeCompleto { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }
        public int IdTipoUsuario { get; set; }
    }

}