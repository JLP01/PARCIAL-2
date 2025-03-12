using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaCajaUnapec.Models;

namespace SistemaCajaUnapec.Data
{
    public class CajaContext : IdentityDbContext<Usuario>
    {
        public CajaContext(DbContextOptions<CajaContext> options) : base(options) { }

        public DbSet<TipoDocumento> TiposDocumentos { get; set; }
        public DbSet<ServicioFacturable> ServiciosFacturables { get; set; }
        public DbSet<FormaPago> FormasPago { get; set; }
        public DbSet<ModalidadPago> ModalidadesPago { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configuración personalizada de Identity para el modelo Usuario
            builder.Entity<Usuario>(entity =>
            {
                entity.Property(u => u.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(u => u.Apellido)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(u => u.Activo)
                    .HasDefaultValue(true);
            });

            // Configuración para la entidad ServicioFacturable
            builder.Entity<ServicioFacturable>(entity =>
            {
                // Configurar el tipo de columna para el campo Precio
                entity.Property(e => e.Precio)
                      .HasColumnType("decimal(18, 2)"); // o HasPrecision(18, 2)
            });

            // Configurar nombres de tablas de Identity si es necesario
            builder.Entity<Usuario>().ToTable("Usuarios");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UsuarioRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UsuarioClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UsuarioLogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("UsuarioTokens");
        }
    }
}
