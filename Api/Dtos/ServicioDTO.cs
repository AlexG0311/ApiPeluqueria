﻿using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public class ServicioDTO
    {
        [Key]
        public int IdServicio { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public TimeSpan Duracion { get; set; }
        public string Img { get; set; }
    }
}
