using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.Model
{
    public class Empleado
    {

        [Key]
        public int idEmpleado { get; set; }

        [ForeignKey("Usuario")]
        public int Usuario_idUsuario { get; set; }
        public Usuario Usuario { get; set; }


    }
}
