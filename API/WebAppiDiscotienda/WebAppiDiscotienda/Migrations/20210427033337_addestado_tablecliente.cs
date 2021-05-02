using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppiDiscotienda.Migrations
{
    public partial class addestado_tablecliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Clientes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Clientes");
        }
    }
}
