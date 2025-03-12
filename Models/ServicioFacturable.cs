using System.ComponentModel.DataAnnotations;

namespace SistemaCajaUnapec.Models
{
    public class ServicioFacturable
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(200)]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        public decimal Precio { get; set; }
    }
}




    