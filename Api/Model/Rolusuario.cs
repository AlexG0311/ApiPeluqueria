using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Model
{
    public class Rolusuario
    {

        [Key]
        public int Rol_idRol { get; set; }
        [Key]
        public int usuario_idUsuario { get; set; }

        [ForeignKey("Rol_idRol")]
        public Rol Rol { get; set; }

        [ForeignKey("usuario_idUsuario")]
        public Usuario Usuario { get; set; }
    }
}
