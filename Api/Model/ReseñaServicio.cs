using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Model
{
    public class ReseñaServicio
    {

        [Key]
        public int idReseñaServicio { get; set; }
        public int Estrellas { get; set; }
        public DateTime Fecha { get; set; }

        // Claves foráneas
        public int servicio_idServicio { get; set; }
        public Servicio Servicio { get; set; }

        public int cliente_idCliente { get; set; }
        public Cliente Cliente { get; set; }
    }
}
