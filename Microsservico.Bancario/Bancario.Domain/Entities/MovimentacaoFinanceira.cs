using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bancario.Domain.Entities
{
    [Table("Movimentacao_Financeira")]
    public class MovimentacaoFinanceira
    {
        [Key]
        public int IdMovimentacao { get; set; }
        public int IdConta { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public string? Descricao { get; set; }
    }
}
