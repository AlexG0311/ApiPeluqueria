using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Model
{
    public class Reserva
    {
        [Key]
        public int idReserva { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }

        // Claves foráneas
        public int Cliente_idCliente { get; set; }
        public Cliente Cliente { get; set; }

        public int Servicio_idServicio { get; set; }
        public Servicio Servicio { get; set; }

        public int Asignacion_idAsignacion { get; set; }
        public Asignacion Asignacion { get; set; }

        public int Estado_idEstado { get; set; }
        public Estado Estado { get; set; }




    }
}
