using Bancario.Application.Dtos;
using Bancario.Application.Interfaces;
using Bancario.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Bancario.API.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Route("api/v1.0/usuarios")]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioService _service;
        private readonly ILogger<UsuariosController> _logger;

        public UsuariosController(IUsuarioService service, ILogger<UsuariosController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> CriarUsuario([FromBody] UsuarioDto usuario)
        {
            try
            {
                _logger.LogInformation("[CriarUsuario] Criando novo usu�rio: {usuario.Cpf}", usuario.Cpf);
                var resultado = await _service.CriarUsuario(usuario);
                return Ok(resultado);
            } 
            catch (Exception ex)
            {
                _logger.LogInformation("[CriarUsuario] N�o foi poss�vel criar o usu�rio: {usuario.Cpf} - Exception Message: {ex}", usuario.Cpf, ex);
                return StatusCode(500, new ErrorDto("N�o foi poss�vel criar o usu�rio", ex.Message, ex.StackTrace ?? ""));
            }

        }

        [HttpGet("{cpf}")]
        [ProducesResponseType(typeof(UsuarioDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterUsuarioPorCpf([FromRoute] string cpf)
        {
            try
            {
                _logger.LogInformation("[ObterUsuarioPorCpf] Buscando usu�rio: {cpf}", cpf);
                var usuario = await _service.ObterUsuarioPorCpf(cpf);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("[ObterUsuarioPorCpf] N�o foi poss�vel localizar o usu�rio: {cpf} - Exception Message: {ex}", cpf, ex);
                return StatusCode(500, new ErrorDto("N�o foi poss�vel localizar o usu�rio", ex.Message, ex.StackTrace ?? ""));
            }

        }

        [HttpGet("login")]
        [ProducesResponseType(typeof(UsuarioDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> LoginUsuario([FromQuery] string cpf, string senha)
        {
            try
            {
                _logger.LogInformation("[LoginUsuario] Verficando credenciais usu�rio: {cpf}", cpf);
                var resultado = await _service.LoginUsuario(cpf, senha);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("[LoginUsuario] N�o foi poss�vel realizar o login de usu�rio: {cpf} - Exception Message: {ex}", cpf, ex);
                return StatusCode(500, new ErrorDto("N�o foi poss�vel realizar o login de usu�rio", ex.Message, ex.StackTrace ?? ""));
            }

        }
    }
}
