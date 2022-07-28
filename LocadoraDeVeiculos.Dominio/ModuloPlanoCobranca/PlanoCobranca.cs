using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca
{
    public class PlanoCobranca : EntidadeBase<PlanoCobranca>
    {
        public GrupoVeiculos GrupoVeiculos { get; set; }
        public ModalidadePlanoCobranca ModalidadePlanoCobranca { get; set; }
        public Decimal ValorDiaria { get; set; }
        public Decimal LimiteKm { get; set; }
        public Decimal ValorKm { get; set; }

        public override string ToString()
        {
            return $"{ModalidadePlanoCobranca}";
        }

        public PlanoCobranca Clonar()
        {
            return MemberwiseClone() as PlanoCobranca;
        }        
       
        public override bool Equals(object? obj)
        {
            PlanoCobranca planoCobranca = obj as PlanoCobranca;

            if (planoCobranca == null)
                return false;

            return
                planoCobranca.Id.Equals(Id) &&
                planoCobranca.ModalidadePlanoCobranca.Equals(ModalidadePlanoCobranca) &&
                planoCobranca.LimiteKm.Equals(LimiteKm) &&
                planoCobranca.ValorDiaria.Equals(ValorDiaria) &&
                planoCobranca.ValorKm.Equals(ValorKm);
        }
    }
}
