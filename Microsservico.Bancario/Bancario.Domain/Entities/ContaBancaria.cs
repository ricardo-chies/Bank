using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bancario.Domain.Entities
{
    [Table("Conta_Bancaria")]
    public class ContaBancaria
    {
        [Key]
        public int IdConta { get; set; }
        public required string CPF { get; set; }
        public decimal Saldo { get; set; }
        public required string Status { get; set; }
    }
}
