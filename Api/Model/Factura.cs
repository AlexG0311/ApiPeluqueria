using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Model
{
    public class Factura
    {


        [Key]
        public int IdFactura { get; set; }
        public DateTime FechaFactura { get; set; }
        public decimal Total { get; set; }

        // Relación con DetalleFactura
        public ICollection<DetalleFactura> DetallesFactura { get; set; }
    }
}
