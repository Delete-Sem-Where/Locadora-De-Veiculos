using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDados.Test.Compartilhado
{
    public class IntegrationTestBase
    {
        public IntegrationTestBase()
        {
            Db.ExecutarSql("DELETE FROM TBFUNCIONARIO;");
            Db.ExecutarSql("DELETE FROM TBPESSOAJURIDICA;");
            Db.ExecutarSql("DELETE FROM TBPESSOAFISICA;");
            Db.ExecutarSql("DELETE FROM TBTAXA;");
            Db.ExecutarSql("DELETE FROM TBPLANOCOBRANCA;");
            Db.ExecutarSql("DELETE FROM TBGRUPOVEICULOS;");
            Db.ExecutarSql("DELETE FROM TBCONDUTOR;");
            Db.ExecutarSql("DELETE FROM TBCLIENTE;");
        }
    }
}