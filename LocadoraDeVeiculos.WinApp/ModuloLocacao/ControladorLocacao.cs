using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Aplicacao.ModuloLocacao;
using LocadoraDeVeiculos.Aplicacao.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxas;
using LocadoraDeVeiculos.Aplicacao.ModuloVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloLocacao
{
    public class ControladorLocacao : ControladorBase
    {
        private TabelaLocacaoControl tabelaLocacao;
        private readonly ServicoLocacao servicoLocacao;
        private readonly ServicoCliente servicoCliente;
        private readonly ServicoCondutor servicoCondutor;
        private readonly ServicoGrupoVeiculos servicoGrupoVeiculos;
        private readonly ServicoVeiculos servicoVeiculos;
        private readonly ServicoPlanoCobranca servicoPlanoCobranca;
        private readonly ServicoTaxa servicoTaxa;

        public ControladorLocacao(ServicoLocacao servicoLocacao, ServicoCliente servicoCliente, ServicoCondutor servicoCondutor, ServicoGrupoVeiculos servicoGrupoVeiculos, ServicoVeiculos servicoVeiculos, ServicoPlanoCobranca servicoPlanoCobranca, ServicoTaxa servicoTaxa)
        {
            this.servicoLocacao = servicoLocacao;
            this.servicoCliente = servicoCliente;
            this.servicoCondutor = servicoCondutor;
            this.servicoGrupoVeiculos = servicoGrupoVeiculos;
            this.servicoVeiculos = servicoVeiculos;
            this.servicoPlanoCobranca = servicoPlanoCobranca;
            this.servicoTaxa = servicoTaxa;
        }

        public override void Inserir()
        {
            TelaCadastroLocacaoForm tela = new TelaCadastroLocacaoForm(
                ObterClientes(),
                ObterCondutores(),
                ObterGrupoVeiculos(),
                ObterVeiculos(),
                ObterPlanoCobrancas(),
                ObterTaxas()
                );
            tela.Locacao = new Locacao();

            tela.GravarRegistro = servicoLocacao.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarLocacaoes();

        }

        public override void Editar()
        {
            var id = tabelaLocacao.ObtemNumeroLocacaoSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um Locacao primeiro",
                "Edição de Locacaoes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoLocacao.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Locacao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var condutorSelecionado = resultado.Value;

            TelaCadastroLocacaoForm tela = new TelaCadastroLocacaoForm(
                ObterClientes(),
                ObterCondutores(),
                ObterGrupoVeiculos(),
                ObterVeiculos(),
                ObterPlanoCobrancas(),
                ObterTaxas()
                );

            tela.Locacao = condutorSelecionado;

            tela.GravarRegistro = servicoLocacao.Editar;

            DialogResult resultadoTela = tela.ShowDialog();

            if (resultadoTela == DialogResult.OK)
                CarregarLocacaoes();
        }

        public override void Excluir()
        {
            var id = tabelaLocacao.ObtemNumeroLocacaoSelecionada();
            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um condutor primeiro",
                    "Exclusão de Locacao", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoLocacao.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Locacao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var funcionarioSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o condutor?", "Exclusão de Locacao",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoLocacao.Excluir(funcionarioSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarLocacaoes();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Locacao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override UserControl ObtemListagem()
        {
            tabelaLocacao = new TabelaLocacaoControl();

            CarregarLocacaoes();

            return tabelaLocacao;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxLocacao();
        }

        private void CarregarLocacaoes()
        {
            var resultado = servicoLocacao.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Locacao> condutores = resultado.Value;

                tabelaLocacao.AtualizarRegistros(condutores);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {condutores.Count} condutor(es)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Listagem de Locacao",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private List<Cliente> ObterClientes()
        {
            var resultado = servicoCliente.SelecionarTodos();
            List<Cliente> lista = new List<Cliente>();
            if (resultado.IsSuccess)
                lista = resultado.Value;
            return lista;
        }

        private List<Condutor> ObterCondutores()
        {
            var resultado = servicoCondutor.SelecionarTodos();
            List<Condutor> lista = new List<Condutor>();
            if (resultado.IsSuccess)
                lista = resultado.Value;
            return lista;
        }

        private List<GrupoVeiculos> ObterGrupoVeiculos()
        {
            var resultado = servicoGrupoVeiculos.SelecionarTodos();
            List<GrupoVeiculos> lista = new List<GrupoVeiculos>();
            if (resultado.IsSuccess)
                lista = resultado.Value;
            return lista;
        }

        private List<Veiculos> ObterVeiculos()
        {
            var resultado = servicoVeiculos.SelecionarTodos();
            List<Veiculos> lista = new List<Veiculos>();
            if (resultado.IsSuccess)
                lista = resultado.Value;
            return lista;
        }

        private List<PlanoCobranca> ObterPlanoCobrancas()
        {
            var resultado = servicoPlanoCobranca.SelecionarTodos();
            List<PlanoCobranca> lista = new List<PlanoCobranca>();
            if (resultado.IsSuccess)
                lista = resultado.Value;
            return lista;
        }

        private List<Taxa> ObterTaxas()
        {
            var resultado = servicoTaxa.SelecionarTodos();
            List<Taxa> lista = new List<Taxa>();
            if (resultado.IsSuccess)
                lista = resultado.Value;
            return lista;
        }

        #region Devolução

        public override void RegistrarDevolucao()
        {
            var id = tabelaLocacao.ObtemNumeroLocacaoSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um Locacao primeiro",
                "Devoluções", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoLocacao.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Devolução", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var condutorSelecionado = resultado.Value;

            TelaCadastroDevolucaoForm tela = new TelaCadastroDevolucaoForm(ObterClientes(),
                ObterCondutores(),
                ObterGrupoVeiculos(),
                ObterVeiculos(),
                ObterPlanoCobrancas(),
                ObterTaxas());

            tela.Locacao = condutorSelecionado;

            tela.GravarRegistro = servicoLocacao.Editar;

            DialogResult resultadoTela = tela.ShowDialog();

            if (resultadoTela == DialogResult.OK)
                CarregarLocacaoes();
        }

        #endregion
    }
}
