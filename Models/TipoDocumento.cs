using System.ComponentModel.DataAnnotations;

namespace SistemaCajaUnapec.Models
{
    public class TipoDocumento
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Descripcion { get; set; } = string.Empty;  // ✅ Corrección aquí

        [Required]
        public bool Estado { get; set; } = true; // ✅ Estado sigue siendo bool
    }


}
