using WebJuegoUI.Models.Response;

namespace WebJuegoUI.Utilities.Contract
{
    public interface IJuegoService
    {
        Task<JugadoresResponse> RegistrarJugadores(string? jugador1, string? jugador2);
    }
}
