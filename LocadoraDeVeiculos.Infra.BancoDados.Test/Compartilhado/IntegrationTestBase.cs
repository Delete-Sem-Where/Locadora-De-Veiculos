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
            //Deletar tabelas do banco aqui
            Db.ExecutarSql("DELETE FROM TBPESSOAFISICA; DBCC CHECKIDENT (TBPESSOAFISICA, RESEED, 0)");
        }
    }
}
