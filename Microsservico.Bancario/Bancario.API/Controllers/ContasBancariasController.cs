using Bancario.Application.Dtos;
using Bancario.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Bancario.API.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Route("api/v1.0/contas")]
    public class ContasBancariasController : Controller
    {
        private readonly IContaBancariaService _contaService;
        private readonly IMovimentacaoFinanceiraService _movimentacaoService;

        public ContasBancariasController(IContaBancariaService contaService, IMovimentacaoFinanceiraService movimentacaoService)
        {
            _contaService = contaService;
            _movimentacaoService = movimentacaoService;
        }

        [HttpGet("{conta}")]
        [ProducesResponseType(typeof(ContaBancariaDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterConta([FromRoute] int conta)
        {
            var resultado = await _contaService.ObterContaPorId(conta);
            return Ok(resultado);
        }

        [HttpGet("saldos")]
        [ProducesResponseType(typeof(IEnumerable<ContaBancariaDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterSaldoClientes()
        {
            var resultado = await _contaService.ObterSaldoClientes();
            return Ok(resultado);
        }

        [HttpGet("extrato/{conta}/{dataInicio}/{dataFim}")]
        [ProducesResponseType(typeof(ContaBancariaDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterExtratoPorPeriodo([FromRoute] int conta, DateTime dataInicio, DateTime dataFim)
        {
            var resultado = await _contaService.ObterExtratoPorPeriodo(conta, dataInicio, dataFim);
            return Ok(resultado);
        }

        [HttpGet("extrato/{conta}")]
        [ProducesResponseType(typeof(ContaBancariaDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterExtratoPorConta([FromRoute] int conta)
        {
            var resultado = await _contaService.ObterExtratoPorConta(conta);
            return Ok(resultado);
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> CriarContaBancaria([FromBody] ContaBancariaDto contaDto)
        {
            var resultado = await _contaService.CriarContaBancaria(contaDto);
            return Ok(resultado);
        }

        [HttpPost("movimentacoes")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> CriarMovimentacao([FromBody] MovimentacaoFinanceiraDto movimentacaoDto)
        {
            var resultado = await _movimentacaoService.CriarMovimentacao(movimentacaoDto);
            return Ok(resultado);
        }

        [HttpGet("{conta}/movimentacoes")]
        [ProducesResponseType(typeof(IEnumerable<MovimentacaoFinanceiraDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterMovimentacoes([FromRoute] int conta)
        {
            var resultado = await _movimentacaoService.ObterMovimentacoes(conta);
            return Ok(resultado);
        }

        [HttpDelete("{conta}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> ExcluirContaBancaria([FromRoute] int conta)
        {
            var resultado = await _contaService.ExcluirContaBancaria(conta);
            return Ok(resultado);
        }

        [HttpPut("inativa")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> InativarContaBancaria([FromBody] List<ContaBancariaDto> contaDto)
        {
            var resultado = await _contaService.AtualizarContas(contaDto);
            return Ok(resultado);
        }
    }
}
