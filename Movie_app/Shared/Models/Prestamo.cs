using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Movie_app.Shared.Models
{
    public partial class Prestamo
    {
        public int Id { get; set; }
        public int IdPelicula { get; set; }
        [Required(ErrorMessage = "Prestatario necesario...")]
        public string Prestatario { get; set; }
        public DateTime? FechaPrestamo { get; set; }

        public virtual Pelicula IdPeliculaNavigation { get; set; }
    }
}
