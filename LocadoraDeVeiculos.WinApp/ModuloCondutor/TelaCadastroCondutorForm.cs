using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloPessoaFisica;
using LocadoraDeVeiculos.Dominio.ModuloPessoaJuridica;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloPessoaFisica;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloPessoaJuridica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloCondutor
{
    public partial class TelaCadastroCondutorForm : Form
    {
        public TelaCadastroCondutorForm()
        {
            InitializeComponent();

            CarregarClientes();
        }

        private readonly RepositorioPessoaFisicaEmBancoDados repositorioPessoaFisica = new RepositorioPessoaFisicaEmBancoDados();
        private readonly RepositorioPessoaJuridicaEmBancoDados repositorioPessoaJuridica = new RepositorioPessoaJuridicaEmBancoDados();

        private void CarregarClientes()
        {
            cmbClientes.Items.Clear();

            var pessoasFisicas = repositorioPessoaFisica.SelecionarTodos();
            foreach (var item in pessoasFisicas)
            {
                cmbClientes.Items.Add($"{item.Nome} - CPF: {item.CPF}");
            }

            var pessoasJuridicas = repositorioPessoaJuridica.SelecionarTodos();
            foreach (var item in pessoasJuridicas)
            {
                cmbClientes.Items.Add($"{item.Nome} - CNPJ: {item.CNPJ}");
            }
        }

        public Func<Condutor, ValidationResult> GravarRegistro { get; set; }

        private Condutor condutor;

        public Condutor Condutor
        {
            get
            {
                return condutor;
            }
            set
            {
                condutor = value;
                txtNumero.Text = condutor.Id.ToString();
                txtNome.Text = condutor.Nome;
                txtCPF.Text = condutor.CPF;
                txtEmail.Text = condutor.Email;
                txtTelefone.Text = condutor.Telefone;
                txtEndereco.Text = condutor.Endereco;
                txtCNH.Text = condutor.CNH;
                if (condutor.ValidadeCNH == DateTime.MinValue)
                    condutor.ValidadeCNH = DateTime.Now;
                datePickerValidadeCNH.Value = condutor.ValidadeCNH;
            }
        }

        private void buttonGravarPf_Click(object sender, EventArgs e)
        {
            condutor.Nome = txtNome.Text;
            condutor.CPF = txtCPF.Text;
            condutor.Email = txtEmail.Text;
            condutor.Telefone = txtTelefone.Text;
            condutor.Endereco = txtEndereco.Text;
            condutor.CNH = txtCNH.Text;
            condutor.ValidadeCNH = datePickerValidadeCNH.Value;

            var resultadoValidacao = GravarRegistro(condutor);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;
                TelaPrincipalForm.Instancia.AtualizarRodape(erro);
                DialogResult = DialogResult.None;
            }
        }

        private void TelaCadastroCondutorForm_Load(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroCondutorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void cmbClientes_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedItem.ToString().Contains("CNPJ"))
            {
                checkClienteCondutor.Checked = false;
                checkClienteCondutor.Enabled = false;
            }
            else
                checkClienteCondutor.Enabled = true;
        }
    }
}
