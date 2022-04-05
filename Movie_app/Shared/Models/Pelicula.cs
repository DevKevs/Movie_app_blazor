using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Movie_app.Shared.Models
{
    public partial class Pelicula
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Titulo necesario...")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Sinopsis necesaria...")]
        public string Sinopsis { get; set; }
        [Required(ErrorMessage = "Genero necesario...")]
        public int IdGenero { get; set; }
        [Required(ErrorMessage = "Fecha de salida necesaria...")]
        public string FechaSalida { get; set; }
        [Required(ErrorMessage = "Puntuacion necesaria...")]
        public string Puntuacion { get; set; }
        public string Imagen { get; set; }
        public string Estado { get; set; }
        public string? Tipo { get; set; }

        public virtual Genero IdGeneroNavigation { get; set; }
        public virtual Prestamo Prestamo { get; set; }
    }
}
