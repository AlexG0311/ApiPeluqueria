namespace Api.Dtos
{
    public class UsuarioClienteDTO
    {

        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string correo { get; set; }
        public string contrasena { get; set; }
        public string telefono { get; set; }
        public bool EsCliente { get; set; } // Indica si el usuario es cliente
    }
}
