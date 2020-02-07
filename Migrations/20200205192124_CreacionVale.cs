using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace scm.Migrations
{
    public partial class CreacionVale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegistroVales",
                columns: table => new
                {
                    IdRegistroVale = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(nullable: false),
                    idEmpleado = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroVales", x => x.IdRegistroVale);
                    table.ForeignKey(
                        name: "FK_RegistroVales_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistroVales_Empleados_idEmpleado",
                        column: x => x.idEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "IdEmpleado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vale",
                columns: table => new
                {
                    FolioVale = table.Column<string>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false),
                    FechaExpedicionVale = table.Column<decimal>(nullable: false),
                    Empresa = table.Column<string>(nullable: true),
                    RegistroValeIdRegistroVale = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vale", x => x.FolioVale);
                    table.ForeignKey(
                        name: "FK_Vale_RegistroVales_RegistroValeIdRegistroVale",
                        column: x => x.RegistroValeIdRegistroVale,
                        principalTable: "RegistroVales",
                        principalColumn: "IdRegistroVale",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistroVales_UsuarioId",
                table: "RegistroVales",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroVales_idEmpleado",
                table: "RegistroVales",
                column: "idEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Vale_RegistroValeIdRegistroVale",
                table: "Vale",
                column: "RegistroValeIdRegistroVale");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vale");

            migrationBuilder.DropTable(
                name: "RegistroVales");
        }
    }
}
