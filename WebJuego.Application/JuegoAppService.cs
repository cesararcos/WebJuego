using WebJuego.Application.Contract;
using WebJuego.Domain.Entities;
using WebJuego.Domain.Request;
using WebJuego.Domain.Response;
using WebJuego.Infrastructure.DataAccess;

namespace WebJuego.Application
{
    public class JuegoAppService(JuegoDbContext context) : IJuegoAppService
    {
        private readonly JuegoDbContext _context = context;

        public ResponseDto<JugadoresResponse> registro(JugadoresRequest jugadoresRequest)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(jugadoresRequest.Jugador1) || string.IsNullOrWhiteSpace(jugadoresRequest.Jugador2))
                {
                    return new ResponseDto<JugadoresResponse>
                    {
                        Success = false,
                        ErrorMessage = "Debe enviar los nombres de ambos jugadores."
                    };
                }

                Jugadores jugador1 = new Jugadores
                {
                    Id = Guid.NewGuid(),
                    Nombre = jugadoresRequest.Jugador1
                };

                Jugadores jugador2 = new Jugadores
                {
                    Id = Guid.NewGuid(),
                    Nombre = jugadoresRequest.Jugador2
                };

                _context.Jugadores.Add(jugador1);
                _context.Jugadores.Add(jugador2);
                _context!.SaveChanges();

                JugadoresResponse response = new JugadoresResponse
                {
                    Jugador1 = new JugadorResponse{ Id = jugador1.Id, Nombre = jugador1.Nombre },
                    Jugador2 = new JugadorResponse { Id = jugador2.Id, Nombre = jugador2.Nombre }
                };

                return new ResponseDto<JugadoresResponse>
                {
                    Success = true,
                    Data = response
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<JugadoresResponse>
                {
                    Success = false,
                    ErrorMessage = $"An error occurred: {ex.Message}"
                };
            }
        }
    }
}
