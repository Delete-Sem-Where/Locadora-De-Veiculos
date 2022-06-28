using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
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
    public partial class TelaCadastroTaxaForm : Form
    {
        private Taxa taxa;

        public TelaCadastroTaxaForm()
        {
            InitializeComponent();

        }

        public Func<Taxa, ValidationResult> GravarRegistro { get; set; }

        public Taxa Taxa
        {
            get
            {
                return taxa;
            }
            set
            {
                taxa = value;
                textBoxNumeroTaxa.Text = taxa.Id.ToString();
                textBoxDescricaoTaxa.Text = taxa.Descricao;
                
                if (taxa.Valor == 0)
                    txtUpDownValor.Value = 1;
                else
                    txtUpDownValor.Value = taxa.Valor;
            }
        }
        

        private void TelaCadastroTaxaForm_Load(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroTaxaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void buttonGravarTaxa_Click(object sender, EventArgs e)
        {
            taxa.Descricao = textBoxDescricaoTaxa.Text;
            taxa.Valor = txtUpDownValor.Value;

            var resultadoValidacao = GravarRegistro(taxa);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;
                TelaPrincipalForm.Instancia.AtualizarRodape(erro);
                DialogResult = DialogResult.None;
            }

        }
    }
}
