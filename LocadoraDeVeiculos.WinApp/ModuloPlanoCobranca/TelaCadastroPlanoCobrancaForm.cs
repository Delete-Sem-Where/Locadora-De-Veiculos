using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloPlanoCobranca
{
    public partial class TelaCadastroPlanoCobrancaForm : Form
    {
        private PlanoCobranca planoCobranca;

        public TelaCadastroPlanoCobrancaForm(List<GrupoVeiculos> grupos)
        {
            InitializeComponent();
            CarregarGrupos(grupos);
        }
        public Func<PlanoCobranca, ValidationResult> GravarRegistro { get; set; }

        private void CarregarGrupos(List<GrupoVeiculos> grupos)
        {           
            cmbGrupoVeiculos.Items.Clear();

            foreach (var item in grupos)
            {                
                cmbGrupoVeiculos.Items.Add(item);
            }
        }

        public PlanoCobranca PlanoCobranca
        {
            get
            {
                return planoCobranca;
            }
            set
            {
                planoCobranca = value;
                if (planoCobranca.Id != 0)
                {
                    PreencherDadosNaTela();
                }
            }
        }

        

        private void TelaCadastroPlanoCobrancaForm_Load(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroPlanoCobrancaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        

        private void buttonGravarPlanoCobranca_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabPage1)
            {
                GravarInformacoesTab1();
            }

            else if (tabControl.SelectedTab == tabPage2)
            {
                GravarInformacoesTab2();
            }
            else if (tabControl.SelectedTab == tabPage3)
            {
                GravarInformacoesTab3();
            }
        }

        #region SUBMETODOS

        private void PreencherDadosNaTela()
        {
            cmbGrupoVeiculos.SelectedItem = planoCobranca.GrupoVeiculos;

            if (planoCobranca.ModalidadePlanoCobranca == ModalidadePlanoCobranca.Diario)
            {
                tabControl.SelectedTab = tabPage1;
                txtValorDiaria_tab1.Value = planoCobranca.ValorDiaria;
                txtValorKm_tab1.Value = planoCobranca.ValorKm;

            }

            else if (planoCobranca.ModalidadePlanoCobranca == ModalidadePlanoCobranca.Livre)
            {
                tabControl.SelectedTab = tabPage2;
                txtValorDiaria_tab2.Value = planoCobranca.ValorDiaria;

            }

            else if (planoCobranca.ModalidadePlanoCobranca == ModalidadePlanoCobranca.Controle)
            {
                tabControl.SelectedTab = tabPage3;
                txtValorDiaria_tab3.Value = planoCobranca.ValorDiaria;
                txtValorKm_tab3.Value = planoCobranca.ValorKm;
            }
        }

        private void GravarInformacoesTab1()
        {
            planoCobranca.GrupoVeiculos = (GrupoVeiculos)cmbGrupoVeiculos.SelectedItem;
            planoCobranca.ModalidadePlanoCobranca = ModalidadePlanoCobranca.Diario;
            planoCobranca.ValorDiaria = txtValorDiaria_tab1.Value;
            planoCobranca.ValorKm = txtValorKm_tab1.Value;

            //zerando atributos q ele nao tem
            planoCobranca.LimiteKm = 0;

            var resultadoValidacao = GravarRegistro(planoCobranca);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;
                TelaPrincipalForm.Instancia.AtualizarRodape(erro);
                DialogResult = DialogResult.None;
            }
        }
        private void GravarInformacoesTab2()
        {
            planoCobranca.GrupoVeiculos = (GrupoVeiculos)cmbGrupoVeiculos.SelectedItem;
            planoCobranca.ModalidadePlanoCobranca = ModalidadePlanoCobranca.Livre;
            planoCobranca.ValorDiaria = txtValorDiaria_tab2.Value;

            //zerando atributos q ele nao tem
            planoCobranca.LimiteKm = 0;
            planoCobranca.ValorKm = 0;

            var resultadoValidacao = GravarRegistro(planoCobranca);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;
                TelaPrincipalForm.Instancia.AtualizarRodape(erro);
                DialogResult = DialogResult.None;
            }
        }
        private void GravarInformacoesTab3()
        {
            planoCobranca.GrupoVeiculos = (GrupoVeiculos)cmbGrupoVeiculos.SelectedItem;

            planoCobranca.ModalidadePlanoCobranca = ModalidadePlanoCobranca.Controle;
            planoCobranca.ValorDiaria = txtValorDiaria_tab3.Value;
            planoCobranca.ValorKm = txtValorKm_tab3.Value;
            planoCobranca.LimiteKm = txtLimiteKm_tab3.Value;

            var resultadoValidacao = GravarRegistro(planoCobranca);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;
                TelaPrincipalForm.Instancia.AtualizarRodape(erro);
                DialogResult = DialogResult.None;
            }
        }
        private void cmbGrupoVeiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControl.Enabled = true;
        }
        #endregion 
    }
}
