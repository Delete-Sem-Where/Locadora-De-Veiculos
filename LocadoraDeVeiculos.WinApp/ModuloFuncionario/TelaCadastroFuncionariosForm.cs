using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    public partial class TelaCadastroFuncionariosForm : Form
    {
        public TelaCadastroFuncionariosForm()
        {
            InitializeComponent();

            // desativa as setas do numericupdown
            txtSalario.Controls[0].Enabled = false;
        }

        private Funcionario funcionario;

        public Func<Funcionario, ValidationResult> GravarRegistro { get; set; }

        public Funcionario Funcionario
        {
            get { return funcionario; }
            set { 
                funcionario = value;

                txtNumero.Text = funcionario.Id.ToString();
                txtNome.Text = funcionario.Nome;
                txtEmail.Text = funcionario.Email;
                txtTelefone.Text = funcionario.Telefone;
                txtEndereco.Text = funcionario.Endereco;
                txtLogin.Text = funcionario.Login;
                txtSenha.Text = funcionario.Senha;
                txtSalario.Text = funcionario.Salario.ToString();
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            funcionario.Id = Convert.ToInt32(txtNumero.Text);
            funcionario.Nome = txtNome.Text;
            funcionario.Email = txtEmail.Text;
            funcionario.Telefone = txtTelefone.Text;
            funcionario.Endereco = txtEndereco.Text;
            funcionario.Login = txtLogin.Text;
            funcionario.Senha = txtSenha.Text;
            funcionario.Salario = Convert.ToDouble(txtSalario.Text);

            var resultadoValidacao = GravarRegistro(funcionario);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void TelaCadastroFuncionariosForm_Load(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroFuncionariosForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void btnVisualizarSenha_Click(object sender, EventArgs e)
        {
            if (txtSenha.UseSystemPasswordChar)
            {
                txtSenha.UseSystemPasswordChar = false;
                btnVisualizarSenha.Image = Properties.Resources.visibility_FILL0_wght400_GRAD0_opsz24;
            }
            else
            {
                txtSenha.UseSystemPasswordChar = true;
                btnVisualizarSenha.Image = Properties.Resources.visibility_off_FILL0_wght400_GRAD0_opsz24;
            }
        }
    }
}
