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
                txtNumero.Text = pessoaFisica.Id.ToString();
                txtNome.Text = pessoaFisica.Nome;
                txtCPF.Text = pessoaFisica.CPF;
                txtEmail.Text = pessoaFisica.Email;
                txtTelefone.Text = pessoaFisica.Telefone;
                txtEndereco.Text = pessoaFisica.Endereco;
                txtCNH.Text = pessoaFisica.CNH;                                
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
            pessoaFisica.Nome = txtNome.Text;
            pessoaFisica.CPF = txtCPF.Text;
            pessoaFisica.Email = txtEmail.Text;
            pessoaFisica.Telefone = txtTelefone.Text;
            pessoaFisica.Endereco = txtEndereco.Text;
            pessoaFisica.CNH = txtCNH.Text;

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