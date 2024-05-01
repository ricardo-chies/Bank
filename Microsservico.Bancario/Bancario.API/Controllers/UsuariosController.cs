using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Bancario.API.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Route("api/v1.0/usuarios")]
    public class UsuariosController : Controller
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<int>), StatusCodes.Status200OK)]
        public async Task<IActionResult> PostBuscar()
        {
            return null;
        }
    }
}
