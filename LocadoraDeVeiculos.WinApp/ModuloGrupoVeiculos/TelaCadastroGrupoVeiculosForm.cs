using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloGruposVeiculos
{
    public partial class TelaCadastroGrupoVeiculosForm : Form
    {       
        public TelaCadastroGrupoVeiculosForm()
        {
            InitializeComponent();
        }        
        public Func<GrupoVeiculos, ValidationResult> GravarRegistro { get; set; }
        
        private GrupoVeiculos grupoVeiculos;

        public GrupoVeiculos GrupoVeiculos
        {
            get
            {
                return grupoVeiculos;
            }
            set
            {
                textBoxNomeGrupoVeiculos.Text = GrupoVeiculos.Nome;
            }
        }

        private void TelaCadastroGrupoVeiculosForm_Load(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroGrupoVeiculosaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void buttonGravarGrupoVeiculos_Click(object sender, EventArgs e)
        {
            grupoVeiculos.Nome = textBoxNomeGrupoVeiculos.Text;

            var resultadoValidacao = GravarRegistro(grupoVeiculos);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;
                TelaPrincipalForm.Instancia.AtualizarRodape(erro);
                DialogResult = DialogResult.None;
            }

        }
    }
}

