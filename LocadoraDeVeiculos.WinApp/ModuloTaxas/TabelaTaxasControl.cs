using LocadoraDeVeiculos.Dominio.ModuloTaxas;
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

namespace LocadoraDeVeiculos.WinApp.ModuloTaxas
{
    public partial class TabelaTaxasControl : UserControl
    {
        public TabelaTaxasControl()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Descrição", HeaderText = "Descrição"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Valor", HeaderText = "Valor"},

                new DataGridViewTextBoxColumn { DataPropertyName = "TipoCalculo", HeaderText = "Tipo de Cálculo"}

            };

            return colunas;
        }

        public int ObtemNumeroTaxaSelecionada()
        {
            return grid.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<Taxa> taxas)
        {
            grid.Rows.Clear();

            foreach (Taxa taxa in taxas)
            {
                grid.Rows.Add(taxa.Id, taxa.Descricao, taxa.Valor, taxa.TipoCalculo);
            }
        }
    }
}
