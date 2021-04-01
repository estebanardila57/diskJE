using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace proyectodisctienda.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombrecli = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cedulacli = table.Column<int>(type: "int", nullable: false),
                    Telefonocli = table.Column<int>(type: "int", nullable: false),
                    Direccioncli = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcioncd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usersystems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcioncargo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nomuser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Idcliente = table.Column<int>(type: "int", nullable: false),
                    clienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usersystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usersystems_Clientes_clienteId",
                        column: x => x.clienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fechainiciopres = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fechafinalpres = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Idclientepres = table.Column<int>(type: "int", nullable: false),
                    IdclipresId = table.Column<int>(type: "int", nullable: true),
                    Codiodisco = table.Column<int>(type: "int", nullable: false),
                    CodDiskId = table.Column<int>(type: "int", nullable: true),
                    Idusers = table.Column<int>(type: "int", nullable: false),
                    iduserystemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prestamos_Clientes_IdclipresId",
                        column: x => x.IdclipresId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prestamos_Discos_CodDiskId",
                        column: x => x.CodDiskId,
                        principalTable: "Discos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prestamos_Usersystems_iduserystemId",
                        column: x => x.iduserystemId,
                        principalTable: "Usersystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sanciones",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descripcionretraso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecharetrasouser = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Iduser = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: true),
                    idprest = table.Column<int>(type: "int", nullable: false),
                    idprestamosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sanciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sanciones_Prestamos_idprestamosId",
                        column: x => x.idprestamosId,
                        principalTable: "Prestamos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sanciones_Usersystems_userId",
                        column: x => x.userId,
                        principalTable: "Usersystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_CodDiskId",
                table: "Prestamos",
                column: "CodDiskId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_IdclipresId",
                table: "Prestamos",
                column: "IdclipresId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_iduserystemId",
                table: "Prestamos",
                column: "iduserystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Sanciones_idprestamosId",
                table: "Sanciones",
                column: "idprestamosId");

            migrationBuilder.CreateIndex(
                name: "IX_Sanciones_userId",
                table: "Sanciones",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Usersystems_clienteId",
                table: "Usersystems",
                column: "clienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sanciones");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Discos");

            migrationBuilder.DropTable(
                name: "Usersystems");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
