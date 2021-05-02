using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppiDiscotienda.Migrations
{
    public partial class agregar_campoEstadotablaDiscos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Discos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Discos");
        }
    }
}
