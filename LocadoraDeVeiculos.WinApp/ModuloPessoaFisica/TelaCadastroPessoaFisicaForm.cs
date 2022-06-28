using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloPessoaFisica;
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
    public partial class TelaCadastroPessoaFisicaForm : Form
    {
        public TelaCadastroPessoaFisicaForm()
        {
            InitializeComponent();
        }

        public Func<PessoaFisica, ValidationResult> GravarRegistro { get; set; }

        private PessoaFisica pessoaFisica;

        public PessoaFisica PessoaFisica
        {
            get
            {
                return pessoaFisica;
            }
            set
            {
                pessoaFisica = value;
                textBoxNumeroPF.Text = pessoaFisica.Id.ToString();
                textBoxNomePF.Text = pessoaFisica.Nome;
                textBoxCpfPF.Text = pessoaFisica.CPF;
                textBoxEmailPF.Text = pessoaFisica.Email;
                textBoxTelefonePF.Text = pessoaFisica.Telefone;
                textBoxEnderecoPF.Text = pessoaFisica.Endereco;
                textBoxCnhPF.Text = pessoaFisica.CNH;                                
            }
        }

        private void TelaCadastroPessoaFisicaForm_Load(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroPessoaFisicaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void buttonGravarPf_Click(object sender, EventArgs e)
        {
            pessoaFisica.Nome = textBoxNomePF.Text;
            pessoaFisica.CPF = textBoxCpfPF.Text;
            pessoaFisica.Email = textBoxEmailPF.Text;
            pessoaFisica.Telefone = textBoxTelefonePF.Text;
            pessoaFisica.Endereco = textBoxEnderecoPF.Text;
            pessoaFisica.CNH = textBoxCnhPF.Text;

            var resultadoValidacao = GravarRegistro(pessoaFisica);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;
                TelaPrincipalForm.Instancia.AtualizarRodape(erro);
                DialogResult = DialogResult.None;
            }
        }
    }
}