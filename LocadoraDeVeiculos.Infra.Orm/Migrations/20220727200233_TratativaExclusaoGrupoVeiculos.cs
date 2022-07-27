using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    public partial class TratativaExclusaoGrupoVeiculos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBPlanoCobranca_TBGrupoVeiculos_GrupoVeiculosId",
                table: "TBPlanoCobranca");

            migrationBuilder.AddForeignKey(
                name: "FK_TBPlanoCobranca_TBGrupoVeiculos_GrupoVeiculosId",
                table: "TBPlanoCobranca",
                column: "GrupoVeiculosId",
                principalTable: "TBGrupoVeiculos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBPlanoCobranca_TBGrupoVeiculos_GrupoVeiculosId",
                table: "TBPlanoCobranca");

            migrationBuilder.AddForeignKey(
                name: "FK_TBPlanoCobranca_TBGrupoVeiculos_GrupoVeiculosId",
                table: "TBPlanoCobranca",
                column: "GrupoVeiculosId",
                principalTable: "TBGrupoVeiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
