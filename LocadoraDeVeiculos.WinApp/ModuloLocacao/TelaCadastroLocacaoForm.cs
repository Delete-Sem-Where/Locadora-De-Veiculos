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
        public TelaCadastroLocacaoForm(List<Cliente> clientes, List<Condutor> condutores, List<GrupoVeiculos> gruposVeiculos, List<Veiculos> veiculos, List<PlanoCobranca> planosCobrancas, List<Taxa> taxas)
        {
            InitializeComponent();

            CarregarClientes(clientes);
            CarregarCondutores(condutores);
            CarregarGrupoVeiculos(gruposVeiculos);
            CarregarVeiculos(veiculos);
            CarregarPlanoCobranca(planosCobrancas);
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

        private void CarregarCondutores(List<Condutor> condutores)
        {
            cmbCondutores.Items.Clear();

            if (condutores.Count > 0)
            {
                foreach (var item in condutores)
                {
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

        private void CarregarVeiculos(List<Veiculos> veiculos)
        {
            cmbVeiculos.Items.Clear();

            if (veiculos.Count > 0)
            {
                foreach (var item in veiculos)
                {
                    cmbVeiculos.Items.Add(item);
                }
            }
        }

        private void CarregarPlanoCobranca(List<PlanoCobranca> planosCobrancas)
        {
            cmbPlanoCobranca.Items.Clear();

            if (planosCobrancas.Count > 0)
            {
                foreach (var item in planosCobrancas)
                {
                    cmbPlanoCobranca.Items.Add(item);
                }
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
            locacao.ValorTotalPrevisto = 1400;

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
    }
}
