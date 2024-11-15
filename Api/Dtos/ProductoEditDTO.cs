using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public class ProductoEditDTO
    {
        [Key]
        public int idProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stok { get; set; }
        public string Img { get; set; }
    }
}
