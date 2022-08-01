using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    public partial class AddTBLocacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LocacaoId",
                table: "TBTaxa",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TBLocacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CondutorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoVeiculosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanoCobrancaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataLocacao = table.Column<DateTime>(type: "date", nullable: false),
                    DataDevolucaoPrevista = table.Column<DateTime>(type: "date", nullable: false),
                    ValorTotalPrevisto = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLocacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBCliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TBCliente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBCondutor_CondutorId",
                        column: x => x.CondutorId,
                        principalTable: "TBCondutor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBGrupoVeiculos_GrupoVeiculosId",
                        column: x => x.GrupoVeiculosId,
                        principalTable: "TBGrupoVeiculos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBPlanoCobranca_PlanoCobrancaId",
                        column: x => x.PlanoCobrancaId,
                        principalTable: "TBPlanoCobranca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBVeiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "TBVeiculos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBTaxa_LocacaoId",
                table: "TBTaxa",
                column: "LocacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_ClienteId",
                table: "TBLocacao",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_CondutorId",
                table: "TBLocacao",
                column: "CondutorId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_GrupoVeiculosId",
                table: "TBLocacao",
                column: "GrupoVeiculosId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_PlanoCobrancaId",
                table: "TBLocacao",
                column: "PlanoCobrancaId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_VeiculoId",
                table: "TBLocacao",
                column: "VeiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBTaxa_TBLocacao_LocacaoId",
                table: "TBTaxa",
                column: "LocacaoId",
                principalTable: "TBLocacao",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBTaxa_TBLocacao_LocacaoId",
                table: "TBTaxa");

            migrationBuilder.DropTable(
                name: "TBLocacao");

            migrationBuilder.DropIndex(
                name: "IX_TBTaxa_LocacaoId",
                table: "TBTaxa");

            migrationBuilder.DropColumn(
                name: "LocacaoId",
                table: "TBTaxa");
        }
    }
}
