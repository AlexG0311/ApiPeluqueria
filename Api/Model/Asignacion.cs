using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Model
{
    public class Asignacion
    {

        [Key]
        public int idAsignacion { get; set; }

        // Clave foránea hacia Horario
        public int Horario_idHorario { get; set; }
        public Horario Horario { get; set; }
    }
}
