using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloGruposVeiculos;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;

namespace LocadoraDeVeiculos.WinApp.ModuloVeiculos
{
    public partial class TelaCadastroVeiculosForm : Form
    {
        public TelaCadastroVeiculosForm()
        {
            InitializeComponent();

            CarregarGrupoVeiculos();
        }

        private readonly RepositorioGrupoVeiculosEmBancoDados repositorioGrupoVeiculos = new RepositorioGrupoVeiculosEmBancoDados();
        private void CarregarGrupoVeiculos()
        {
            cmbGrupoVeiculos.Items.Clear();

            var grupoVeiculos = repositorioGrupoVeiculos.SelecionarTodos();
            foreach (var item in grupoVeiculos)
            {
                cmbGrupoVeiculos.Items.Add(item);
            }
        }

        public Func<Veiculos, ValidationResult> GravarRegistro { get; set; }

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

            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            veiculos.Modelo = txtModelo.Text;
            veiculos.Placa = txtPlaca.Text;
            veiculos.Marca = txtMarca.Text;
            veiculos.Cor = txtCor.Text;
            veiculos.QuilometroPercorrido = txtKmPercorrido.Text;
            veiculos.Ano = txtAno.Text;
            veiculos.CapacidadeTanque = txtCapacidadeTanque.Text;
            veiculos.TipoCombustivel = txtTipoCombustivel.Text;


            var grupoVeiculos_selecionado = (GrupoVeiculos)cmbGrupoVeiculos.SelectedItem;
            veiculos.GrupoVeiculos_Id = grupoVeiculos_selecionado.Id;

            var resultadoValidacao = GravarRegistro(veiculos);
            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;
                TelaPrincipalForm.Instancia.AtualizarRodape(erro);
                DialogResult = DialogResult.None;
            }
        }


        private void btnSelecionarFoto_Click(object sender, EventArgs e)
        {
            /*
            string origemCompleto = "";
            string foto = "";
            string pastaDestino = Fotos.enderecoFotos;
            string destinoCompleto = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                origemCompleto = openFileDialog1.FileName;
                foto = openFileDialog1.SafeFileName;
                destinoCompleto = pastaDestino + foto;

                if (File.Exists(destinoCompleto))
                {
                    if (MessageBox.Show("Arquivo com esse nome já existe, deseja substituir?", "Substituir",
                        MessageBoxButtons.YesNo) == DialogResult.No)

                        return;
                }
                System.IO.File.Copy(origemCompleto, destinoCompleto, true);

                if (File.Exists(destinoCompleto))
                    pb_foto.ImageLocation = origemCompleto;

                else
                    MessageBox.Show("Arquivo não copiado");
            */

         }
     }     
 }

