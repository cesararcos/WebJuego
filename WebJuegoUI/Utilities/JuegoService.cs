using WebJuegoUI.Models.Response;
using WebJuegoUI.Utilities.Contract;

namespace WebJuegoUI.Utilities
{
    public class JuegoService : IJuegoService
    {
        private readonly HttpClient _httpClient;

        public JuegoService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5094/api/Juego/");
        }

        public async Task<JugadoresResponse> RegistrarJugadores(string? jugador1, string? jugador2)
        {
            JugadoresResponse viewModel = new();

            var info = new
            {
                Jugador1 = jugador1,
                Jugador2 = jugador2,
            };
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("Registro", info);

            if (response.IsSuccessStatusCode)
            {
                ResponseDto<JugadoresResponse>? result = await response.Content.ReadFromJsonAsync<ResponseDto<JugadoresResponse>>();

                if (result!.Success)
                {
                    viewModel = new()
                    {
                        Jugador1 = result.Data.Jugador1,
                        Jugador2 = result.Data.Jugador2,
                    };

                }
            }

            return viewModel;
        }
    }
}
