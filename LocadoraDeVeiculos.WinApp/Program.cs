using LocadoraDeVeiculos.Infra.Logging;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using LocadoraDeVeiculos.WinApp.Compartilhado.ServiceLocator;

namespace LocadoraDeVeiculos.WinApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MigradorBancoDadosLocadoraDeVeiculos.AtualizarBancoDados();
            ConfiguracaoLogsLocadora.ConfigurarEscritaLogs();
            ApplicationConfiguration.Initialize();

            var serviceLocatorAutofac = new ServiceLocatorAutofac();

            Application.Run(new TelaPrincipalForm(serviceLocatorAutofac));
        }
    }
}