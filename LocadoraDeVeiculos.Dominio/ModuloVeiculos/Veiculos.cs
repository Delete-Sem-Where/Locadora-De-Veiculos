using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;

namespace LocadoraDeVeiculos.Dominio.ModuloVeiculos
{
    public class Veiculos : EntidadeBase<Veiculos>
    {
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Placa { get; set; }
        public string Ano { get; set; }
        public string Cor { get; set; }
        public string TipoCombustivel { get; set; }
        public string QuilometroPercorrido { get; set; }
        public string CapacidadeTanque { get; set; }
        public GrupoVeiculos GrupoVeiculos { get; set; }
        public byte[] Imagem { get; set; }

        public override string ToString()
        {
            return $"{Modelo}";
        }

        public Veiculos Clonar()
        {
            return MemberwiseClone() as Veiculos;
        }

        public override bool Equals(object? obj)
        {
            Veiculos veiculos = obj as Veiculos;

            if (veiculos == null)
                return false;

            return
                veiculos.Id.Equals(Id) &&
                veiculos.Modelo.Equals(Modelo)&&
                veiculos.Marca.Equals(Marca) &&
                veiculos.Placa.Equals(Placa) &&
                veiculos.Ano.Equals(Ano) &&
                veiculos.Cor.Equals(Cor) &&
                veiculos.TipoCombustivel.Equals(TipoCombustivel) &&
                veiculos.QuilometroPercorrido.Equals(QuilometroPercorrido) &&
                veiculos.CapacidadeTanque.Equals(CapacidadeTanque) &&
                veiculos.GrupoVeiculos.Equals(GrupoVeiculos);
        }
    }
}
