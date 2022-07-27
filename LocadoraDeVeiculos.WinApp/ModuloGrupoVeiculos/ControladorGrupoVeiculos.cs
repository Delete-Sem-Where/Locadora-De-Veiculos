using LocadoraDeVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloGruposVeiculos
{
    public class ControladorGrupoVeiculos : ControladorBase
    {
        private TabelaGrupoVeiculosControl tabelaGrupoVeiculos;
        private readonly IRepositorioGrupoVeiculos repositorioGrupoVeiculos;
        private readonly ServicoGrupoVeiculos servicoGrupoVeiculos;

        public ControladorGrupoVeiculos(IRepositorioGrupoVeiculos repositorioGrupoVeiculos, ServicoGrupoVeiculos servicoGrupoVeiculos)
        {
            this.repositorioGrupoVeiculos = repositorioGrupoVeiculos;
            this.servicoGrupoVeiculos = servicoGrupoVeiculos;
        }

        public override void Inserir()
        {
            TelaCadastroGrupoVeiculosForm tela = new TelaCadastroGrupoVeiculosForm();
            tela.GrupoVeiculos = new GrupoVeiculos();

            tela.GravarRegistro = servicoGrupoVeiculos.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarGrupoVeiculos();
            }
        }

        public override void Editar()
        {
            GrupoVeiculos GrupoVeiculosSelecionado = ObtemGrupoVeiculosSelecionado();

            if (GrupoVeiculosSelecionado == null)
            {
                MessageBox.Show("Selecione um agrupamento",
                "Edição de um agrupamento de veiculos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroGrupoVeiculosForm tela = new TelaCadastroGrupoVeiculosForm();

            tela.GrupoVeiculos = GrupoVeiculosSelecionado.Clonar();

            tela.GravarRegistro = servicoGrupoVeiculos.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarGrupoVeiculos();
            }
        }

        public override void Excluir()
        {
            GrupoVeiculos GrupoVeiculosSelecionado = ObtemGrupoVeiculosSelecionado();

            if (GrupoVeiculosSelecionado == null)
            {
                MessageBox.Show("Selecione um grupo de veiculos",
                "Exclusão de um Grupo de Veiculos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir esse agrupamento?",
                "Exclusão de um Grupo de Veiculos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioGrupoVeiculos.Excluir(GrupoVeiculosSelecionado);
                CarregarGrupoVeiculos();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxGrupoVeiculos();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaGrupoVeiculos == null)
                tabelaGrupoVeiculos = new TabelaGrupoVeiculosControl();

            CarregarGrupoVeiculos();

            return tabelaGrupoVeiculos;
        }

        public void CarregarGrupoVeiculos()
        {
            List<GrupoVeiculos> GrupoVeiculos = repositorioGrupoVeiculos.SelecionarTodos();

            tabelaGrupoVeiculos.AtualizarRegistros(GrupoVeiculos);
            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {GrupoVeiculos.Count} grupo de veiculos");
        }

        public GrupoVeiculos ObtemGrupoVeiculosSelecionado()
        {
            var id = tabelaGrupoVeiculos.ObtemNumeroGrupoVeiculosSelecionado();

            return repositorioGrupoVeiculos.SelecionarPorId(id);
        }

    }
}