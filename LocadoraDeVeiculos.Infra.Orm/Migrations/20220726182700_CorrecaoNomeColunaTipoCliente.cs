using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    public partial class CorrecaoNomeColunaTipoCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoCliente",
                table: "TBCliente",
                newName: "Tipo_Cliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tipo_Cliente",
                table: "TBCliente",
                newName: "TipoCliente");
        }
    }
}
