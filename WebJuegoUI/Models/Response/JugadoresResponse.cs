namespace WebJuegoUI.Models.Response
{
    public class JugadoresResponse
    {
        public JugadorResponse? Jugador1 { get; set; }
        public JugadorResponse? Jugador2 { get; set; }
    }

    public class JugadorResponse
    {
        public Guid Id { get; set; }
        public string? Nombre { get; set; }
    }
}
