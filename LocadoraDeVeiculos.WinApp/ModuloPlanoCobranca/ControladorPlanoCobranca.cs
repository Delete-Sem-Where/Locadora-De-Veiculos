using LocadoraDeVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Aplicacao.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloGruposVeiculos;
using LocadoraDeVeiculos.WinApp.Compartilhado;

namespace LocadoraDeVeiculos.WinApp.ModuloPlanoCobranca
{
    public class ControladorPlanoCobranca : ControladorBase
    {

        private TabelaPlanoCobrancaControl tabelaPlanoCobranca;
        private ServicoPlanoCobranca servicoPlanoCobranca;
        private ServicoGrupoVeiculos servicoGrupoVeiculos;

        public ControladorPlanoCobranca(ServicoPlanoCobranca servicoPlanoCobranca, ServicoGrupoVeiculos servicoGrupoVeiculos)
        {
            this.servicoPlanoCobranca = servicoPlanoCobranca;
            this.servicoGrupoVeiculos = servicoGrupoVeiculos;
        }

        public override void Inserir()
        {
            TelaCadastroPlanoCobrancaForm tela = new TelaCadastroPlanoCobrancaForm(ObterGrupoVeiculos());
            tela.PlanoCobranca = new PlanoCobranca();

            tela.GravarRegistro = servicoPlanoCobranca.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarPlanosCobrancas();

        }
        
        public override void Editar()
        {
            var id = tabelaPlanoCobranca.ObtemNumeroPlanoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um Plano de Cobrança primeiro",
                "Edição de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoPlanoCobranca.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message, "Edição de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TelaCadastroPlanoCobrancaForm tela = new TelaCadastroPlanoCobrancaForm(ObterGrupoVeiculos());

            var planoSelecionada = resultado.Value;

            tela.PlanoCobranca = planoSelecionada;

            tela.GravarRegistro = servicoPlanoCobranca.Editar;

            DialogResult resultadoTela = tela.ShowDialog();

            if (resultadoTela == DialogResult.OK)
                CarregarPlanosCobrancas();
        }

        public override void Excluir()
        {
            var id = tabelaPlanoCobranca.ObtemNumeroPlanoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um Plano de Cobrança primeiro",
                "Exclusão de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultadoTela = MessageBox.Show("Deseja realmente excluir o Plano de Cobrança?",
                "Exclusão de Plano de Cobrança", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            var resultado = servicoPlanoCobranca.SelecionarPorId(id);

            var planoCobrancaSelecionado = resultado.Value;

            if (resultadoTela == DialogResult.OK)
            {
                servicoPlanoCobranca.Excluir(planoCobrancaSelecionado);
                CarregarPlanosCobrancas();
            }
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaPlanoCobranca == null)
                tabelaPlanoCobranca = new TabelaPlanoCobrancaControl();

            CarregarPlanosCobrancas();

            return tabelaPlanoCobranca;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxPlanoCobranca();
        }

        public void CarregarPlanosCobrancas()
        {
            var resultado = servicoPlanoCobranca.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<PlanoCobranca> planosCobranca = resultado.Value;

                tabelaPlanoCobranca.AtualizarRegistros(planosCobranca);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {planosCobranca.Count} plano(s) de cobrança");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Listagem de plano(s) de cobrança",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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