using Microsoft.AspNetCore.Mvc;
using WebJuegoUI.Models.Request;
using WebJuegoUI.Models.Response;
using WebJuegoUI.Utilities.Contract;

namespace WebJuegoUI.Controllers
{
    public class JuegoController(IJuegoService juegoService) : Controller
    {
        private readonly IJuegoService _juegoService = juegoService;

        
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarJugadores([FromBody] JugadoresRequest request)
        {
            Models.Response.JugadoresResponse result = await _juegoService.RegistrarJugadores(request.jugador1, request.jugador2);

            if (result == null) return View();

            var redirectUrl = Url.Action("Juego", "Juego", new
            {
                id1 = result.Jugador1.Id,
                n1 = result.Jugador1.Nombre,
                id2 = result.Jugador2.Id,
                n2 = result.Jugador2.Nombre
            });

            return Ok(new
            {
                success = true,
                redirectUrl = redirectUrl
            });
        }

        public IActionResult Juego(Guid id1, string n1, Guid id2, string n2)
        {
            var modelo = new JuegoViewModel
            {
                IdJugador1 = id1,
                NombreJugador1 = n1,
                IdJugador2 = id2,
                NombreJugador2 = n2
            };

            return View(modelo);
        }
    }
}
