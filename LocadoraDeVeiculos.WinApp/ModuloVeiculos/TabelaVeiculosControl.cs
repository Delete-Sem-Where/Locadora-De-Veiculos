using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.WinApp.Compartilhado;


namespace LocadoraDeVeiculos.WinApp.ModuloVeiculos
{
    public partial class TabelaVeiculosControl : UserControl
    {
        public TabelaVeiculosControl()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Modelo", HeaderText = "Modelo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Marca", HeaderText = "Marca"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Ano", HeaderText = "Ano"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Cor", HeaderText = "Cor"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Placa", HeaderText = "Placa"},

                new DataGridViewTextBoxColumn { DataPropertyName = "TipoCombustivel", HeaderText = "Tipo de Combustível"},

                new DataGridViewTextBoxColumn { DataPropertyName = "KmPercorridos", HeaderText = "Quilometros Percorrido"},

                new DataGridViewTextBoxColumn { DataPropertyName = "CapacidadeTanque", HeaderText = "Capacidade do Tanque"}
            };

            return colunas;
        }

        public Guid ObtemNumeroVeiculoSelecionado()
        {
            return grid.SelecionarNumero<Guid>();
        }

        public void AtualizarRegistros(List<Veiculos> veiculos)
        {
            grid.Rows.Clear();

            foreach (Veiculos v in veiculos)
            {
                grid.Rows.Add(v.Id, v.Modelo, v.Marca, v.Ano, v.Cor, v.Placa,
                               v.TipoCombustivel, v.QuilometroPercorrido + " Km",
                               v.CapacidadeTanque + " Litros");
            }
        }
    }
}
