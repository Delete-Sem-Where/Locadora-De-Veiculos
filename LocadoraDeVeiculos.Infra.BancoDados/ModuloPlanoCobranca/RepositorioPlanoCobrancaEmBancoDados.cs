using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDados.ModuloPlanoCobranca
{
    public class RepositorioPlanoCobrancaEmBancoDados :
        RepositorioBase<PlanoCobranca, MapeadorPlanoCobranca>,
        IRepositorioPlanoCobranca
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBPLANOCOBRANCA]
                (
                    [ID],       
                    [GRUPOVEICULOS_ID],       
                    [MODALIDADEPLANOCOBRANCA], 
                    [VALORDIARIA],
                    [LIMITEKM],                    
                    [VALORKM]         
                )
            VALUES
                (
                    @ID,
                    @GRUPOVEICULOS_ID,
                    @MODALIDADEPLANOCOBRANCA,
                    @VALORDIARIA,
                    @LIMITEKM,
                    @VALORKM
                );";

        protected override string sqlEditar =>
            @"UPDATE [TBPLANOCOBRANCA]
                SET
                    [GRUPOVEICULOS_ID] = @GRUPOVEICULOS_ID,
                    [MODALIDADEPLANOCOBRANCA] = @MODALIDADEPLANOCOBRANCA,
                    [VALORDIARIA] = @VALORDIARIA,
                    [LIMITEKM] = @LIMITEKM,
                    [VALORKM] = @VALORKM
                WHERE
                    [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBPLANOCOBRANCA]
                WHERE
                    [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                    [ID],
		            [GRUPOVEICULOS_ID],       
                    [MODALIDADEPLANOCOBRANCA], 
                    [VALORDIARIA],
                    [LIMITEKM],                    
                    [VALORKM]   
	            FROM 
		            [TBPLANOCOBRANCA]
		        WHERE
                    [ID] = @ID";
        protected override string sqlSelecionarTodos =>
            @"SELECT 
                    [ID],
		            [GRUPOVEICULOS_ID],       
                    [MODALIDADEPLANOCOBRANCA], 
                    [VALORDIARIA],
                    [LIMITEKM],                    
                    [VALORKM]   
	            FROM 
		            [TBPLANOCOBRANCA]";

        private string sqlSelecionarPorGrupo_E_Modalidade =>
            @"SELECT
                [ID],
                [GRUPOVEICULOS_ID],       
                [MODALIDADEPLANOCOBRANCA], 
                [VALORDIARIA],
                [LIMITEKM],                    
                [VALORKM]   
            FROM 
                [TBPLANOCOBRANCA]
            WHERE 
                [GRUPOVEICULOS_ID] = @GRUPOVEICULOS_ID
            AND
                [MODALIDADEPLANOCOBRANCA] = @MODALIDADEPLANOCOBRANCA";

        public PlanoCobranca SelecionarPlanoPorGrupo_E_Modalidade(Guid id, ModalidadePlanoCobranca tipoPlano)
        {
            return SelecionarPorVariosParametro(sqlSelecionarPorGrupo_E_Modalidade, new SqlParameter("GRUPOVEICULOS_ID", id), new SqlParameter("MODALIDADEPLANOCOBRANCA", tipoPlano));
        }
    }
}
