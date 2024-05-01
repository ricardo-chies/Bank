

namespace Bancario.Application.Dtos
{
    public class ContaBancariaDto
    {
        public int Conta { get; set; }
        public string Cpf { get; set; }
        public decimal Saldo { get; set; }
        public required string Status { get; set; }
    }
}
