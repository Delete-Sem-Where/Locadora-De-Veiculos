using Autofac;
using Configs;
using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Aplicacao.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.Compartilhado;
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
using LocadoraDeVeiculos.Infra.Orm.ModuloCliente;
using LocadoraDeVeiculos.Infra.Orm.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Orm.ModuloFuncionario;
using LocadoraDeVeiculos.WinApp.ModuloCliente;
using LocadoraDeVeiculos.WinApp.ModuloCondutor;
using LocadoraDeVeiculos.WinApp.ModuloConfiguracao;
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

            builder.Register((x) => new ConfiguracaoAplicacao().ConnectionStrings)
                 .As<ConnectionStrings>()
                 .SingleInstance();

            builder.RegisterType<ConfiguracaoAplicacao>()
                .SingleInstance();

            builder.RegisterType<LocadoraDeVeiculosDbContext>().As<IContextoPersistencia>()
                .InstancePerLifetimeScope();

            builder.RegisterType<RepositorioClienteOrm>().As<IRepositorioCliente>();
            builder.RegisterType<ServicoCliente>();
            builder.RegisterType<ControladorCliente>();

            builder.RegisterType<RepositorioGrupoVeiculosEmBancoDados>().As<IRepositorioGrupoVeiculos>();
            builder.RegisterType<ServicoGrupoVeiculos>();
            builder.RegisterType<ControladorGrupoVeiculos>();

            builder.RegisterType<RepositorioFuncionarioOrm>().As<IRepositorioFuncionario>();
            builder.RegisterType<ServicoFuncionario>();
            builder.RegisterType<ControladorFuncionario>();

            builder.RegisterType<RepositorioCondutorOrm>().As<IRepositorioCondutor>();
            builder.RegisterType<ServicoCondutor>();
            builder.RegisterType<ControladorCondutor>();

            builder.RegisterType<RepositorioTaxaEmBancoDados>().As<IRepositorioTaxa>();
            builder.RegisterType<ServicoTaxa>();
            builder.RegisterType<ControladorTaxa>();

            builder.RegisterType<RepositorioPlanoCobrancaEmBancoDados>().As<IRepositorioPlanoCobranca>();
            builder.RegisterType<ServicoPlanoCobranca>();
            builder.RegisterType<ControladorPlanoCobranca>();

            builder.RegisterType<ControladorConfiguracao>().AsSelf();

            container = builder.Build();
        }

        public T Get<T>() where T : ControladorBase
        {
            return container.Resolve<T>();
        }
    }
}
