using LocadoraDeVeiculos.Aplicacao.ModuloVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloVeiculos
{
    public class ControladorVeiculos : ControladorBase
    {
        private TabelaVeiculosControl tabelaVeiculos;
        private readonly IRepositorioVeiculos repositorioVeiculos;
        private readonly ServicoVeiculos servicoVeiculos;

        public ControladorVeiculos(IRepositorioVeiculos repositorioVeiculos, ServicoVeiculos servicoVeiculos)
        {
            this.repositorioVeiculos = repositorioVeiculos;
            this.servicoVeiculos = servicoVeiculos;
        }

        public override void Inserir()
        {
            TelaCadastroVeiculosForm tela = new TelaCadastroVeiculosForm();
            tela.Veiculos = new Veiculos();

            tela.GravarRegistro = servicoVeiculos.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarVeiculos();
            }
        }

        public override void Editar()
        {
            Veiculos VeiculosSelecionado = ObtemVeiculosSelecionado();

            if (VeiculosSelecionado == null)
            {
                MessageBox.Show("Selecione um veículo",
                "Edição de um  veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroVeiculosForm tela = new TelaCadastroVeiculosForm();

            tela.Veiculos = VeiculosSelecionado.Clonar();

            tela.GravarRegistro = servicoVeiculos.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarVeiculos();
            }
        }

        public override void Excluir()
        {
            Veiculos VeiculosSelecionado = ObtemVeiculosSelecionado();

            if (VeiculosSelecionado == null)
            {
                MessageBox.Show("Selecione um veiculo",
                "Exclusão de um Veiculos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir esse veículo?",
                "Exclusão de um Veiculo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioVeiculos.Excluir(VeiculosSelecionado);
                CarregarVeiculos();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxVeiculos();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaVeiculos == null)
                tabelaVeiculos = new TabelaVeiculosControl();

            CarregarVeiculos();

            return tabelaVeiculos;
        }

        public void CarregarVeiculos()
        {
            List<Veiculos> Veiculos = repositorioVeiculos.SelecionarTodos();

            tabelaVeiculos.AtualizarRegistros(Veiculos);
            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {Veiculos.Count} veiculos");
        }

        public Veiculos ObtemVeiculosSelecionado()
        {
            var id = tabelaVeiculos.ObtemNumeroVeiculoSelecionado();

            return repositorioVeiculos.SelecionarPorId(id);
        }

    }
}
