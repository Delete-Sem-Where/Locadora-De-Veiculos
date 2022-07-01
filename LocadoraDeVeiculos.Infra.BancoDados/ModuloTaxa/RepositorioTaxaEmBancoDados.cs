using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;

namespace LocadoraDeVeiculos.Infra.BancoDados.ModuloTaxa
{
    public class RepositorioTaxaEmBancoDados : 
        RepositorioBase<Taxa, MapeadorTaxa>,        
        IRepositorioTaxa
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBTAXA] 
                (
                    [DESCRICAO],
                    [VALOR]

	            )
	            VALUES
                (
                    @DESCRICAO,
                    @VALOR

                );SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @"UPDATE [TBTAXA]	
		        SET
			        [DESCRICAO] = @DESCRICAO,
			        [VALOR] = @VALOR
		        WHERE
			        [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBTAXA]
		        WHERE
			        [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
		            [ID], 
		            [DESCRICAO],
		            [VALOR]
	            FROM 
		            [TBTAXA]";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
		            [ID], 
		            [DESCRICAO],
		            [VALOR]
	            FROM 
		            [TBTAXA]
		        WHERE
                    [ID] = @ID";

        private string sqlSelecionarPorNome =>
            @"SELECT 
		            [ID], 
		            [DESCRICAO],
		            [VALOR]
	            FROM 
		            [TBTAXA]
		        WHERE
                    [NOME] = @NOME";

        public Taxa SelecionarTaxaPorDescricao(string descricao)
        {
            return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("DESCRICAO", descricao));
        }
    }
}
