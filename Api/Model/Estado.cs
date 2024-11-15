using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Model
{
    public class Estado
    {
        [Key]
        public int idEstado { get; set; }
        public string Descripcion { get; set; }

        // Relación uno a muchos con Reserva
        public ICollection<Reserva> Reservas { get; set; }

    }
}
