using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJuego.Domain.Request;
using WebJuego.Domain.Response;

namespace WebJuego.Application.Contract
{
    public interface IJuegoAppService
    {
        ResponseDto<bool> registro(JugadoresRequest jugadores);
    }
}
