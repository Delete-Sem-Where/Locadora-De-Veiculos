using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos
{
    public class GrupoVeiculos : EntidadeBase<GrupoVeiculos>
    {
        public string? Nome { get; set; }
        public override string ToString()
        {
            return $"Nome: {Nome};";
        }

        public GrupoVeiculos Clonar()
        {
            return MemberwiseClone() as GrupoVeiculos;
        }

        public override bool Equals(object? obj)
        {
            GrupoVeiculos grupoVeiculos = obj as GrupoVeiculos;

            if (grupoVeiculos == null)
                return false;

            return
                grupoVeiculos.Id.Equals(Id) &&
                grupoVeiculos.Nome.Equals(Nome);
        }
    }
}
