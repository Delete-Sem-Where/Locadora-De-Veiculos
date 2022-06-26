using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;

namespace LocadoraDeVeiculos.Infra.BancoDados.Test.Compartilhado
{
    public class IntegrationTestBase
    {
        public IntegrationTestBase()
        {
            Db.ExecutarSql("DELETE FROM TBTAXA; DBCC CHECKIDENT(TBTAXA, RESEED, 0)");
        }
    }
}