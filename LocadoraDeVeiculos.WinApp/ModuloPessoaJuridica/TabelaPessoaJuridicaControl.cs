using LocadoraDeVeiculos.Dominio.ModuloPessoaJuridica;
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

namespace LocadoraDeVeiculos.WinApp.ModuloPessoaJuridica
{
    public partial class TabelaPessoaJuridicaControl : UserControl
    {
        public TabelaPessoaJuridicaControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone"},

                new DataGridViewTextBoxColumn {DataPropertyName = "CNPJ", HeaderText = "CNPJ"}
            };

            return colunas;
        }

        public Guid ObtemNumeroPessoaJuridicaSelecionado()
        {
            return grid.SelecionarNumero<Guid>();
        }

        public void AtualizarRegistros(List<PessoaJuridica> pessoasJuridicas)
        {
            grid.Rows.Clear();

            foreach (var pessoaJuridica in pessoasJuridicas)
            {
                grid.Rows.Add(
                    pessoaJuridica.Id,
                    pessoaJuridica.Nome,
                    pessoaJuridica.Email,
                    pessoaJuridica.Telefone,
                    pessoaJuridica.CNPJ
                );
            }
        }
    }
}
