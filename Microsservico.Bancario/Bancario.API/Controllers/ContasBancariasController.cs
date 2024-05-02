using Bancario.Application.Dtos;
using Bancario.Application.Interfaces;
using Bancario.Domain.Interfaces;
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
    }
}
