using WebJuego.Domain.Entities;
using WebJuego.Domain.Request;
using WebJuego.Domain.Response;

namespace WebJuego.Application.Contract
{
    public interface IJuegoAppService
    {
        ResponseDto<JugadoresResponse> registro(JugadoresRequest jugadoresRequest);
    }
}
