using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace scm.Migrations
{
    public partial class retenciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaExpedicionVale",
                table: "Vale",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AddColumn<decimal>(
                name: "IVAAplicado",
                table: "RegistroVales",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Retenciones",
                columns: table => new
                {
                    Key = table.Column<string>(nullable: false),
                    Value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retenciones", x => x.Key);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Retenciones");

            migrationBuilder.DropColumn(
                name: "IVAAplicado",
                table: "RegistroVales");

            migrationBuilder.AlterColumn<decimal>(
                name: "FechaExpedicionVale",
                table: "Vale",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
