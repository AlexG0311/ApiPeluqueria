using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Api.Model
{
    

        public class Producto
        {
        [Key]
        public int idProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stok { get; set; }
        public string Img { get; set; }

        // Relaciones

        
        public ICollection<clienteproducto> ClienteProductos { get; set; }
        // Relación con DetalleFactura
        public ICollection<DetalleFactura> DetallesFactura { get; set; }
        public ICollection<Descuento> Descuentos { get; set; }
        public ICollection<ReseñaProducto> ReseñasProducto { get; set; }
    }

}
