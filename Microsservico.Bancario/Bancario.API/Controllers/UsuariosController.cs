using Bancario.Application.Dtos;
using Bancario.Application.Interfaces;
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

        public UsuariosController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> CriarUsuario([FromBody] UsuarioDto usuario)
        {
            var resultado = await _service.CriarUsuario(usuario);
            return Ok(resultado);
        }

        [HttpGet("{cpf}")]
        [ProducesResponseType(typeof(UsuarioDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterUsuarioPorCpf([FromRoute] string cpf)
        {
            var usuario = await _service.ObterUsuarioPorCpf(cpf);
            return Ok(usuario);
        }

        [HttpGet("login")]
        [ProducesResponseType(typeof(UsuarioDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> LoginUsuario([FromQuery] string cpf, string senha)
        {
            var resultado = await _service.LoginUsuario(cpf, senha);
            return Ok(resultado);
        }
    }
}
