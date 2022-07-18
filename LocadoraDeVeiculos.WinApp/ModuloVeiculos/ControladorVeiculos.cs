using LocadoraDeVeiculos.Aplicacao.ModuloVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.WinApp.Compartilhado;


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
                CarregarVeiculos();           
        }

        public override void Editar()
        {
            Veiculos veiculosSelecionado = ObtemVeiculosSelecionado();

            if (veiculosSelecionado == null)
            {
                MessageBox.Show("Selecione um veículo",
                "Edição de um  veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroVeiculosForm tela = new TelaCadastroVeiculosForm();

            tela.Veiculos = veiculosSelecionado.Clonar();

            tela.GravarRegistro = servicoVeiculos.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)            
                CarregarVeiculos();          
        }

        public override void Excluir()
        {
            Veiculos veiculosSelecionado = ObtemVeiculosSelecionado();

            if (veiculosSelecionado == null)
            {
                MessageBox.Show("Selecione um veiculo",
                "Exclusão de veículo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir este veículo?",
                "Exclusão de veículo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioVeiculos.Excluir(veiculosSelecionado);
                CarregarVeiculos();
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
        public Veiculos ObtemVeiculosSelecionado()
        {
            var id = tabelaVeiculos.ObtemNumeroVeiculoSelecionado();

            return repositorioVeiculos.SelecionarPorId(id);
        }
        public void CarregarVeiculos()
        {
            List<Veiculos> veiculos = repositorioVeiculos.SelecionarTodos();

            tabelaVeiculos.AtualizarRegistros(veiculos);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {veiculos.Count} veiculo(s)");
        }
    }
}
