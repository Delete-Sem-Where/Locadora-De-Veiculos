using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LocadoraDeVeiculos.Infra.Orm.Compartilhado
{
    public class LocadoraDeVeiculosDbContextFactory : IDesignTimeDbContextFactory<LocadoraDeVeiculosDbContext>
    {
        public LocadoraDeVeiculosDbContext CreateDbContext(string[] args)
        {
            var configuracao = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("ConfiguracaoAplicacao.json")
             .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            return new LocadoraDeVeiculosDbContext(connectionString);
        }
    }
}
