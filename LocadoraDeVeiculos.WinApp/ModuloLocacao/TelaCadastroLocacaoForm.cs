using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloLocacao
{
    public partial class TelaCadastroLocacaoForm : Form
    {
        List<Condutor> condutores;
        List<Veiculos> veiculos;
        List<PlanoCobranca> planosCobrancas;

        PlanoCobranca planoCobrancaSelecionado;
        decimal valorTaxasSelecionadas = 0;
        int qtdDiasLocacao = 0;

        public TelaCadastroLocacaoForm(List<Cliente> clientes, List<Condutor> condutores, List<GrupoVeiculos> gruposVeiculos, List<Veiculos> veiculos, List<PlanoCobranca> planosCobrancas, List<Taxa> taxas)
        {
            InitializeComponent();

            this.condutores = condutores;
            this.veiculos = veiculos;
            this.planosCobrancas = planosCobrancas;

            CarregarClientes(clientes);
            CarregarGrupoVeiculos(gruposVeiculos);
            CarregarTaxas(taxas);
        }

        private void CarregarClientes(List<Cliente> clientes)
        {
            cmbClientes.Items.Clear();

            if (clientes.Count > 0)
            {
                foreach (var item in clientes)
                {
                    cmbClientes.Items.Add(item);
                }
            }
        }

        private void CarregarCondutoresDoCliente(List<Condutor> condutores, Cliente clienteSelecionado)
        {
            cmbCondutores.Items.Clear();

            if (condutores.Count > 0)
            {
                foreach (var item in condutores)
                {
                    if(item.Cliente == clienteSelecionado)
                        cmbCondutores.Items.Add(item);
                }
            }
        }

        private void CarregarGrupoVeiculos(List<GrupoVeiculos> gruposVeiculos)
        {
            cmbGrupoVeiculos.Items.Clear();

            if (gruposVeiculos.Count > 0)
            {
                foreach (var item in gruposVeiculos)
                {
                    cmbGrupoVeiculos.Items.Add(item);
                }
            }
        }

        private void CarregarVeiculosDoGrupo(List<Veiculos> veiculos, GrupoVeiculos grupoSelecionado)
        {
            cmbVeiculos.Items.Clear();

            if (veiculos.Count > 0)
            {
                foreach (var item in veiculos)
                {
                    if(item.GrupoVeiculos == grupoSelecionado)
                        cmbVeiculos.Items.Add(item);
                }
            }
        }

        private void CarregarPlanoCobrancaDoGrupo(List<PlanoCobranca> planosCobrancas, GrupoVeiculos grupoSelecionado)
        {
            cmbPlanoCobranca.Items.Clear();

            if (planosCobrancas.Count > 0)
            {
                foreach (var item in planosCobrancas)
                {
                    if(item.GrupoVeiculos == grupoSelecionado)
                        cmbPlanoCobranca.Items.Add(item);
                }
            }
        }

        private void CarregarTaxas(List<Taxa> taxas)
        {
            listTaxas.Items.Clear();

            foreach (var item in taxas)
            {
                listTaxas.Items.Add(item);
            }
        }

        public Func<Locacao, Result<Locacao>> GravarRegistro { get; set; }

        private Locacao locacao;

        public Locacao Locacao
        {
            get
            {
                return locacao;
            }
            set
            {
                locacao = value;

                if (locacao.Id != Guid.Empty)
                    PreencherDadosNaTela();
            }
        }

        private void PreencherDadosNaTela()
        {
            txtNumero.Text = locacao.Id.ToString();
        }

        private void cmbVeiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbVeiculos.SelectedItem != null)
            {
                var veiculoSelecionado = (Veiculos)cmbVeiculos.SelectedItem;
                txtKmRodado.Text = veiculoSelecionado.QuilometroPercorrido;
            }
            else
            {
                txtKmRodado.Text = string.Empty;
            }
        }

        private void buttonGravarPf_Click(object sender, EventArgs e)
        {
            locacao.Cliente = (Cliente)cmbClientes.SelectedItem;
            locacao.Condutor = (Condutor)cmbCondutores.SelectedItem;
            locacao.GrupoVeiculos = (GrupoVeiculos)cmbGrupoVeiculos.SelectedItem;
            locacao.Veiculo = (Veiculos)cmbVeiculos.SelectedItem;
            locacao.PlanoCobranca = (PlanoCobranca)cmbPlanoCobranca.SelectedItem;
            locacao.DataLocacao = datePickerDataLocacao.Value;
            locacao.DataDevolucaoPrevista = dateTimeDataDevolucao.Value;

            txtValorTotalPrevisto.Text = txtValorTotalPrevisto.Text.Remove(0,2);
            locacao.ValorTotalPrevisto = Convert.ToDouble(txtValorTotalPrevisto.Text);

            var resultadoValidacao = GravarRegistro(locacao);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção de Locação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var clienteSelecionado = (Cliente)cmbClientes.SelectedItem;
            CarregarCondutoresDoCliente(condutores, clienteSelecionado);
        }

        private void cmbGrupoVeiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            planoCobrancaSelecionado = null;
            txtKmRodado.Text = string.Empty;
            var grupoSelecionado = (GrupoVeiculos)cmbGrupoVeiculos.SelectedItem;
            CarregarVeiculosDoGrupo(veiculos, grupoSelecionado);
            CarregarPlanoCobrancaDoGrupo(planosCobrancas, grupoSelecionado);
            CalcularValorTotalPrevisto();
        }

        private void cmbPlanoCobranca_SelectedIndexChanged(object sender, EventArgs e)
        {
            planoCobrancaSelecionado = (PlanoCobranca)cmbPlanoCobranca.SelectedItem;
            CalcularValorTotalPrevisto();
        }

        private void CalcularValorTotalPrevisto()
        {
            decimal valorTotalPrevisto = 0;

            if(planoCobrancaSelecionado != null)
            {
                if (planoCobrancaSelecionado.ModalidadePlanoCobranca == ModalidadePlanoCobranca.Livre)
                {
                    valorTotalPrevisto = qtdDiasLocacao * planoCobrancaSelecionado.ValorDiaria + valorTaxasSelecionadas;
                    AlterarMensagemInformacaoPlanoCobranca(planoCobrancaSelecionado.ModalidadePlanoCobranca);
                }
                else if (planoCobrancaSelecionado.ModalidadePlanoCobranca == ModalidadePlanoCobranca.Diario)
                {
                    valorTotalPrevisto = qtdDiasLocacao * planoCobrancaSelecionado.ValorDiaria + valorTaxasSelecionadas;
                    AlterarMensagemInformacaoPlanoCobranca(planoCobrancaSelecionado.ModalidadePlanoCobranca);
                }
                else if (planoCobrancaSelecionado.ModalidadePlanoCobranca == ModalidadePlanoCobranca.Controle)
                {
                    valorTotalPrevisto = qtdDiasLocacao * planoCobrancaSelecionado.ValorDiaria + valorTaxasSelecionadas;
                    AlterarMensagemInformacaoPlanoCobranca(planoCobrancaSelecionado.ModalidadePlanoCobranca);
                }
            }
            else
            {
                valorTotalPrevisto = valorTaxasSelecionadas;
            }

            txtValorTotalPrevisto.Text = "R$" + valorTotalPrevisto.ToString();
        }

        private void AlterarMensagemInformacaoPlanoCobranca(ModalidadePlanoCobranca modalidadePlanoCobranca)
        {
            if(modalidadePlanoCobranca == ModalidadePlanoCobranca.Diario)
                lblInformacaoPlanoCobranca.Text = "Valor por KM calculado somente na devolução";
            else if(modalidadePlanoCobranca == ModalidadePlanoCobranca.Controle)
                lblInformacaoPlanoCobranca.Text = "Multa para limite de KM excedido";
            else if(modalidadePlanoCobranca == ModalidadePlanoCobranca.Livre)
                lblInformacaoPlanoCobranca.Text = string.Empty;
        }

        private void CalcularDiasLocacao()
        {
            qtdDiasLocacao = (int)(dateTimeDataDevolucao.Value - datePickerDataLocacao.Value).TotalDays;
            CalcularValorTotalPrevisto();
        }

        private void datePickerDataLocacao_ValueChanged(object sender, EventArgs e)
        {
            CalcularDiasLocacao();
        }

        private void dateTimeDataDevolucao_ValueChanged(object sender, EventArgs e)
        {
            CalcularDiasLocacao();
        }

        private void listTaxas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            Taxa taxaSelecionada = (Taxa)listTaxas.SelectedItem;
            if (listTaxas.CheckedItems.Contains(taxaSelecionada))
                valorTaxasSelecionadas -= taxaSelecionada.Valor;
            else
                valorTaxasSelecionadas += taxaSelecionada.Valor;

            CalcularValorTotalPrevisto();
        }
    }
}
