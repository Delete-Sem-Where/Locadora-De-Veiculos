using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.WinApp.Compartilhado;
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
    public partial class TabelaLocacaoControl : UserControl
    {
        public TabelaLocacaoControl()
        {
            InitializeComponent();

            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Condutor", HeaderText = "Condutor"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Veiculo", HeaderText = "Veículo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "PlanoCobranca", HeaderText = "Plano de Cobrança"},

                new DataGridViewTextBoxColumn {DataPropertyName = "DataLocacao", HeaderText = "Data de Locação"},

                new DataGridViewTextBoxColumn {DataPropertyName = "DataDevolucaoPrevista", HeaderText = "Data de Devolução Prevista"}
            };

            return colunas;
        }

        public Guid ObtemNumeroLocacaoSelecionada()
        {
            return grid.SelecionarNumero<Guid>();
        }

        public void AtualizarRegistros(List<Locacao> locacoes)
        {
            grid.Rows.Clear();

            foreach (var locacao in locacoes)
            {
                grid.Rows.Add(
                    locacao.Id,
                    locacao.Condutor.Nome,
                    locacao.Veiculo.Modelo,
                    locacao.PlanoCobranca.ModalidadePlanoCobranca.ToString(),
                    locacao.DataLocacao,
                    locacao.DataDevolucaoPrevista
                    );
            }
        }
    }
}
