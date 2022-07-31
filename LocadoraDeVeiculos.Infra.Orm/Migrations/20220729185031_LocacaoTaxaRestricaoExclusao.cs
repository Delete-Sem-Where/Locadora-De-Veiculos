using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    public partial class LocacaoTaxaRestricaoExclusao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocacaoTaxa_TBTaxa_TaxasSelecionadasId",
                table: "LocacaoTaxa");

            migrationBuilder.AddForeignKey(
                name: "FK_LocacaoTaxa_TBTaxa_TaxasSelecionadasId",
                table: "LocacaoTaxa",
                column: "TaxasSelecionadasId",
                principalTable: "TBTaxa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocacaoTaxa_TBTaxa_TaxasSelecionadasId",
                table: "LocacaoTaxa");

            migrationBuilder.AddForeignKey(
                name: "FK_LocacaoTaxa_TBTaxa_TaxasSelecionadasId",
                table: "LocacaoTaxa",
                column: "TaxasSelecionadasId",
                principalTable: "TBTaxa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
