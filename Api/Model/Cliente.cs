using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.Model
{
    public class Cliente
    {
        [Key]
        public int idCliente { get; set; }

        [ForeignKey("Usuario")]


        // Relación muchos a muchos con Producto a través de ClienteProducto
        public ICollection<clienteproducto> Productos { get; set; }
        public int Usuario_idUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<ReseñaProducto> Reseñas { get; set; }
    }

}
