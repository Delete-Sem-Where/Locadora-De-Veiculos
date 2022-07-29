using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloLocacao
{
    public partial class TelaCadastroDevolucaoForm : Form
    {
        //List<Cliente> clientes;
        List<Condutor> condutores;
        List<Veiculos> veiculos;
        List<PlanoCobranca> planosCobrancas;
        List<Taxa> taxas;
        PlanoCobranca planoCobrancaSelecionado;
        decimal valorTaxasSelecionadasLocacao = 0;
        decimal valorTaxasSelecionadas = 0;
        int qtdDiasLocacao = 0;

        public TelaCadastroDevolucaoForm(List<Cliente> clientes, List<Condutor> condutores, List<GrupoVeiculos> gruposVeiculos, List<Veiculos> veiculos, List<PlanoCobranca> planosCobrancas, List<Taxa> taxas)
        {
            InitializeComponent();
            this.planosCobrancas = planosCobrancas;
            this.taxas = taxas;
            CarregarNiveisTanque();            
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
                locacao.DataDevolucao = DateTime.Now;
                PreencherDadosNaTela();
            }
        }
        
        private void PreencherDadosNaTela()
        {
            txtNumero.Text = locacao.Id.ToString();
            lblCliente.Text = locacao.Cliente.Nome;
            lblCondutor.Text = locacao.Condutor.Nome;
            lblGrupoVeiculos.Text = locacao.GrupoVeiculos.Nome;
            lblVeiculo.Text = locacao.Veiculo.Modelo;
            lblPlanoCobranca.Text = locacao.PlanoCobranca.ModalidadePlanoCobranca.ToString();
            numericKm.Minimum = Convert.ToDecimal(locacao.Veiculo.QuilometroPercorrido);

            CarregarTaxasSelecionadas();
            CarregarTaxasNaoSelecionadas(taxas);

            dateTimePickerDataLocacao.Value = locacao.DataLocacao;
            dateTimePickerDataDevolucaoPrevista.Value = locacao.DataDevolucaoPrevista;
            dateTimePickerDataDevolucao.Value = locacao.DataDevolucao = DateTime.Now; 
            
            CalcularDiasLocacao();
            CalcularValorTotal();
        }

        private void CarregarTaxasSelecionadas()
        {
            listTaxas.Items.Clear();
            var i = 0;
            foreach (var item in locacao.TaxasSelecionadas)
            {                
                listTaxas.Items.Add(item);
                listTaxas.SetItemChecked(i,true);
                valorTaxasSelecionadasLocacao += item.Valor;
                i++;
            }
        }

        private void CarregarTaxasNaoSelecionadas(List<Taxa> taxas)
        {
            listTaxas2.Items.Clear();

            foreach (var item in taxas)
            {                
                if(!locacao.TaxasSelecionadas.Contains(item))
                {
                    listTaxas2.Items.Add(item);
                }
            }
        }

        private void CarregarNiveisTanque()
        {
            cmbNivelTanque.Items.Clear();
            
                foreach (var item in Enum.GetValues(typeof(NivelTanqueDevolucao)))
                {
                    cmbNivelTanque.Items.Add(item);
                }            
        }

        private void CalcularValorTotal()
        {
            decimal valorTotal = 0;
            decimal calculoTaxas = valorTaxasSelecionadas + valorTaxasSelecionadasLocacao;
            decimal calculoDiaria = qtdDiasLocacao * locacao.PlanoCobranca.ValorDiaria;
            decimal calculoTanque = Calcular_Valor_Tanque();
            decimal calculoDeQuantoRodou = Calcular_km_rodado() * locacao.PlanoCobranca.ValorKm;


            if (locacao.PlanoCobranca.ModalidadePlanoCobranca == ModalidadePlanoCobranca.Livre)
            {
                valorTotal = calculoDiaria + calculoTaxas + calculoTanque;
            }
            else if (locacao.PlanoCobranca.ModalidadePlanoCobranca == ModalidadePlanoCobranca.Diario)
            {
                valorTotal = calculoDeQuantoRodou + calculoDiaria + calculoTaxas + calculoTanque;
            }
            else if (locacao.PlanoCobranca.ModalidadePlanoCobranca == ModalidadePlanoCobranca.Controle)
            {
                decimal fatorMulta = 0m;
                if (locacao.DataDevolucao.DayOfYear > locacao.DataDevolucaoPrevista.DayOfYear)
                {
                    fatorMulta = CalcularMulta();
                }
                valorTotal = (calculoDeQuantoRodou + calculoDiaria + calculoTaxas + calculoTanque) * fatorMulta;                
            }                       

            txtValorTotalDevolucao.Text = "R$" + valorTotal.ToString();
        }

        private decimal Calcular_km_rodado()
        {
            var valor = numericKm.Value - Convert.ToDecimal(locacao.Veiculo.QuilometroPercorrido);

            return valor;
        }

        private void listTaxas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            Taxa taxaSelecionada = (Taxa)listTaxas2.SelectedItem;
            if (listTaxas2.CheckedItems.Contains(taxaSelecionada))
                valorTaxasSelecionadas -= taxaSelecionada.Valor;
            else
                valorTaxasSelecionadas += taxaSelecionada.Valor;

            CalcularValorTotal();
        }
        private void km_alterado(object sender, EventArgs e)
        {
            CalcularValorTotal();
        }
        private void nivelTanque_alterado(object sender, EventArgs e)
        {            
            CalcularValorTotal();
        }
        private decimal Calcular_Valor_Tanque()
        {
            decimal coeficienteTanque = 0m;
            decimal valorGasolina = 5.67m;
            decimal valorTanque = Convert.ToDecimal(locacao.Veiculo.CapacidadeTanque) * valorGasolina;
            if (cmbNivelTanque.SelectedItem != null)
            {

                if (cmbNivelTanque.SelectedItem.Equals(NivelTanqueDevolucao.Vazio))
                    coeficienteTanque = 1m;
                if (cmbNivelTanque.SelectedItem.Equals(NivelTanqueDevolucao.UmQuarto))
                    coeficienteTanque = 0.75m;
                if (cmbNivelTanque.SelectedItem.Equals(NivelTanqueDevolucao.Meio))
                    coeficienteTanque = 0.5m;
                if (cmbNivelTanque.SelectedItem.Equals(NivelTanqueDevolucao.TresQuartos))
                    coeficienteTanque = 0.25m;
                if (cmbNivelTanque.SelectedItem.Equals(NivelTanqueDevolucao.Cheio))
                    coeficienteTanque = 0m;
            }

             var resultado = valorTanque * coeficienteTanque;

            return resultado;
        }

        private void CalcularDiasLocacao()
        {
            qtdDiasLocacao = locacao.DataDevolucao.DayOfYear - locacao.DataLocacao.DayOfYear;

            if (qtdDiasLocacao == 0)
                qtdDiasLocacao = 1;
        }

        private decimal CalcularMulta()
        {
            var qtdDias = locacao.DataDevolucao.DayOfYear - locacao.DataDevolucaoPrevista.DayOfYear;
            decimal fatorMulta = qtdDias * 0.1m;

            return fatorMulta;
        }

        private void btnGravarDevolucao_Click(object sender, EventArgs e)
        {
            var resultadoValidacaoSelecoes = ValidarCamposSelecionados();
            if (resultadoValidacaoSelecoes.IsSuccess)
            {
                locacao.EstaAlugado = false;
                locacao.DataDevolucao = DateTime.Now;
                locacao.NivelTanqueDevolucao = (NivelTanqueDevolucao)cmbNivelTanque.SelectedItem;
            }
            else
            {
                string erro = $"Não pode realizar a devolução com valores inválidos para o {resultadoValidacaoSelecoes.Errors[0].Message}";
                TelaPrincipalForm.Instancia.AtualizarRodape(erro);
                DialogResult = DialogResult.None;
                return;
            }
        }
        

        private Result ValidarCamposSelecionados()
        {
            if (cmbNivelTanque.SelectedItem == null)
            {
                return Result.Fail(new Error("Nivel para o Tanque"));
            }         
            else
            {
                return Result.Ok();
            }
        }

        
    }
}
