using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Movie_app.Shared.Models
{
    public partial class Genero
    {
        public Genero()
        {
            Peliculas = new HashSet<Pelicula>();
        }

        public int Id { get; set; }
        [Required (ErrorMessage ="Nombre de genero necesario...")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "Descripcion necesaria...")]
        public string Descripcion { get; set; }

        public virtual ICollection<Pelicula> Peliculas { get; set; }
    }
}
