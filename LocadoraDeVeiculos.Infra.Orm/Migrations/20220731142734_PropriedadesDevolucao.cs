using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    public partial class PropriedadesDevolucao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataDevolucao",
                table: "TBLocacao",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "EstaAlugado",
                table: "TBLocacao",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NivelTanqueDevolucao",
                table: "TBLocacao",
                type: "int",
                nullable: false,
                defaultValue: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDevolucao",
                table: "TBLocacao");

            migrationBuilder.DropColumn(
                name: "EstaAlugado",
                table: "TBLocacao");

            migrationBuilder.DropColumn(
                name: "NivelTanqueDevolucao",
                table: "TBLocacao");
        }
    }
}
