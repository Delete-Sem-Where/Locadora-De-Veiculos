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
        private readonly ServicoGrupoVeiculos servicoGrupoVeiculos;

        public ControladorGrupoVeiculos(ServicoGrupoVeiculos servicoGrupoVeiculos)
        {
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
            var id = tabelaGrupoVeiculos.ObtemNumeroGrupoVeiculosSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um agrupamento",
                "Edição de um agrupamento de veiculos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoGrupoVeiculos.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var grupoSelecionado = resultado.Value;

            TelaCadastroGrupoVeiculosForm tela = new TelaCadastroGrupoVeiculosForm();

            tela.GrupoVeiculos = grupoSelecionado;

            tela.GravarRegistro = servicoGrupoVeiculos.Editar;

            DialogResult resultadoTela = tela.ShowDialog();

            if (resultadoTela == DialogResult.OK)
                CarregarGrupoVeiculos();
        }

        public override void Excluir()
        {
            var id = tabelaGrupoVeiculos.ObtemNumeroGrupoVeiculosSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um agrupamento",
                "Exclusão de um Grupo de Veiculos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoGrupoVeiculos.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var grupoSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o grupo de veículos?", "Exclusão de Grupo de Veículos",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoGrupoVeiculos.Excluir(grupoSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarGrupoVeiculos();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            var resultado = servicoGrupoVeiculos.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<GrupoVeiculos> grupos = resultado.Value;

                tabelaGrupoVeiculos.AtualizarRegistros(grupos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {grupos.Count} grupo(s) de veículos");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Listagem de Grupo de Veículos",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}