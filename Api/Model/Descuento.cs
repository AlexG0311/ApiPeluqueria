using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Model
{
    public class Descuento
    {
        [Key]
        public int IdDescuento { get; set; }
        public decimal Porcentaje { get; set; }

        // Fecha de inicio y fin del descuento
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        // Relación con Producto
        [ForeignKey("Producto")]
        public int producto_idProducto { get; set; }
        public Producto Producto { get; set; }
    }

}
