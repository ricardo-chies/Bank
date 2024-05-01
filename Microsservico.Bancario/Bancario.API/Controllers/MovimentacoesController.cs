using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Bancario.API.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Route("api/v1.0/movimentacoes")]
    public class MovimentacoesController : Controller
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<int>), StatusCodes.Status200OK)]
        public async Task<IActionResult> PostBuscar()
        {
            return null;
        }
    }
}
