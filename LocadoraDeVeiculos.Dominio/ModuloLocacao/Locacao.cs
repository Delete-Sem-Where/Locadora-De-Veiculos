using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloLocacao
{
    public class Locacao : EntidadeBase<Locacao>
    {
        public Cliente Cliente { get; set; }

        public Condutor Condutor { get; set; }

        public GrupoVeiculos GrupoVeiculos { get; set; }

        public Veiculos Veiculo { get; set; }

        public PlanoCobranca PlanoCobranca { get; set; }

        public DateTime DataLocacao { get; set; }

        public DateTime DataDevolucaoPrevista { get; set; }

        public List<Taxa> TaxasSelecionadas { get; set; }

        public double ValorTotalPrevisto { get; set; }

        public Locacao()
        {
            DataLocacao = DateTime.Now;
        }

        public Locacao Clonar()
        {
            return MemberwiseClone() as Locacao;
        }

        public override bool Equals(object? obj)
        {
            Locacao locacao = obj as Locacao;

            if (locacao == null)
                return false;

            return
                locacao.Id.Equals(Id) &&
                locacao.Cliente.Equals(Cliente) &&
                locacao.Condutor.Equals(Condutor) &&
                locacao.GrupoVeiculos.Equals(GrupoVeiculos) &&
                locacao.Veiculo.Equals(Veiculo) &&
                locacao.PlanoCobranca.Equals(PlanoCobranca) &&
                locacao.DataLocacao.Equals(DataLocacao) &&
                locacao.DataDevolucaoPrevista.Equals(DataDevolucaoPrevista) &&
                locacao.TaxasSelecionadas.Equals(TaxasSelecionadas) &&
                locacao.ValorTotalPrevisto.Equals(ValorTotalPrevisto);
        }
    }
}
