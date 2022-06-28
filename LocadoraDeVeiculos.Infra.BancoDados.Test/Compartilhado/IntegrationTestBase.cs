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
            Db.ExecutarSql("DELETE FROM TBFUNCIONARIO; DBCC CHECKIDENT(TBFUNCIONARIO, RESEED, 0)");
            Db.ExecutarSql("DELETE FROM TBPESSOAJURIDICA; DBCC CHECKIDENT (TBPESSOAJURIDICA, RESEED, 0)");
            Db.ExecutarSql("DELETE FROM TBPESSOAFISICA; DBCC CHECKIDENT (TBPESSOAFISICA, RESEED, 0)");
            Db.ExecutarSql("DELETE FROM TBTAXA; DBCC CHECKIDENT(TBTAXA, RESEED, 0)");
        }
    }
}