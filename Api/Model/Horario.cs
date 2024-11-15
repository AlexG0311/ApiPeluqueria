using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Model
{
    public class Horario
    {

        [Key]
        public int idHorario { get; set; }
        public DateTime DiaMesAño { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }

        // Clave foránea hacia Empleado
        public int Empleado_idEmpleado { get; set; }
        public Empleado Empleado { get; set; }

        // Relación uno a muchos con Asignacion
        public ICollection<Asignacion> Asignaciones { get; set; }
    }
}
