using Autofac;
using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Aplicacao.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloCliente;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloCondutor;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloGruposVeiculos;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloTaxa;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using LocadoraDeVeiculos.WinApp.ModuloCliente;
using LocadoraDeVeiculos.WinApp.ModuloCondutor;
using LocadoraDeVeiculos.WinApp.ModuloFuncionario;
using LocadoraDeVeiculos.WinApp.ModuloGruposVeiculos;
using LocadoraDeVeiculos.WinApp.ModuloPlanoCobranca;
using LocadoraDeVeiculos.WinApp.ModuloTaxas;
using Microsoft.Extensions.Configuration;

namespace LocadoraDeVeiculos.WinApp.Compartilhado.ServiceLocator
{
    public class ServiceLocatorAutofac : IServiceLocator
    {
        private readonly IContainer container;

        public ServiceLocatorAutofac()
        {
            var builder = new ContainerBuilder();

            var configuracao = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("ConfiguracaoAplicacao.json")
                 .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            var contextoDadosOrm = new LocadoraDeVeiculosDbContext(connectionString);

            builder.RegisterType<RepositorioClienteEmBancoDados>().As<IRepositorioCliente>();
            builder.RegisterType<ServicoCliente>().AsSelf();
            builder.RegisterType<ControladorCliente>().AsSelf();

            builder.RegisterType<RepositorioGrupoVeiculosEmBancoDados>().As<IRepositorioGrupoVeiculos>();
            builder.RegisterType<ServicoGrupoVeiculos>().AsSelf();
            builder.RegisterType<ControladorGrupoVeiculos>().AsSelf();

            builder.RegisterType<RepositorioFuncionarioEmBancoDados>().As<IRepositorioFuncionario>();
            builder.RegisterType<ServicoFuncionario>().AsSelf().WithParameter("contextoPersistencia", contextoDadosOrm);
            builder.RegisterType<ControladorFuncionario>().AsSelf();

            builder.RegisterType<RepositorioCondutorEmBancoDados>().As<IRepositorioCondutor>();
            builder.RegisterType<ServicoCondutor>().AsSelf();
            builder.RegisterType<ControladorCondutor>().AsSelf();

            builder.RegisterType<RepositorioTaxaEmBancoDados>().As<IRepositorioTaxa>();
            builder.RegisterType<ServicoTaxa>().AsSelf();
            builder.RegisterType<ControladorTaxa>().AsSelf();

            builder.RegisterType<RepositorioPlanoCobrancaEmBancoDados>().As<IRepositorioPlanoCobranca>();
            builder.RegisterType<ServicoPlanoCobranca>().AsSelf();
            builder.RegisterType<ControladorPlanoCobranca>().AsSelf();

            container = builder.Build();
        }

        public T Get<T>() where T : ControladorBase
        {
            return container.Resolve<T>();
        }
    }
}
