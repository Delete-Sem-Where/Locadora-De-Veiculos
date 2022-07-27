using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
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

namespace LocadoraDeVeiculos.WinApp.ModuloPlanoCobranca
{
    public partial class TabelaPlanoCobrancaControl : UserControl
    {
        public TabelaPlanoCobrancaControl()
        {
            InitializeComponent();
            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
            grid.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número"},

                new DataGridViewTextBoxColumn { DataPropertyName = "GrupoVeiculos", HeaderText = "Grupo de Veículo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "ModalidadePlanoCobranca", HeaderText = "Modalidade"},

                new DataGridViewTextBoxColumn { DataPropertyName = "ValorDiaria", HeaderText = "Diária"},

                new DataGridViewTextBoxColumn { DataPropertyName = "ValorKm", HeaderText = "Preço/KM"},

                new DataGridViewTextBoxColumn { DataPropertyName = "LimiteKm", HeaderText = "Km Limite"},

            };

            return colunas;
        }

        public Guid ObtemNumeroPlanoSelecionado()
        {
            return grid.SelecionarNumero<Guid>();
        }

        internal void AtualizarRegistros(List<PlanoCobranca> planos)
        {
            grid.Rows.Clear();
            foreach (var plano in planos)
            {
                grid.Rows.Add(plano.Id,
                    plano.GrupoVeiculos,
                    plano.ModalidadePlanoCobranca,
                    plano.ValorDiaria,
                    plano.ValorKm,
                    plano.LimiteKm);
            }
        }
    }
}