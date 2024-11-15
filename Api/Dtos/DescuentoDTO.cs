namespace Api.Dtos
{
    public class DescuentoDTO
    {

        public int IdDescuento { get; set; }
        public decimal Porcentaje { get; set; }

        // Nuevas propiedades de fecha de inicio y fin
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        // Solo el ID del producto relacionado
        public int producto_idProducto { get; set; }
    }
}
