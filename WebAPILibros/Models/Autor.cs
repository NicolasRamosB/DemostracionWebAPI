using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json.Serialization;

namespace WebAPILibros.Models
{
    [Table("Autor")]
    public class Autor
    {
        [Key]
        public int IdAutor { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Apellido { get; set; }

        [Range(18, 110, ErrorMessage = "Solo Mayores de 18")]
        public int ? Edad { get; set; }


        public List<Libro> Libros { get; set; }

    }
}
