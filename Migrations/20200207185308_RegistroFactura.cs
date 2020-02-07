using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace scm.Migrations
{
    public partial class RegistroFactura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "GastosCobranzaInversion",
                table: "RegistroVales",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GastosFacturacion",
                table: "RegistroVales",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GastosSeguridadSocial",
                table: "RegistroVales",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegistroFacturaIdRegistroFactura",
                table: "Factura",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RegistroFactura",
                columns: table => new
                {
                    IdRegistroFactura = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(nullable: false),
                    TotalFactura = table.Column<decimal>(nullable: false),
                    IVAAplicado = table.Column<decimal>(nullable: true),
                    GastosFacturacion = table.Column<decimal>(nullable: true),
                    GastosSeguridadSocial = table.Column<decimal>(nullable: true),
                    IdEmpleado = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroFactura", x => x.IdRegistroFactura);
                    table.ForeignKey(
                        name: "FK_RegistroFactura_Empleados_IdEmpleado",
                        column: x => x.IdEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "IdEmpleado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistroFactura_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Factura_RegistroFacturaIdRegistroFactura",
                table: "Factura",
                column: "RegistroFacturaIdRegistroFactura");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroFactura_IdEmpleado",
                table: "RegistroFactura",
                column: "IdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroFactura_UsuarioId",
                table: "RegistroFactura",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_RegistroFactura_RegistroFacturaIdRegistroFactura",
                table: "Factura",
                column: "RegistroFacturaIdRegistroFactura",
                principalTable: "RegistroFactura",
                principalColumn: "IdRegistroFactura",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factura_RegistroFactura_RegistroFacturaIdRegistroFactura",
                table: "Factura");

            migrationBuilder.DropTable(
                name: "RegistroFactura");

            migrationBuilder.DropIndex(
                name: "IX_Factura_RegistroFacturaIdRegistroFactura",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "GastosCobranzaInversion",
                table: "RegistroVales");

            migrationBuilder.DropColumn(
                name: "GastosFacturacion",
                table: "RegistroVales");

            migrationBuilder.DropColumn(
                name: "GastosSeguridadSocial",
                table: "RegistroVales");

            migrationBuilder.DropColumn(
                name: "RegistroFacturaIdRegistroFactura",
                table: "Factura");
        }
    }
}
