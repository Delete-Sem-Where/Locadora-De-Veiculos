using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    public partial class TelaCadastroClientesForm : Form
    {
        public TelaCadastroClientesForm()
        {
            InitializeComponent();
        }

        public Func<Cliente, Result<Cliente>> GravarRegistro { get; set; }

        private Cliente cliente;

        public Cliente Cliente
        {
            get
            {
                return cliente;
            }
            set
            {
                cliente = value;
                if (cliente.Id != Guid.Empty)
                    PreencherDadosNaTela();
                else
                {
                    HabilitarPessoaFisica();
                    radioButtonPessoaFisica.Checked = true;
                    DesabilitarPessoaJuridica();
                }
            }
        }

        private void TelaCadastroClienteForm_Load(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroClienteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void radioButtonPessoaFisica_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarPessoaFisica();
            DesabilitarPessoaJuridica();
        }

        private void radioButtonPessoaJuridica_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarPessoaJuridica();
            DesabilitarPessoaFisica();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            cliente.Nome = txtNome.Text;
            cliente.CPF = txtCPF.Text;
            cliente.CNPJ = txtCNPJ.Text;
            cliente.Email = txtEmail.Text;
            cliente.Telefone = txtTelefone.Text;
            cliente.Endereco = txtEndereco.Text;
            cliente.TipoCliente = ObterTipoCliente();

            if (cliente.TipoCliente == TipoCliente.PessoaFisica)
                cliente.Documento = cliente.CPF;
            else
                cliente.Documento = cliente.CNPJ;

            var resultadoValidacao = GravarRegistro(cliente);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
        }

        private void PreencherDadosNaTela()
        {
            txtNumero.Text = cliente.Id.ToString();
            txtNome.Text = cliente.Nome;
            txtEmail.Text = cliente.Email;
            txtTelefone.Text = cliente.Telefone;
            txtCPF.Text = cliente.CPF;
            txtCNPJ.Text = cliente.CNPJ;
            txtEndereco.Text = cliente.Endereco;
            PreencherTipoCliente();
        }

        private void PreencherTipoCliente()
        {
            if (cliente.TipoCliente == TipoCliente.PessoaFisica)
            {
                radioButtonPessoaFisica.Checked = true;
                DesabilitarPessoaJuridica();
                HabilitarPessoaFisica();
                txtCPF.Text = cliente.CPF;
            }
            else if (cliente.TipoCliente == TipoCliente.PessoaJuridica)
            {
                radioButtonPessoaJuridica.Checked = true;
                DesabilitarPessoaFisica();
                HabilitarPessoaJuridica();
                txtCNPJ.Text = cliente.CNPJ;
            }
        }

        private void HabilitarPessoaFisica()
        {
            txtCPF.Enabled = true;
        }

        private void HabilitarPessoaJuridica()
        {
            txtCNPJ.Enabled = true;
        }

        private void DesabilitarPessoaFisica()
        {
            txtCPF.Clear();
            txtCPF.Enabled = false;
        }

        private void DesabilitarPessoaJuridica()
        {
            txtCNPJ.Clear();
            txtCNPJ.Enabled = false;
        }

        private TipoCliente ObterTipoCliente()
        {
            TipoCliente retorno = TipoCliente.PessoaFisica;

            if (radioButtonPessoaFisica.Checked && string.IsNullOrEmpty(txtCPF.Text) == false)
                retorno = TipoCliente.PessoaFisica;
            else if (radioButtonPessoaJuridica.Checked && string.IsNullOrEmpty(txtCNPJ.Text) == false)
                retorno = TipoCliente.PessoaJuridica;

            return retorno;
        }
    }
}
