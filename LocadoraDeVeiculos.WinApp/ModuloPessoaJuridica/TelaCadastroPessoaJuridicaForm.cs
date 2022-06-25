using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloPessoaJuridica;
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
    public partial class TelaCadastroPessoaJuridicaForm : Form
    {
        public TelaCadastroPessoaJuridicaForm()
        {
            InitializeComponent();
        }

        private PessoaJuridica pessoaJuridica;

        public Func<PessoaJuridica, ValidationResult> GravarRegistro { get; set; }

        public PessoaJuridica PessoaJuridica
        {
            get { return pessoaJuridica; }
            set
            {
                pessoaJuridica = value;

                txtNumero.Text = pessoaJuridica.Id.ToString();
                txtNome.Text = pessoaJuridica.Nome;
                txtEmail.Text = pessoaJuridica.Email;
                txtTelefone.Text = pessoaJuridica.Telefone;
                txtEndereco.Text = pessoaJuridica.Endereco;
                txtCNPJ.Text = pessoaJuridica.CNPJ;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            pessoaJuridica.Id = Convert.ToInt32(txtNumero.Text);
            pessoaJuridica.Nome = txtNome.Text;
            pessoaJuridica.Email = txtEmail.Text;
            pessoaJuridica.Telefone = txtTelefone.Text;
            pessoaJuridica.Endereco = txtEndereco.Text;
            pessoaJuridica.CNPJ = txtCNPJ.Text;

            var resultadoValidacao = GravarRegistro(pessoaJuridica);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void TelaCadastroPessoaJuridicaForm_Load(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroPessoaJuridicaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }
    }
}
