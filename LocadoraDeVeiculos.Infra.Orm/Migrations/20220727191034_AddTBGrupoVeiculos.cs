using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    public partial class AddTBGrupoVeiculos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBCondutor_TBCliente_ClienteId",
                table: "TBCondutor");

            migrationBuilder.DropForeignKey(
                name: "FK_TBPlanoCobranca_GrupoVeiculos_GrupoVeiculosId",
                table: "TBPlanoCobranca");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GrupoVeiculos",
                table: "GrupoVeiculos");

            migrationBuilder.RenameTable(
                name: "GrupoVeiculos",
                newName: "TBGrupoVeiculos");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "TBGrupoVeiculos",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TBGrupoVeiculos",
                table: "TBGrupoVeiculos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBCondutor_TBCliente_ClienteId",
                table: "TBCondutor",
                column: "ClienteId",
                principalTable: "TBCliente",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBPlanoCobranca_TBGrupoVeiculos_GrupoVeiculosId",
                table: "TBPlanoCobranca",
                column: "GrupoVeiculosId",
                principalTable: "TBGrupoVeiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBCondutor_TBCliente_ClienteId",
                table: "TBCondutor");

            migrationBuilder.DropForeignKey(
                name: "FK_TBPlanoCobranca_TBGrupoVeiculos_GrupoVeiculosId",
                table: "TBPlanoCobranca");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TBGrupoVeiculos",
                table: "TBGrupoVeiculos");

            migrationBuilder.RenameTable(
                name: "TBGrupoVeiculos",
                newName: "GrupoVeiculos");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "GrupoVeiculos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GrupoVeiculos",
                table: "GrupoVeiculos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBCondutor_TBCliente_ClienteId",
                table: "TBCondutor",
                column: "ClienteId",
                principalTable: "TBCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TBPlanoCobranca_GrupoVeiculos_GrupoVeiculosId",
                table: "TBPlanoCobranca",
                column: "GrupoVeiculosId",
                principalTable: "GrupoVeiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
