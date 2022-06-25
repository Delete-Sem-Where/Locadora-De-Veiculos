using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxas
{
    public class Taxa:EntidadeBase<Taxa>
    {
        public string Nome { get; set; }
        
        public override string ToString()
        {
            return $"{Nome}";
        }
    }
}
