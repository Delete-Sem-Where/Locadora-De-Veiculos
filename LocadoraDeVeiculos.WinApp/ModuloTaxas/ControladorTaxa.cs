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
    public class ControladorTaxa : ControladorBase
    {
        private TabelaTaxasControl tabelaTaxas;
        private readonly ServicoTaxa servicoTaxa;

        public ControladorTaxa(ServicoTaxa servicoTaxa)
        {
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
            var id = tabelaTaxas.ObtemNumeroTaxaSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                "Edição de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoTaxa.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message, "Edição de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var taxaSelecionada = resultado.Value;

            TelaCadastroTaxaForm tela = new TelaCadastroTaxaForm();

            tela.Taxa = taxaSelecionada;

            tela.GravarRegistro = servicoTaxa.Editar;

            DialogResult resultadoTela = tela.ShowDialog();

            if (resultadoTela == DialogResult.OK)
            {
                CarregarTaxas();
            }
        }

        public override void Excluir()
        {
            var id = tabelaTaxas.ObtemNumeroTaxaSelecionada();
            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                    "Exclusão de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoTaxa.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var taxaSelecionada = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir a taxa?", "Exclusão de Taxa",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoTaxa.Excluir(taxaSelecionada);

                if (resultadoExclusao.IsSuccess)
                    CarregarTaxas();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            var resultado = servicoTaxa.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Taxa> taxas = resultado.Value;

                tabelaTaxas.AtualizarRegistros(taxas);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {taxas.Count} taxa(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Listagem de Taxa",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}