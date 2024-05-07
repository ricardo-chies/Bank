using Bancario.Application.Dtos;
using Bancario.Application.Interfaces;
using Bancario.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using static System.Net.Mime.MediaTypeNames;

namespace Bancario.API.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Route("api/v1.0/contas")]
    public class ContasBancariasController : Controller
    {
        private readonly IContaBancariaService _contaService;
        private readonly IMovimentacaoFinanceiraService _movimentacaoService;
        private readonly ILogger<ContasBancariasController> _logger;

        public ContasBancariasController(IContaBancariaService contaService, IMovimentacaoFinanceiraService movimentacaoService, ILogger<ContasBancariasController> logger)
        {
            _contaService = contaService;
            _movimentacaoService = movimentacaoService;
            _logger = logger;
        }

        [HttpGet("{conta}")]
        [ProducesResponseType(typeof(ContaBancariaDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterConta([FromRoute] int conta)
        {
            try
            {
                _logger.LogInformation("[ObterConta] Realizando chamada no microsserviço");
                var resultado = await _contaService.ObterContaPorId(conta);
                return Ok(resultado);
            } 
            catch (Exception ex)
            {
                _logger.LogError("[ObterConta] Não foi possivel obter dados da conta: {conta} - Exception Message: {ex}", conta, ex);
                return StatusCode(500, new ErrorDto("Não foi possivel obter dados da conta", ex.Message, ex.StackTrace ?? ""));
            }

        }

        [HttpGet("saldos")]
        [ProducesResponseType(typeof(IEnumerable<ContaBancariaDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterSaldoClientes()
        {
            try
            {
                _logger.LogInformation("[ObterSaldoClientes] Realizando chamada no microsserviço");
                var resultado = await _contaService.ObterSaldoClientes();
                return Ok(resultado);
            }
            catch(Exception ex)
            {
                _logger.LogError("[ObterSaldoClientes] Não foi possivel obter os saldos dos clientes - Exception Message: {ex}", ex);
                return StatusCode(500, new ErrorDto("Não foi possivel obter os saldos dos clientes", ex.Message, ex.StackTrace ?? ""));
            }
        }


        [HttpGet("saldos/{cpf}")]
        [ProducesResponseType(typeof(ContaBancariaDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterSaldoClientePorCpf([FromRoute] string cpf)
        {
            try
            {
                _logger.LogInformation("[ObterSaldoClientePorCpf] Realizando chamada no microsserviço");
                var resultado = await _contaService.ObterSaldoClientePorCpf(cpf);
                return Ok(resultado);
            }
            catch(Exception ex)
            {
                _logger.LogError("[ObterSaldoClientePorCpf] Não foi possivel obter o saldo do cliente: {cpf} - Exception Message: {ex}", cpf, ex);
                return StatusCode(500, new ErrorDto(" Não foi possivel obter o saldo do cliente", ex.Message, ex.StackTrace ?? ""));
            }
        }

        [HttpGet("extrato/{conta}/{dataInicio}/{dataFim}")]
        [ProducesResponseType(typeof(ContaBancariaDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterExtratoPorPeriodo([FromRoute] int conta, DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                _logger.LogInformation("[ObterExtratoPorPeriodo] Realizando chamada no microsserviço");
                var resultado = await _contaService.ObterExtratoPorPeriodo(conta, dataInicio, dataFim);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError("[ObterExtratoPorPeriodo] Não foi possível obter extrato do período para a conta: {conta} - Exception Message: {ex}", conta, ex);
                return StatusCode(500, new ErrorDto("Não foi possível obter extrato do período para a conta", ex.Message, ex.StackTrace ?? ""));
            }

        }

        [HttpGet("extrato/{conta}")]
        [ProducesResponseType(typeof(ContaBancariaDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterExtratoPorConta([FromRoute] int conta)
        {
            try
            {
                _logger.LogInformation("[ObterExtratoPorConta] Realizando chamada no microsserviço");
                var resultado = await _contaService.ObterExtratoPorConta(conta);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError("[ObterExtratoPorConta] Não foi possível obter extrato para a conta: {conta} - Exception Message: {ex}", conta, ex);
                return StatusCode(500, new ErrorDto("Não foi possível obter extrato para a conta", ex.Message, ex.StackTrace ?? ""));
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> CriarContaBancaria([FromBody] ContaBancariaDto contaDto)
        {
            try
            {
                _logger.LogInformation("[CriarContaBancaria] Realizando chamada no microsserviço");
                var resultado = await _contaService.CriarContaBancaria(contaDto);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError("[CriarContaBancaria] Não foi possivel criar a conta - Exception Message: {ex}", ex);
                return StatusCode(500, new ErrorDto("Não foi possivel criar a conta", ex.Message, ex.StackTrace ?? ""));
            }

        }

        [HttpPost("movimentacoes")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> CriarMovimentacao([FromBody] MovimentacaoFinanceiraDto movimentacaoDto)
        {
            try
            {
                _logger.LogInformation("[CriarMovimentacao] Realizando chamada no microsserviço");
                var resultado = await _movimentacaoService.CriarMovimentacao(movimentacaoDto);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError("[CriarMovimentacao] Não foi possivel realizar a movimentação - Exception Message: {ex}", ex);
                return StatusCode(500, new ErrorDto("Não foi possivel realizar a movimentação", ex.Message, ex.StackTrace ?? ""));
            }

        }

        [HttpGet("{conta}/movimentacoes")]
        [ProducesResponseType(typeof(IEnumerable<MovimentacaoFinanceiraDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterMovimentacoes([FromRoute] int conta)
        {
            try
            {
                _logger.LogInformation("[ObterMovimentacoes] Realizando chamada no microsserviço");
                var resultado = await _movimentacaoService.ObterMovimentacoes(conta);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError("[ObterMovimentacoes] Não foi possivel obter as movimentações - Exception Message: {ex}", ex);
                return StatusCode(500, new ErrorDto("Não foi possivel obter as movimentações", ex.Message, ex.StackTrace ?? ""));
            }

        }

        [HttpDelete("{conta}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> ExcluirContaBancaria([FromRoute] int conta)
        {
            try
            {
                _logger.LogInformation("[ExcluirContaBancaria] Realizando chamada no microsserviço");
                var resultado = await _contaService.ExcluirContaBancaria(conta);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError("[ExcluirContaBancaria] Não foi possivel excluir a conta bancária - Exception Message: {ex}", ex);
                return StatusCode(500, new ErrorDto("Não foi possivel excluir a conta bancária", ex.Message, ex.StackTrace ?? ""));
            }

        }

        [HttpPut("inativa")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> InativarContaBancaria([FromQuery] int conta)
        {
            try
            {
                _logger.LogInformation("[InativarContaBancaria] Realizando chamada no microsserviço");
                var resultado = await _contaService.InativaConta(conta);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError("[InativarContaBancaria] Não foi possivel inativar a conta - Exception Message: {ex}", ex);
                return StatusCode(500, new ErrorDto("Não foi possivel inativar a conta", ex.Message, ex.StackTrace ?? ""));
            }

        }
    }
}
