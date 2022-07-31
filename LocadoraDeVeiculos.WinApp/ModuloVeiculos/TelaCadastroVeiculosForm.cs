using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloGruposVeiculos;
using FluentResults;

namespace LocadoraDeVeiculos.WinApp.ModuloVeiculos
{
    public partial class TelaCadastroVeiculosForm : Form
    {
        private string caminhoImagem = "";

        public TelaCadastroVeiculosForm(List<GrupoVeiculos> grupos)
        {
            InitializeComponent();

            CarregarGrupoVeiculos(grupos);
        }

        private void CarregarGrupoVeiculos(List<GrupoVeiculos> grupos)
        {
            cmbGrupoVeiculos.Items.Clear();

            foreach (var item in grupos)
                cmbGrupoVeiculos.Items.Add(item);
        }

        public Func<Veiculos, Result<Veiculos>> GravarRegistro { get; set; }

        private Veiculos veiculos;

        public Veiculos Veiculos
        {
            get
            {
                return veiculos;
            }
            set
            {
                veiculos = value;

                txtNumero.Text = veiculos.Id.ToString();
                txtModelo.Text = veiculos.Modelo;
                txtPlaca.Text = veiculos.Placa;
                txtMarca.Text = veiculos.Marca;
                txtCor.Text = veiculos.Cor;
                txtKmPercorrido.Text = veiculos.QuilometroPercorrido;
                txtAno.Text = veiculos.Ano;
                txtCapacidadeTanque.Text = veiculos.CapacidadeTanque;
                txtTipoCombustivel.Text = veiculos.TipoCombustivel;

                if(veiculos.Imagem != null)
                {
                    using (var imagem = new MemoryStream(veiculos.Imagem))
                    {
                        picBoxImagem.Image = Image.FromStream(imagem);
                    }
                }

                if(veiculos.GrupoVeiculos != null)
                {
                    for (int i = 0; i < cmbGrupoVeiculos.Items.Count; i++)
                    {
                        if (veiculos.GrupoVeiculos == (GrupoVeiculos)cmbGrupoVeiculos.Items[i])
                        {
                            cmbGrupoVeiculos.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
        }

        private void TelaCadastroVeiculosForm_Load(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroCondutorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void btnGravar_Click_1(object sender, EventArgs e)
        {
            veiculos.Modelo = txtModelo.Text;
            veiculos.Placa = txtPlaca.Text;
            veiculos.Marca = txtMarca.Text;
            veiculos.Cor = txtCor.Text;
            veiculos.QuilometroPercorrido = txtKmPercorrido.Text;
            veiculos.Ano = txtAno.Text;
            veiculos.CapacidadeTanque = txtCapacidadeTanque.Text;
            veiculos.TipoCombustivel = txtTipoCombustivel.Text;

            if (cmbGrupoVeiculos.SelectedItem == null)
            {
                string erro = "Não pode inserir um veículo sem selecionar seu grupo de veículos";
                TelaPrincipalForm.Instancia.AtualizarRodape(erro);
                DialogResult = DialogResult.None;
                return;
            }

            if (caminhoImagem != string.Empty)
                veiculos.Imagem = ReceberFoto(caminhoImagem);

            var grupoVeiculos_Selecionado = (GrupoVeiculos)cmbGrupoVeiculos.SelectedItem;
            veiculos.GrupoVeiculos = grupoVeiculos_Selecionado;

            var resultadoValidacao = GravarRegistro(veiculos);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
        }

        private void btnSelecionarFoto_Click(object sender, EventArgs e)
        {
            var abrirArquivo = new OpenFileDialog();
            abrirArquivo.Filter = "|*.jpg; *.jpeg; *.png;";
            abrirArquivo.Multiselect = false;

            if (abrirArquivo.ShowDialog() == DialogResult.OK)
            {
                caminhoImagem = abrirArquivo.FileName;
            }

            if (caminhoImagem != "")
            {
                picBoxImagem.Load(caminhoImagem);
            }
        }

        private byte[] ReceberFoto(string caminhoImagem)
        {
            byte[] imagem;
            using (var fileStream = new FileStream(caminhoImagem, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(fileStream))
                {
                    imagem = reader.ReadBytes((int)fileStream.Length);
                }
            }

            return imagem;
        }
    }
}
        