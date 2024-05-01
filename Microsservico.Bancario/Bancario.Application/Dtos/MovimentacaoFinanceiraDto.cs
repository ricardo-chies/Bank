namespace Bancario.Application.Dtos
{
    public class MovimentacaoFinanceiraDto
    {
        public int CodigoMovimentacao { get; set; }
        public int Conta { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public string? Descricao { get; set; }
    }
}