using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    public partial class AddModuloVeiculos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBVeiculos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Modelo = table.Column<string>(type: "varchar(65)", nullable: false),
                    Marca = table.Column<string>(type: "varchar(20)", nullable: false),
                    Placa = table.Column<string>(type: "varchar(7)", nullable: false),
                    Ano = table.Column<string>(type: "varchar(4)", nullable: false),
                    Cor = table.Column<string>(type: "varchar(40)", nullable: false),
                    TipoCombustivel = table.Column<string>(type: "varchar(30)", nullable: false),
                    QuilometroPercorrido = table.Column<string>(type: "varchar(8)", nullable: false),
                    CapacidadeTanque = table.Column<string>(type: "varchar(8)", nullable: false),
                    GrupoVeiculosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBVeiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBVeiculos_TBGrupoVeiculos_GrupoVeiculosId",
                        column: x => x.GrupoVeiculosId,
                        principalTable: "TBGrupoVeiculos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBVeiculos_GrupoVeiculosId",
                table: "TBVeiculos",
                column: "GrupoVeiculosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBVeiculos");
        }
    }
}
