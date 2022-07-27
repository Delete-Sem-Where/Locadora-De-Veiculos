using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    public partial class AddTBTaxa_e_TBPlanoCobranca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GrupoVeiculos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoVeiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBTaxa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    TipoCalculo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTaxa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBPlanoCobranca",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoVeiculosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModalidadePlanoCobranca = table.Column<int>(type: "int", nullable: false),
                    ValorDiaria = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    LimiteKm = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    ValorKm = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPlanoCobranca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBPlanoCobranca_GrupoVeiculos_GrupoVeiculosId",
                        column: x => x.GrupoVeiculosId,
                        principalTable: "GrupoVeiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBPlanoCobranca_GrupoVeiculosId",
                table: "TBPlanoCobranca",
                column: "GrupoVeiculosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBPlanoCobranca");

            migrationBuilder.DropTable(
                name: "TBTaxa");

            migrationBuilder.DropTable(
                name: "GrupoVeiculos");
        }
    }
}
