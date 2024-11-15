using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Model
{
    public class Especialidades
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idEspecialidades { get; set; }
        public string Nombre { get; set; }

        // Clave foránea hacia Empleado
        public int Empleado_idEmpleado { get; set; }
        public Empleado Empleado { get; set; }
    }
}
