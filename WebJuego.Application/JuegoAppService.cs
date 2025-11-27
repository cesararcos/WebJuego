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

        public ResponseDto<bool> registro(JugadoresRequest jugadoresRequest)
        {
            try
            {
                //var result = _usuarioValidator.Validate(usuario);

                //if (!result.IsValid)
                //{
                //    return new ResponseDto<bool>
                //    {
                //        Success = false,
                //        ErrorMessage = result.Errors.First().ErrorMessage
                //    };
                //}

                //var findUser = _context?.Usuarios?.FirstOrDefault(x => x.Correo == usuario.Correo) ?? null;

                //if (findUser != null)
                //{
                //    return new ResponseDto<bool>
                //    {
                //        Success = false,
                //        ErrorMessage = Constants.USER_EXIST
                //    };
                //}

                Jugadores jugadores = new()
                {
                    Id = Guid.NewGuid(),
                    Nombre = "Test"
                };

                _context!.Jugadores.Add(jugadores);
                _context!.SaveChanges();

                return new ResponseDto<bool>
                {
                    Success = true,
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<bool>
                {
                    Success = false,
                    ErrorMessage = $"An error occurred: {ex.Message}"
                };
            }
        }
    }
}
