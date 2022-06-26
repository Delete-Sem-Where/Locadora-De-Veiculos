using FluentValidation;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxas
{
    public class ValidadorTaxa : AbstractValidator<Taxa>
    {
        //acrescentar as regras do jamboard de validação
        
        public ValidadorTaxa()
        {
            RuleFor(x => x.Descricao)
                .NotNull().NotEmpty()
                .MinimumLength(2)
                .Nomes();
            

            RuleFor(x => x.Valor)
                .GreaterThan(0);
        }
    }
}
