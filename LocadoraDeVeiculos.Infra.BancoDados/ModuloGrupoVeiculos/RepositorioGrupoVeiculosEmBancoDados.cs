using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDados.ModuloGruposVeiculos
{
    public class RepositorioGrupoVeiculosEmBancoDados :
        RepositorioBase<GrupoVeiculos, MapeadorGrupoVeiculos>,
        IRepositorioGrupoVeiculos
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBGRUPOVEICULOS] 
                (
                    [ID],
                    [NOME]
	            )
	            VALUES
                (
                    @ID,
                    @NOME
                );";

        protected override string sqlEditar =>
            @"UPDATE [TBGRUPOVEICULOS]	
		        SET
			        [NOME] = @NOME
		        WHERE
			        [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBGRUPOVEICULOS]
		        WHERE
			        [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
		            [ID], 
		            [NOME]
	            FROM 
		            [TBGRUPOVEICULOS]";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
		            [ID], 
		            [NOME]
	            FROM 
		            [TBGRUPOVEICULOS]
		        WHERE
                    [ID] = @ID";

        private string sqlSelecionarPorNome =>
            @"SELECT 
		            [ID], 
		            [NOME]
	            FROM 
		            [TBGRUPOVEICULOS]
		        WHERE
                    [NOME] = @NOME";

        public GrupoVeiculos SelecionarGrupoVeiculosPorNome(string nome)
        {
            return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("NOME", nome));
        }
    }
}
