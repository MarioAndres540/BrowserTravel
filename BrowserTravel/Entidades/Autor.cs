using System.ComponentModel.DataAnnotations;

namespace BrowserTravel.Entidades
{
    public class Autor
    {
        public int Id { get; set; }
        [StringLength(45)]
        [Required]
        public string Nombre { get; set; }
        [StringLength(45)]
        [Required]
        public string Apellido { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
