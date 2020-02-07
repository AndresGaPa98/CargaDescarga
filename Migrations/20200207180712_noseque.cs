using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace scm.Migrations
{
    public partial class noseque : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Empresa",
                table: "Vale");

            migrationBuilder.AddColumn<int>(
                name: "EmpresaIdEmpresa",
                table: "Vale",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FacturaFolioFactura",
                table: "Vale",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    IdEmpresa = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreEmpresa = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.IdEmpresa);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    FolioFactura = table.Column<string>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false),
                    Concepto = table.Column<string>(nullable: false),
                    FechaExpedicion = table.Column<DateTime>(nullable: false),
                    StatusFactura = table.Column<int>(nullable: false),
                    IdEmpresa = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.FolioFactura);
                    table.ForeignKey(
                        name: "FK_Factura_Empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "IdEmpresa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vale_EmpresaIdEmpresa",
                table: "Vale",
                column: "EmpresaIdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Vale_FacturaFolioFactura",
                table: "Vale",
                column: "FacturaFolioFactura");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_IdEmpresa",
                table: "Factura",
                column: "IdEmpresa");

            migrationBuilder.AddForeignKey(
                name: "FK_Vale_Empresa_EmpresaIdEmpresa",
                table: "Vale",
                column: "EmpresaIdEmpresa",
                principalTable: "Empresa",
                principalColumn: "IdEmpresa",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vale_Factura_FacturaFolioFactura",
                table: "Vale",
                column: "FacturaFolioFactura",
                principalTable: "Factura",
                principalColumn: "FolioFactura",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vale_Empresa_EmpresaIdEmpresa",
                table: "Vale");

            migrationBuilder.DropForeignKey(
                name: "FK_Vale_Factura_FacturaFolioFactura",
                table: "Vale");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropIndex(
                name: "IX_Vale_EmpresaIdEmpresa",
                table: "Vale");

            migrationBuilder.DropIndex(
                name: "IX_Vale_FacturaFolioFactura",
                table: "Vale");

            migrationBuilder.DropColumn(
                name: "EmpresaIdEmpresa",
                table: "Vale");

            migrationBuilder.DropColumn(
                name: "FacturaFolioFactura",
                table: "Vale");

            migrationBuilder.AddColumn<string>(
                name: "Empresa",
                table: "Vale",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
