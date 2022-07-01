using LocadoraDeVeiculos.Aplicacao.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloTaxas
{
    public class ControladorTaxa:ControladorBase
    {
        private TabelaTaxasControl tabelaTaxas;
        private readonly IRepositorioTaxa repositorioTaxa;
        private readonly ServicoTaxa servicoTaxa;

        public ControladorTaxa(IRepositorioTaxa repositorioTaxa, ServicoTaxa servicoTaxa)
        {
            this.repositorioTaxa = repositorioTaxa;
            this.servicoTaxa = servicoTaxa;
        }

        public override void Inserir()
        {
            TelaCadastroTaxaForm tela = new TelaCadastroTaxaForm();
            tela.Taxa = new Taxa();

            tela.GravarRegistro = servicoTaxa.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTaxas();
            }
        }

        public override void Editar()
        {
            Taxa taxaSelecionada = ObtemTaxaSelecionada();

            if (taxaSelecionada == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                "Edição de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroTaxaForm tela = new TelaCadastroTaxaForm();

            tela.Taxa = taxaSelecionada.Clonar();

            tela.GravarRegistro = servicoTaxa.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTaxas();
            }
        }

        public override void Excluir()
        {
            Taxa taxaSelecionada = ObtemTaxaSelecionada();

            if (taxaSelecionada == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                "Exclusão de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a taxa?",
                "Exclusão de Taxas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioTaxa.Excluir(taxaSelecionada);
                CarregarTaxas();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxTaxa();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaTaxas == null)
                tabelaTaxas = new TabelaTaxasControl();

            CarregarTaxas();

            return tabelaTaxas;
        }

        public void CarregarTaxas()
        {
            List<Taxa> taxas = repositorioTaxa.SelecionarTodos();

            tabelaTaxas.AtualizarRegistros(taxas);
            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {taxas.Count} taxa(s)");
        }

        public Taxa ObtemTaxaSelecionada()
        {
            var id = tabelaTaxas.ObtemNumeroTaxaSelecionada();

            return repositorioTaxa.SelecionarPorId(id);
        }

    }
}