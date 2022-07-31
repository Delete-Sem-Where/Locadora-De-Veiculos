using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;


namespace LocadoraDeVeiculos.WinApp.ModuloLocacao
{
    public partial class TelaCadastroLocacaoForm : Form
    {
        List<Condutor> condutores;
        List<Veiculos> veiculos;
        List<PlanoCobranca> planosCobrancas;

        PlanoCobranca planoCobrancaSelecionado;
        decimal valorTaxasSelecionadas = 0;
        int qtdDiasLocacao = 0;

        public TelaCadastroLocacaoForm(List<Cliente> clientes, List<Condutor> condutores, List<GrupoVeiculos> gruposVeiculos, List<Veiculos> veiculos, List<PlanoCobranca> planosCobrancas, List<Taxa> taxas)
        {
            InitializeComponent();

            this.condutores = condutores;
            this.veiculos = veiculos;
            this.planosCobrancas = planosCobrancas;

            CarregarClientes(clientes);
            CarregarGrupoVeiculos(gruposVeiculos);
            CarregarTaxas(taxas);
        }

        private void CarregarClientes(List<Cliente> clientes)
        {
            cmbClientes.Items.Clear();

            if (clientes.Count > 0)
            {
                foreach (var item in clientes)
                {
                    cmbClientes.Items.Add(item);
                }
            }
        }

        private void CarregarCondutoresDoCliente(List<Condutor> condutores, Cliente clienteSelecionado)
        {
            cmbCondutores.Items.Clear();

            if (condutores.Count > 0)
            {
                foreach (var item in condutores)
                {
                    if(item.Cliente == clienteSelecionado)
                        cmbCondutores.Items.Add(item);
                }
            }
        }

        private void CarregarGrupoVeiculos(List<GrupoVeiculos> gruposVeiculos)
        {
            cmbGrupoVeiculos.Items.Clear();

            if (gruposVeiculos.Count > 0)
            {
                foreach (var item in gruposVeiculos)
                {
                    cmbGrupoVeiculos.Items.Add(item);
                }
            }
        }

        private void CarregarVeiculosDoGrupo(List<Veiculos> veiculos, GrupoVeiculos grupoSelecionado)
        {
            cmbVeiculos.Items.Clear();

            if (veiculos.Count > 0)
            {
                foreach (var item in veiculos)
                {
                    if(item.GrupoVeiculos == grupoSelecionado)
                        cmbVeiculos.Items.Add(item);
                }
            }
        }

        private void CarregarPlanoCobrancaDoGrupo(List<PlanoCobranca> planosCobrancas, GrupoVeiculos grupoSelecionado)
        {
            cmbPlanoCobranca.Items.Clear();

            if (planosCobrancas.Count > 0)
            {
                foreach (var item in planosCobrancas)
                {
                    if(item.GrupoVeiculos == grupoSelecionado)
                        cmbPlanoCobranca.Items.Add(item);
                }
            }
        }

        private void CarregarTaxas(List<Taxa> taxas)
        {
            listTaxas.Items.Clear();

            foreach (var item in taxas)
            {
                listTaxas.Items.Add(item);
            }
        }

        public Func<Locacao, Result<Locacao>> GravarRegistro { get; set; }

        private Locacao locacao;

        public Locacao Locacao
        {
            get
            {
                return locacao;
            }
            set
            {
                locacao = value;
                locacao.TaxasSelecionadas = new List<Taxa>();
                PreencherDadosNaTela();
            }
        }

        private void PreencherDadosNaTela()
        {
            txtNumero.Text = locacao.Id.ToString();
            LimitarCalendarios();

            if (locacao.Cliente != null)
                CarregarAtributosSelecionados();
        }

        private void CarregarAtributosSelecionados()
        {
            LocalizarDatas();
            LocalizarClienteComboBox();
            LocalizarCondutorComboBox();
            LocalizarGrupoVeiculosComboBox();
            LocalizarVeiculosComboBox();
            LocalizarPlanoCobrancaComboBox();
            LocalizarTaxasSelecionadas();
        }

        private void LocalizarDatas()
        {
            datePickerDataLocacao.Value = locacao.DataLocacao;
            datePickerDataDevolucao.Value = locacao.DataDevolucaoPrevista;
        }

        private void LocalizarClienteComboBox()
        {
            for (int i = 0; i < cmbClientes.Items.Count; i++)
            {
                if (locacao.Cliente == (Cliente)cmbClientes.Items[i])
                {
                    cmbClientes.SelectedIndex = i;
                    break;
                }
            }
        }

        private void LocalizarCondutorComboBox()
        {
            for (int i = 0; i < cmbCondutores.Items.Count; i++)
            {
                if (locacao.Condutor == (Condutor)cmbCondutores.Items[i])
                {
                    cmbCondutores.SelectedIndex = i;
                    break;
                }
            }
        }

        private void LocalizarGrupoVeiculosComboBox()
        {
            for (int i = 0; i < cmbGrupoVeiculos.Items.Count; i++)
            {
                if (locacao.GrupoVeiculos == (GrupoVeiculos)cmbGrupoVeiculos.Items[i])
                {
                    cmbGrupoVeiculos.SelectedIndex = i;
                    break;
                }
            }
        }

        private void LocalizarVeiculosComboBox()
        {
            for (int i = 0; i < cmbVeiculos.Items.Count; i++)
            {
                if (locacao.Veiculo == (Veiculos)cmbVeiculos.Items[i])
                {
                    cmbVeiculos.SelectedIndex = i;
                    break;
                }
            }
        }

        private void LocalizarPlanoCobrancaComboBox()
        {
            for (int i = 0; i < cmbPlanoCobranca.Items.Count; i++)
            {
                if (locacao.PlanoCobranca == (PlanoCobranca)cmbPlanoCobranca.Items[i])
                {
                    cmbPlanoCobranca.SelectedIndex = i;
                    break;
                }
            }
        }

        private void LocalizarTaxasSelecionadas()
        {
            for (int i = 0; i < listTaxas.Items.Count; i++)
            {
                if (locacao.TaxasSelecionadas.Contains(listTaxas.Items[i]))
                {
                    listTaxas.SelectedItem = listTaxas.Items[i];
                    listTaxas.SetItemChecked(i, true);
                }
            }
        }

        private void cmbVeiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbVeiculos.SelectedItem != null)
            {
                var veiculoSelecionado = (Veiculos)cmbVeiculos.SelectedItem;
                txtKmRodado.Text = veiculoSelecionado.QuilometroPercorrido;
            }
            else
            {
                txtKmRodado.Text = string.Empty;
            }
        }

        private void buttonGravarPf_Click(object sender, EventArgs e)
        {
            var resultadoValidacaoSelecoes = ValidarCamposSelecionados();

            if (resultadoValidacaoSelecoes.IsSuccess)
            {
                locacao.Cliente = (Cliente)cmbClientes.SelectedItem;
                locacao.Condutor = (Condutor)cmbCondutores.SelectedItem;
                locacao.GrupoVeiculos = (GrupoVeiculos)cmbGrupoVeiculos.SelectedItem;
                locacao.Veiculo = (Veiculos)cmbVeiculos.SelectedItem;
                locacao.PlanoCobranca = (PlanoCobranca)cmbPlanoCobranca.SelectedItem;
                locacao.DataLocacao = datePickerDataLocacao.Value;
                locacao.DataDevolucaoPrevista = datePickerDataDevolucao.Value;
                locacao.TaxasSelecionadas = SalvarTaxasSelecionadas();

                txtValorTotalPrevisto.Text = txtValorTotalPrevisto.Text.Remove(0,2);
                locacao.ValorTotalPrevisto = Convert.ToDouble(txtValorTotalPrevisto.Text);

                locacao.EstaAlugado = true;
            }
            else
            {
                string erro = $"Não pode inserir uma locação sem selecionar um {resultadoValidacaoSelecoes.Errors[0].Message}";
                TelaPrincipalForm.Instancia.AtualizarRodape(erro);
                DialogResult = DialogResult.None;
                return;
            }

            var resultadoValidacao = GravarRegistro(locacao);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção de Locação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
        }

        private Result ValidarCamposSelecionados()
        {
            if (cmbClientes.SelectedItem == null)
            {
                return Result.Fail(new Error("cliente"));
            }
            else if (cmbCondutores.SelectedItem == null)
            {
                return Result.Fail(new Error("condutor"));
            }
            else if (cmbGrupoVeiculos.SelectedItem == null)
            {
                return Result.Fail(new Error("grupo de veículos"));
            }
            else if (cmbVeiculos.SelectedItem == null)
            {
                return Result.Fail(new Error("veículo"));
            }
            else if (cmbPlanoCobranca.SelectedItem == null)
            {
                return Result.Fail(new Error("plano de cobrança"));
            }
            else
            {
                return Result.Ok();
            }
        }

        private List<Taxa> SalvarTaxasSelecionadas()
        {
            List<Taxa> taxasSelecionadas = new List<Taxa>();

            foreach (Taxa item in listTaxas.CheckedItems)
            {
                taxasSelecionadas.Add(item);
            }

            return taxasSelecionadas;
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var clienteSelecionado = (Cliente)cmbClientes.SelectedItem;
            CarregarCondutoresDoCliente(condutores, clienteSelecionado);
        }

        private void cmbGrupoVeiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            planoCobrancaSelecionado = null;
            txtKmRodado.Text = string.Empty;
            var grupoSelecionado = (GrupoVeiculos)cmbGrupoVeiculos.SelectedItem;
            CarregarVeiculosDoGrupo(veiculos, grupoSelecionado);
            CarregarPlanoCobrancaDoGrupo(planosCobrancas, grupoSelecionado);
            CalcularValorTotalPrevisto();
        }

        private void cmbPlanoCobranca_SelectedIndexChanged(object sender, EventArgs e)
        {
            planoCobrancaSelecionado = (PlanoCobranca)cmbPlanoCobranca.SelectedItem;
            CalcularValorTotalPrevisto();
        }

        private void CalcularValorTotalPrevisto()
        {
            decimal valorTotalPrevisto = 0;

            if(planoCobrancaSelecionado != null)
            {
                if (planoCobrancaSelecionado.ModalidadePlanoCobranca == ModalidadePlanoCobranca.Livre)
                {
                    valorTotalPrevisto = qtdDiasLocacao * planoCobrancaSelecionado.ValorDiaria + valorTaxasSelecionadas;
                    AlterarMensagemInformacaoPlanoCobranca(planoCobrancaSelecionado.ModalidadePlanoCobranca);
                }
                else if (planoCobrancaSelecionado.ModalidadePlanoCobranca == ModalidadePlanoCobranca.Diario)
                {
                    valorTotalPrevisto = qtdDiasLocacao * planoCobrancaSelecionado.ValorDiaria + valorTaxasSelecionadas;
                    AlterarMensagemInformacaoPlanoCobranca(planoCobrancaSelecionado.ModalidadePlanoCobranca);
                }
                else if (planoCobrancaSelecionado.ModalidadePlanoCobranca == ModalidadePlanoCobranca.Controle)
                {
                    valorTotalPrevisto = qtdDiasLocacao * planoCobrancaSelecionado.ValorDiaria + valorTaxasSelecionadas;
                    AlterarMensagemInformacaoPlanoCobranca(planoCobrancaSelecionado.ModalidadePlanoCobranca);
                }
            }
            else
            {
                valorTotalPrevisto = valorTaxasSelecionadas;
            }

            txtValorTotalPrevisto.Text = "R$" + valorTotalPrevisto.ToString();
        }

        private void AlterarMensagemInformacaoPlanoCobranca(ModalidadePlanoCobranca modalidadePlanoCobranca)
        {
            if(modalidadePlanoCobranca == ModalidadePlanoCobranca.Diario)
                lblInformacaoPlanoCobranca.Text = "Valor por KM calculado somente na devolução";
            else if(modalidadePlanoCobranca == ModalidadePlanoCobranca.Controle)
                lblInformacaoPlanoCobranca.Text = "Multa para limite de KM excedido";
            else if(modalidadePlanoCobranca == ModalidadePlanoCobranca.Livre)
                lblInformacaoPlanoCobranca.Text = string.Empty;
        }

        private void CalcularDiasLocacao()
        {
            qtdDiasLocacao = datePickerDataDevolucao.Value.DayOfYear - datePickerDataLocacao.Value.DayOfYear;
            
            if(qtdDiasLocacao == 0)
                qtdDiasLocacao = 1;

            CalcularValorTotalPrevisto();
        }

        private void datePickerDataDevolucao_ValueChanged(object sender, EventArgs e)
        {
            CalcularDiasLocacao();
        }

        private void listTaxas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            Taxa taxaSelecionada = (Taxa)listTaxas.SelectedItem;
            if (listTaxas.CheckedItems.Contains(taxaSelecionada))
                valorTaxasSelecionadas -= taxaSelecionada.Valor;
            else
                valorTaxasSelecionadas += taxaSelecionada.Valor;

            CalcularValorTotalPrevisto();
        }

        private void LimitarCalendarios()
        {
            if(locacao.DataLocacao == DateTime.Now)
                datePickerDataLocacao.MinDate = DateTime.Now.Date;
            if(locacao.DataDevolucaoPrevista == DateTime.Now)
                datePickerDataDevolucao.MinDate = DateTime.Now.Date;
            else if(locacao.DataLocacao.Date <= DateTime.Now.Date)
            {
                datePickerDataLocacao.MinDate = locacao.DataLocacao;
                datePickerDataLocacao.Enabled = false;
            }
        }        
    }
}
