using Bancario.Application.Dtos;

namespace Bancario.Application.Interfaces
{
    public interface IContaBancariaService
    {
        Task<ContaBancariaDto> ObterContaPorId(int idConta);
        Task<bool> AtualizarContas(List<ContaBancariaDto> listContaDto);
        Task<bool> ExcluirContaBancaria(int idConta);
        Task<bool> CriarContaBancaria(ContaBancariaDto contaDto);
        Task<IEnumerable<MovimentacaoFinanceiraDto>> ObterExtratoPorPeriodo(int conta, DateTime dataInicio, DateTime dataFim);
        Task<IEnumerable<MovimentacaoFinanceiraDto>> ObterExtratoPorConta(int conta);
        Task<IEnumerable<ContaBancariaDto>> ObterSaldoClientes();
    }
}