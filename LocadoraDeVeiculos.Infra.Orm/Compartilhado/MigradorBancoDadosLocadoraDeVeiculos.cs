using Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.Compartilhado
{
    public class MigradorBancoDadosLocadoraDeVeiculos
    {
        public static void AtualizarBancoDados()
        {
            var configuracaoAplicacao = new ConfiguracaoAplicacao();

            var db = new LocadoraDeVeiculosDbContext(configuracaoAplicacao.ConnectionStrings);

            var migracoesPendentes = db.Database.GetPendingMigrations();

            if (migracoesPendentes.Count() > 0)
                db.Database.Migrate();
        }
    }
}
