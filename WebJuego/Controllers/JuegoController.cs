using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebJuego.Application.Contract;
using WebJuego.Domain.Request;
using WebJuego.Domain.Response;

namespace WebJuego.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JuegoController(IJuegoAppService juegoAppService) : ControllerBase
    {
        private readonly IJuegoAppService _juegoAppService = juegoAppService;

        [HttpPost]
        public IActionResult Registro(JugadoresRequest jugadores)
        {
            ResponseDto<bool> responde = _juegoAppService.registro(jugadores);

            if (!responde.Success)
                return NotFound(responde.ErrorMessage);

            return Ok(responde);
        }

    }
}
