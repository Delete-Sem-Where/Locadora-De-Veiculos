using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloCondutor
{
    public class ControladorCondutor : ControladorBase
    {
        private TabelaCondutorControl tabelaCondutor;
        private readonly ServicoCondutor servicoCondutor;

        public ControladorCondutor(ServicoCondutor servicoCondutor)
        {
            this.servicoCondutor = servicoCondutor;
        }

        public override void Inserir()
        {
            TelaCadastroCondutorForm tela = new TelaCadastroCondutorForm();
            tela.Condutor = new Condutor();

            tela.GravarRegistro = servicoCondutor.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarCondutores();

        }

        public override void Editar()
        {
            var id = tabelaCondutor.ObtemNumeroCondutorSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um Condutor primeiro",
                "Edição de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoCondutor.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var condutorSelecionado = resultado.Value;

            TelaCadastroCondutorForm tela = new TelaCadastroCondutorForm();

            tela.Condutor = condutorSelecionado.Clonar();

            tela.GravarRegistro = servicoCondutor.Editar;

            DialogResult resultadoTela = tela.ShowDialog();

            if (resultadoTela == DialogResult.OK)
                CarregarCondutores();
        }

        public override void Excluir()
        {
            var id = tabelaCondutor.ObtemNumeroCondutorSelecionado();
            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um condutor primeiro",
                    "Exclusão de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoCondutor.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var funcionarioSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o condutor?", "Exclusão de Condutor",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoCondutor.Excluir(funcionarioSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarCondutores();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override UserControl ObtemListagem()
        {
            tabelaCondutor = new TabelaCondutorControl();

            CarregarCondutores();

            return tabelaCondutor;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxCondutor();
        }

        private void CarregarCondutores()
        {
            var resultado = servicoCondutor.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Condutor> condutores = resultado.Value;

                tabelaCondutor.AtualizarRegistros(condutores);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {condutores.Count} condutor(es)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Listagem de Condutor",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
