using Microsoft.AspNetCore.Identity;

namespace SistemaCajaUnapec.Models
{
    public class Usuario : IdentityUser
    {
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public bool Activo { get; set; }
    }
}
