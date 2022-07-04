using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
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

namespace LocadoraDeVeiculos.WinApp.ModuloVeiculos
{
    public partial class TabelaVeiculosControl : UserControl
    {
        public TabelaVeiculosControl()
        {
            InitializeComponent();
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Modelo", HeaderText = "Modelo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Marca", HeaderText = "Marca"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Ano", HeaderText = "Ano"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Cor", HeaderText = "Cor"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Placa", HeaderText = "Placa"},

                new DataGridViewTextBoxColumn { DataPropertyName = "TipoCombustivel", HeaderText = "Tipo de Combustível"},

                new DataGridViewTextBoxColumn { DataPropertyName = "KmPercorridos", HeaderText = "Quilometros Percorrido"},

                new DataGridViewTextBoxColumn { DataPropertyName = "CapacidadeTanque", HeaderText = "Capacidade do Tanque"},

             //TODO   new DataGridViewTextBoxColumn { DataPropertyName = "GrupoVeiculos_Id", HeaderText = "Grupo de Veiculos"}
            };

            return colunas;
        }

        public int ObtemNumeroVeiculoSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<Veiculos> veiculos)
        {
            grid.Rows.Clear();

            foreach (Veiculos v in veiculos)
            {
                grid.Rows.Add(v.Id, v.Modelo, v.Marca, v.Ano, v.Cor, v.Placa,
                               v.TipoCombustivel, v.QuilometroPercorrido + " Km",
                               v.CapacidadeTanque + " Litros");
            }
        }
    }
}
