namespace Bancario.Domain.Entities
{
    public class MovimentacaoFinanceira
    {
        public int Id { get; set; }
        public int IdConta { get; set; }
        public TipoMovimentacao Tipo { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public string Descricao { get; set; }
    }

    public enum TipoMovimentacao
    {
        Credito,
        Debito
    }
}
