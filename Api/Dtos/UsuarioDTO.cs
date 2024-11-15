using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public class UsuarioDTO
    {

        [Key]
        public int idUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string Telefono { get; set; }
    }
}
