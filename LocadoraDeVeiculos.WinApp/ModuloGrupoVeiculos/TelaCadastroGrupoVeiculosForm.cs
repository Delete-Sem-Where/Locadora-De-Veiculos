﻿using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public Func<GrupoVeiculos, Result<GrupoVeiculos>> GravarRegistro { get; set; }
        
        private GrupoVeiculos grupoVeiculos;

        public GrupoVeiculos GrupoVeiculos
        {
            get
            {
                return grupoVeiculos;
            }
            set
            {
                grupoVeiculos = value;
                txtNumero.Text = GrupoVeiculos.Id.ToString();
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

        private void buttonGravarGrupoVeiculos_Click_1(object sender, EventArgs e)
        {
            grupoVeiculos.Nome = textBoxNomeGrupoVeiculos.Text;

            var resultadoValidacao = GravarRegistro(grupoVeiculos);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
        }
    }
}

