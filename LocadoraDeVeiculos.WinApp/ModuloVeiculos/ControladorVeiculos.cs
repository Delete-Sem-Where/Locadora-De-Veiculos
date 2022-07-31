using LocadoraDeVeiculos.Aplicacao.ModuloGrupoVeiculos;
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
        private readonly ServicoVeiculos servicoVeiculos;
        private ServicoGrupoVeiculos servicoGrupoVeiculos;

        public ControladorVeiculos(ServicoVeiculos servicoVeiculos, ServicoGrupoVeiculos servicoGrupoVeiculos)
        {
            this.servicoVeiculos = servicoVeiculos;
            this.servicoGrupoVeiculos = servicoGrupoVeiculos;

        }

        public override void Inserir()
        {
            TelaCadastroVeiculosForm tela = new TelaCadastroVeiculosForm(ObterGrupoVeiculos());

            tela.Veiculos = new Veiculos();

            tela.GravarRegistro = servicoVeiculos.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarVeiculos();
        }

        public override void Editar()
        {
            var id = tabelaVeiculos.ObtemNumeroVeiculoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um veículo",
                "Edição de veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoVeiculos.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var veiculoSelecionado = resultado.Value;

            TelaCadastroVeiculosForm tela = new TelaCadastroVeiculosForm(ObterGrupoVeiculos());

            tela.Veiculos = veiculoSelecionado;

            tela.GravarRegistro = servicoVeiculos.Editar;

            DialogResult resultadoTela = tela.ShowDialog();

            if (resultadoTela == DialogResult.OK)
                CarregarVeiculos();
        }

        public override void Excluir()
        {
            var id = tabelaVeiculos.ObtemNumeroVeiculoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um veiculo",
                "Exclusão de veículo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoVeiculos.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var funcionarioSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o veículo?", "Exclusão de veículo",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoVeiculos.Excluir(funcionarioSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarVeiculos();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de veículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxVeiculos();
        }

        public override UserControl ObtemListagem()
        {
            tabelaVeiculos = new TabelaVeiculosControl();

            CarregarVeiculos();

            return tabelaVeiculos;
        }

        public void CarregarVeiculos()
        {
            var resultado = servicoVeiculos.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Veiculos> veiculos = resultado.Value;

                tabelaVeiculos.AtualizarRegistros(veiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {veiculos.Count} veiculo(s)");
            }
            else        
                MessageBox.Show(resultado.Errors[0].Message, "Listagem de Veículo",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }
        private List<GrupoVeiculos> ObterGrupoVeiculos()
        {
            var resultado = servicoGrupoVeiculos.SelecionarTodos();
            List<GrupoVeiculos> lista = new List<GrupoVeiculos>();
            if (resultado.IsSuccess)
                lista = resultado.Value;
            return lista;
        }
    }
}
