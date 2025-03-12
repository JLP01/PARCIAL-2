using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCajaUnapec.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModalidadPago : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "ModalidadesPago",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "ModalidadesPago",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "ModalidadesPago");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "ModalidadesPago");
        }
    }
}
