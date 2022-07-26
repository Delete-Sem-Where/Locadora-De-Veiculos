using LocadoraDeVeiculos.Infra.Logging;
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
            ConfiguracaoLogsLocadora.ConfigurarEscritaLogs();
            ApplicationConfiguration.Initialize();

            var serviceLocatorAutofac = new ServiceLocatorAutofac();

            Application.Run(new TelaPrincipalForm(serviceLocatorAutofac));
        }
    }
}