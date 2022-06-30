using LocadoraDeVeiculos.Dominio.ModuloPessoaFisica;
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

namespace LocadoraDeVeiculos.WinApp.ModuloPessoaFisica
{
    public partial class TabelaPessoaFisicaControl : UserControl
    {
        public TabelaPessoaFisicaControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Endereco", HeaderText = "Endereco"},

                new DataGridViewTextBoxColumn { DataPropertyName = "CPF", HeaderText = "CPF"},

                new DataGridViewTextBoxColumn { DataPropertyName = "CNH", HeaderText = "CNH"},
            };

            return colunas;
        }

        public int ObtemNumeroPessoaFisicaSelecionada()
        {
            return grid.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<PessoaFisica> pfs)
        {
            grid.Rows.Clear();

            foreach (PessoaFisica pf in pfs)
            {
                grid.Rows.Add(pf.Id, pf.Nome, pf.Email, pf.Telefone, pf.Endereco, pf.CPF, pf.CNH);
            }
        }
    }
}
