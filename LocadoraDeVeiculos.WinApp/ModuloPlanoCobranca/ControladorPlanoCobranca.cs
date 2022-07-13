using LocadoraDeVeiculos.Aplicacao.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloGruposVeiculos;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloPlanoCobranca;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloPlanoCobranca
{
    public class ControladorPlanoCobranca:ControladorBase
    {
                
        private IRepositorioPlanoCobranca repositorioPlanoCobranca;
        private TabelaPlanoCobrancaControl tabelaPlanoCobranca;
        private ServicoPlanoCobranca servicoPlanoCobranca;
        private TabelaPlanoCobrancaControl tabelaPlano;
        private readonly RepositorioGrupoVeiculosEmBancoDados repositorioGrupoVeiculos = new RepositorioGrupoVeiculosEmBancoDados();



        public ControladorPlanoCobranca(IRepositorioPlanoCobranca repositorioPlanoCobranca, ServicoPlanoCobranca servicoPlanoCobranca)
        {
            this.repositorioPlanoCobranca = repositorioPlanoCobranca;
            this.servicoPlanoCobranca = servicoPlanoCobranca;
        }

        public override void Inserir()
        {
            var gruposVeiculos = repositorioGrupoVeiculos.SelecionarTodos();

            TelaCadastroPlanoCobrancaForm tela = new TelaCadastroPlanoCobrancaForm(gruposVeiculos);
            tela.PlanoCobranca = new PlanoCobranca();

            tela.GravarRegistro = servicoPlanoCobranca.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarPlanosCobrancas();

        }
        //editarrrr puxasr infosd
        public override void Editar()
        {
            PlanoCobranca planoCobrancaSelecionado = ObtemPlanoCobrancaSelecionado();

            if (planoCobrancaSelecionado == null)
            {
                MessageBox.Show("Selecione um Plano de Cobrança primeiro",
                "Edição de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var gruposVeiculos = repositorioGrupoVeiculos.SelecionarTodos();
            TelaCadastroPlanoCobrancaForm tela = new TelaCadastroPlanoCobrancaForm(gruposVeiculos);

            
            tela.PlanoCobranca = planoCobrancaSelecionado.Clonar();

            tela.GravarRegistro = servicoPlanoCobranca.Editar;

            DialogResult resultado = tela.ShowDialog();            

            if (resultado == DialogResult.OK)
                CarregarPlanosCobrancas();

        }

        public override void Excluir()
        {
            PlanoCobranca contatoSelecionado = ObtemPlanoCobrancaSelecionado();

            if (contatoSelecionado == null)
            {
                MessageBox.Show("Selecione um Plano de Cobrança primeiro",
                "Exclusão de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o Plano de Cobrança?",
                "Exclusão de Plano de Cobrança", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioPlanoCobranca.Excluir(contatoSelecionado);
                CarregarPlanosCobrancas();
            }
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaPlanoCobranca == null)
                tabelaPlanoCobranca = new TabelaPlanoCobrancaControl();

            CarregarPlanosCobrancas();

            return tabelaPlanoCobranca;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxPlanoCobranca();
        }

        private PlanoCobranca ObtemPlanoCobrancaSelecionado()
        {
            var id = tabelaPlanoCobranca.ObtemNumeroPlanoSelecionado();

           return (PlanoCobranca)repositorioPlanoCobranca.SelecionarPorId(id);
        }

        private void CarregarPlanosCobrancas()
        {
            List<PlanoCobranca> planosCobranca = repositorioPlanoCobranca.SelecionarTodos();

            tabelaPlanoCobranca.AtualizarRegistros(planosCobranca);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {planosCobranca.Count} plano(s) de cobrança");
        }
    }
}
