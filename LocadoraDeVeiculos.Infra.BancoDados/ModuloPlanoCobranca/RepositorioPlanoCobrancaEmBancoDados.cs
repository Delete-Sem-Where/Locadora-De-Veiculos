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
        //METER OS INNER JOIN
        protected override string sqlInserir =>
            @"INSERT INTO [TBPLANOCOBRANCA]
                (
                    [GRUPOVEICULOS_ID],       
                    [MODALIDADEPLANOCOBRANCA], 
                    [VALORDIARIA],
                    [LIMITEKM],                    
                    [VALORKM]         
                )
            VALUES
                (
                    @GRUPOVEICULOS_ID,
                    @MODALIDADEPLANOCOBRANCA,
                    @VALORDIARIA,
                    @LIMITEKM,
                    @VALORKM
                ); SELECT SCOPE_IDENTITY();";

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

        private string sqlSelecionarPorGrupo =>
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
                    [GRUPOVEICULOS_ID] = @GRUPOVEICULOS_ID";

        private string sqlSelecionarPorModalidadePlano =>
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
                    [MODALIDADEPLANOCOBRANCA] = @MODALIDADEPLANOCOBRANCA";


        public PlanoCobranca SelecionarPlanoPorGrupo(int id)
        {
            return SelecionarPorParametro(sqlSelecionarPorGrupo, new SqlParameter("GRUPOVEICULOS_ID", id));
        }

        public PlanoCobranca SelecionarPlanoPorTipoPlano(ModalidadePlanoCobranca tipoPlano)
        {
            return SelecionarPorParametro(sqlSelecionarPorModalidadePlano, new SqlParameter("MODALIDADEPLANOCOBRANCA", tipoPlano));
        }
    }
}
