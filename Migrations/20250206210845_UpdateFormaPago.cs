using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCajaUnapec.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFormaPago : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "FormasPago",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "FormasPago",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "FormasPago");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "FormasPago");
        }
    }
}
