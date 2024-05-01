namespace Bancario.Domain.Entities
{
    public class ContaBancaria
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public decimal Saldo { get; set; }
        public StatusConta Status { get; set; }
    }

    public enum StatusConta
    {
        Ativa,
        Inativa
    }
}
