using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.Model
{
    public class Servicio
    {

        [Key]
        public int idServicio { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public TimeSpan Duracion { get; set; }
        public string Img { get; set; }

        // Relación uno a muchos con ReseñaServicio
      
        public ICollection<ReseñaServicio> ReseñasServicio { get; set; }
      
        // Relación uno a muchos con Reserva
        public ICollection<Reserva> Reservas { get; set; }
    }
}
