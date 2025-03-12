using System.ComponentModel.DataAnnotations;

namespace SistemaCajaUnapec.Models
{
    public class ModalidadPago
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public int NumeroCuotas { get; set; }

        [Required]
        [StringLength(200)]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        public bool Estado { get; set; }
    }
}
