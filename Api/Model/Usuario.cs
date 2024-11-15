using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;




namespace Api.Model
{
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string Telefono { get; set; }

        // Relaciones uno a uno
        public Cliente Cliente { get; set; }
        public Empleado Empleado { get; set; }

        // Relación muchos a muchos con Rol
        public ICollection<Rolusuario> RolesUsuario { get; set; }
    }



}
