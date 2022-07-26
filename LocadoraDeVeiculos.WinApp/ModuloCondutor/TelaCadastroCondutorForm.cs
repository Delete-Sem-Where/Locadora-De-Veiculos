using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloCliente;

namespace LocadoraDeVeiculos.WinApp.ModuloCondutor
{
    public partial class TelaCadastroCondutorForm : Form
    {
        public TelaCadastroCondutorForm()
        {
            InitializeComponent();

            CarregarClientes();
        }

        private readonly RepositorioClienteEmBancoDados repositorioCliente = new RepositorioClienteEmBancoDados();

        private void CarregarClientes()
        {
            cmbClientes.Items.Clear();

            var clientes = repositorioCliente.SelecionarTodos();
            foreach (var item in clientes)
            {
                cmbClientes.Items.Add(item);
            }
        }

        public Func<Condutor, Result<Condutor>> GravarRegistro { get; set; }

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

                VerificarAtributosDuranteEdicao();

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

            if (cmbClientes.SelectedItem == null)
            {
                string erro = "Não pode inserir um condutor sem selecionar um cliente";
                TelaPrincipalForm.Instancia.AtualizarRodape(erro);
                DialogResult = DialogResult.None;
                return;
            }

            var cliente_selecionado = (Cliente)cmbClientes.SelectedItem;
            condutor.Cliente_Id = cliente_selecionado.Id;

            var resultadoValidacao = GravarRegistro(condutor);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
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

        private void checkClienteCondutor_CheckedChanged(object sender, EventArgs e)
        {
            if (checkClienteCondutor.Checked)
            {
                LimparCampos();
                CompletarCamposCliente();
            }
            else
            {
                LimparCampos();
            }
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimparCampos();
            checkClienteCondutor.Checked = false;

            if (cmbClientes.SelectedItem.ToString().Contains("CNPJ"))
            {
                checkClienteCondutor.Checked = false;
                checkClienteCondutor.Enabled = false;
            }
            else
                checkClienteCondutor.Enabled = true;
        }

        private void LimparCampos()
        {
            txtNome.Text = String.Empty;
            txtCPF.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtTelefone.Text = String.Empty;
            txtEndereco.Text = String.Empty;
            txtCNH.Text = String.Empty;
            datePickerValidadeCNH.Value = DateTime.Now;
        }

        private void CompletarCamposCliente()
        {
            if (cmbClientes.SelectedItem != null && !VerificarSeCamposVazios())
                return;

            var cliente = (Cliente)cmbClientes.SelectedItem;

            txtNome.Text = cliente.Nome;
            txtCPF.Text = cliente.CPF;
            txtEmail.Text = cliente.Email;
            txtTelefone.Text = cliente.Telefone;
            txtEndereco.Text = cliente.Endereco;
        }

        private bool VerificarSeCamposVazios()
        {
            bool nomeVazio = String.IsNullOrEmpty(txtNome.Text);
            bool cpfVazio = String.IsNullOrEmpty(txtNome.Text);
            bool emailVazio = String.IsNullOrEmpty(txtNome.Text);
            bool telefoneVazio = String.IsNullOrEmpty(txtNome.Text);
            bool enderecoVazio = String.IsNullOrEmpty(txtNome.Text);

            if (nomeVazio && cpfVazio && emailVazio && telefoneVazio && enderecoVazio)
                return true;

            return false;
        }

        private void VerificarAtributosDuranteEdicao()
        {
            CarregarItemComboboxSelecionado();

            if (condutor.Cliente_Id != Guid.Empty)
                checkClienteCondutor.Checked = true;
            else
                checkClienteCondutor.Enabled = false;
        }

        private void CarregarItemComboboxSelecionado()
        {
            for (int i = 0; i < cmbClientes.Items.Count; i++)
            {
                var cliente_selecionado = (Cliente)cmbClientes.Items[i];
                if (condutor.Cliente_Id == cliente_selecionado.Id)
                {
                    cmbClientes.SelectedIndex = i;
                    break;
                }
            }
        }
    }
}
