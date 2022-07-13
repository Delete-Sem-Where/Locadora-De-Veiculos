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
                    [ID],
                    [DESCRICAO],
                    [VALOR],
                    [TIPOCALCULO]

	            )
	            VALUES
                (
                    @ID,
                    @DESCRICAO,
                    @VALOR,
                    @TIPOCALCULO


                );";

        protected override string sqlEditar =>
            @"UPDATE [TBTAXA]	
		        SET
			        [DESCRICAO] = @DESCRICAO,
			        [VALOR] = @VALOR,
                    [TIPOCALCULO] = @TIPOCALCULO
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
		            [VALOR],
                    [TIPOCALCULO] 
	            FROM 
		            [TBTAXA]";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
		            [ID], 
		            [DESCRICAO],
		            [VALOR],
                    [TIPOCALCULO] 

	            FROM 
		            [TBTAXA]
		        WHERE
                    [ID] = @ID";

        private string sqlSelecionarPorNome =>
            @"SELECT 
		            [ID], 
		            [DESCRICAO],
		            [VALOR],
                    [TIPOCALCULO]
	            FROM 
		            [TBTAXA]
		        WHERE
                    [DESCRICAO] = @DESCRICAO";

        public Taxa SelecionarTaxaPorDescricao(string descricao)
        {
            return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("DESCRICAO", descricao));
        }
    }
}
