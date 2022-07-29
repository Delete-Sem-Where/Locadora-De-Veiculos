using LocadoraDeVeiculos.Infra.BancoDados.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloPessoaJuridica;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloPessoaFisica;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloTaxa;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloPlanoCobranca;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.WinApp.ModuloFuncionario;
using LocadoraDeVeiculos.WinApp.ModuloPessoaJuridica;
using LocadoraDeVeiculos.WinApp.ModuloPessoaFisica;
using LocadoraDeVeiculos.WinApp.ModuloTaxas;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloGruposVeiculos;
using LocadoraDeVeiculos.WinApp.ModuloGruposVeiculos;
using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Aplicacao.ModuloPessoaJuridica;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Aplicacao.ModuloPessoaFisica;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxas;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloCliente;
using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
using LocadoraDeVeiculos.WinApp.ModuloCliente;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloCondutor;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.WinApp.ModuloCondutor;
using LocadoraDeVeiculos.Aplicacao.ModuloPlanoCobranca;
using LocadoraDeVeiculos.WinApp.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloVeiculos;
using LocadoraDeVeiculos.Aplicacao.ModuloVeiculos;
using LocadoraDeVeiculos.WinApp.ModuloVeiculos;
using LocadoraDeVeiculos.WinApp.Compartilhado.ServiceLocator;
using LocadoraDeVeiculos.WinApp.ModuloLocacao;

namespace LocadoraDeVeiculos.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        private ControladorBase controlador;
        private IServiceLocator serviceLocator;

        public TelaPrincipalForm(IServiceLocator serviceLocator)
        {
            InitializeComponent();

            this.serviceLocator = serviceLocator;

            Instancia = this;

            labelRodape.Text = string.Empty;
            labelTipoCadastro.Text = string.Empty;
        }

        public static TelaPrincipalForm Instancia
        {
            get;
            private set;
        }

        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }

        private void funcionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorFuncionario>());
        }

        private void pessoaJurídicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorPessoaJuridica>());
        }

        private void pessoasFísicasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorPessoaFisica>());
        }

        private void taxasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorTaxa>());
        }

        private void grupoVeículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorGrupoVeiculos>());
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorCliente>());
        }

        private void condutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorCondutor>());
        }

        private void planoDeCobrançaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorPlanoCobranca>());
        }

        private void veículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorVeiculos>());
        }

        private void locacaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorLocacao>());
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            controlador.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }

        private void btnDevolucao_Click_1(object sender, EventArgs e)
        {
            controlador.RegistrarDevolucao();
        }

        private void ConfigurarBotoes(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.Enabled = configuracao.InserirHabilitado;
            btnEditar.Enabled = configuracao.EditarHabilitado;
            btnDevolucao.Enabled = configuracao.ExcluirHabilitado;
            btnDevolucao.Enabled = configuracao.AdicionarItensHabilitado;            
        }

        private void ConfigurarTooltips(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.ToolTipText = configuracao.TooltipInserir;
            btnEditar.ToolTipText = configuracao.TooltipEditar;
            btnDevolucao.ToolTipText = configuracao.TooltipExcluir;
            btnDevolucao.ToolTipText = configuracao.TooltipAdicionarItens;            
        }

        private void ConfigurarTelaPrincipal(ControladorBase controlador)
        {
            this.controlador = controlador;

            ConfigurarToolbox();

            ConfigurarListagem();
        }

        private void ConfigurarToolbox()
        {
            ConfiguracaoToolboxBase configuracao = controlador.ObtemConfiguracaoToolbox();

            if (configuracao != null)
            {
                toolbox.Enabled = true;

                labelTipoCadastro.Text = configuracao.TipoCadastro;

                ConfigurarTooltips(configuracao);

                ConfigurarBotoes(configuracao);
            }
        }

        private void ConfigurarListagem()
        {
            AtualizarRodape("");

            var listagemControl = controlador.ObtemListagem();

            panelRegistros.Controls.Clear();

            listagemControl.Dock = DockStyle.Fill;

            panelRegistros.Controls.Add(listagemControl);
        }

       
    }
}
