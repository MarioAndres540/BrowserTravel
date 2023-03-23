using System.ComponentModel.DataAnnotations;

namespace BrowserTravel.Entidades
{
    public class Editorials
    {
        public int Id { get; set; }
        [StringLength(45)]
        [Required]
        public string Nombre { get; set; }
        [StringLength(45)]
        [Required]
        public string Sede { get; set; }
    }
}
