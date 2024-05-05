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
                _logger.LogInformation("[CriarUsuario] Criando novo usuário: {usuario.Cpf}", usuario.Cpf);
                var resultado = await _service.CriarUsuario(usuario);
                return Ok(resultado);
            } 
            catch (Exception ex)
            {
                _logger.LogInformation("[CriarUsuario] Não foi possível criar o usuário: {usuario.Cpf} - Exception Message: {ex}", usuario.Cpf, ex);
                return StatusCode(500, new ErrorDto("Não foi possível criar o usuário", ex.Message, ex.StackTrace ?? ""));
            }

        }

        [HttpGet("{cpf}")]
        [ProducesResponseType(typeof(UsuarioDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterUsuarioPorCpf([FromRoute] string cpf)
        {
            try
            {
                _logger.LogInformation("[ObterUsuarioPorCpf] Buscando usuário: {cpf}", cpf);
                var usuario = await _service.ObterUsuarioPorCpf(cpf);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("[ObterUsuarioPorCpf] Não foi possível localizar o usuário: {cpf} - Exception Message: {ex}", cpf, ex);
                return StatusCode(500, new ErrorDto("Não foi possível localizar o usuário", ex.Message, ex.StackTrace ?? ""));
            }

        }

        [HttpGet("login")]
        [ProducesResponseType(typeof(UsuarioDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> LoginUsuario([FromQuery] string cpf, string senha)
        {
            try
            {
                _logger.LogInformation("[LoginUsuario] Verficando credenciais usuário: {cpf}", cpf);
                var resultado = await _service.LoginUsuario(cpf, senha);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("[LoginUsuario] Não foi possível realizar o login de usuário: {cpf} - Exception Message: {ex}", cpf, ex);
                return StatusCode(500, new ErrorDto("Não foi possível realizar o login de usuário", ex.Message, ex.StackTrace ?? ""));
            }

        }
    }
}
