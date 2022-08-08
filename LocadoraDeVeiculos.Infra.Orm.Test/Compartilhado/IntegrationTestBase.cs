using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;

namespace LocadoraDeVeiculos.Infra.Orm.Test
{
    public class IntegrationTestBase
    {
        public IntegrationTestBase()
        {
            Db.ExecutarSql("DELETE FROM TBLOCACAO;");
            Db.ExecutarSql("DELETE FROM TBCONDUTOR;");
            Db.ExecutarSql("DELETE FROM TBCLIENTE;");
            Db.ExecutarSql("DELETE FROM TBVEICULOS;");
            Db.ExecutarSql("DELETE FROM TBPLANOCOBRANCA;");
            Db.ExecutarSql("DELETE FROM TBGRUPOVEICULOS;");
            Db.ExecutarSql("DELETE FROM TBTAXA;");
            Db.ExecutarSql("DELETE FROM TBFUNCIONARIO;");
        }
    }
}