using LocadoraDeVeiculos.Infra.BancoDados.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloPessoaJuridica;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloPessoaFisica;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloTaxa;
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

namespace LocadoraDeVeiculos.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        private ControladorBase controlador;
        private Dictionary<string, ControladorBase> controladores;

        public TelaPrincipalForm()
        {
            InitializeComponent();

            Instancia = this;

            labelRodape.Text = string.Empty;
            labelTipoCadastro.Text = string.Empty;

            InicializarControladores();
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
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void pessoaJurídicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void pessoasFísicasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void taxasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void grupoVeículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
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

        private void ConfigurarBotoes(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.Enabled = configuracao.InserirHabilitado;
            btnEditar.Enabled = configuracao.EditarHabilitado;
            btnExcluir.Enabled = configuracao.ExcluirHabilitado;
            btnAdicionarItens.Enabled = configuracao.AdicionarItensHabilitado;
            btnAtualizarItens.Enabled = configuracao.AtualizarItensHabilitado;
            btnFiltrar.Enabled = configuracao.FiltrarHabilitado;
            btnAgrupar.Enabled = configuracao.AgruparHabilitado;
            btnVisualizar.Enabled = configuracao.VisualizarHabilitado;
        }

        private void ConfigurarTooltips(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.ToolTipText = configuracao.TooltipInserir;
            btnEditar.ToolTipText = configuracao.TooltipEditar;
            btnExcluir.ToolTipText = configuracao.TooltipExcluir;
            btnAdicionarItens.ToolTipText = configuracao.TooltipAdicionarItens;
            btnAtualizarItens.ToolTipText = configuracao.TooltipAtualizarItens;
            btnFiltrar.ToolTipText = configuracao.TooltipFiltrar;
            btnAgrupar.ToolTipText = configuracao.TooltipAgrupar;
            btnVisualizar.ToolTipText = configuracao.TooltipVisualizar;
        }

        private void ConfigurarTelaPrincipal(ToolStripMenuItem opcaoSelecionada)
        {
            var tipo = opcaoSelecionada.Text;

            controlador = controladores[tipo];

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

        private void InicializarControladores()
        {
            var repositorioFuncionario = new RepositorioFuncionarioEmBancoDados();
            var repositorioPessoaJuridica = new RepositorioPessoaJuridicaEmBancoDados();
            var repositorioPessoaFisica = new RepositorioPessoaFisicaEmBancoDados();
            var repositorioTaxa = new RepositorioTaxaEmBancoDados();
            var repositorioGrupoVeiculos = new RepositorioGrupoVeiculosEmBancoDados();
            var repositorioCliente = new RepositorioClienteEmBancoDados();

            var servicoFuncionario = new ServicoFuncionario(repositorioFuncionario);
            var servicoPessoaJuridica = new ServicoPessoaJuridica(repositorioPessoaJuridica);
            var servicoGrupoVeiculos = new ServicoGrupoVeiculos(repositorioGrupoVeiculos);
            var servicoPessoaFisica = new ServicoPessoaFisica(repositorioPessoaFisica);
            var servicoTaxa = new ServicoTaxa(repositorioTaxa);
            var servicoCliente = new ServicoCliente(repositorioCliente);

            controladores = new Dictionary<string, ControladorBase>();

            controladores.Add("Funcionário", new ControladorFuncionario(repositorioFuncionario, servicoFuncionario));
            controladores.Add("Pessoa Jurídica", new ControladorPessoaJuridica(repositorioPessoaJuridica, servicoPessoaJuridica));
            controladores.Add("Pessoa Física", new ControladorPessoaFisica(repositorioPessoaFisica, servicoPessoaFisica));
            controladores.Add("Taxas", new ControladorTaxa(repositorioTaxa, servicoTaxa));
            controladores.Add("Grupo Veículos", new ControladorGrupoVeiculos(repositorioGrupoVeiculos, servicoGrupoVeiculos));
            controladores.Add("Cliente", new ControladorCliente(repositorioCliente, servicoCliente));
        }
    }
}
