using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloLocacao
{
    public class ValidadorLocacao : AbstractValidator<Locacao>
    {
        public ValidadorLocacao()
        {
            RuleFor(x => x.DataLocacao)
                .NotEqual(DateTime.MinValue);

            RuleFor(x => x.DataDevolucaoPrevista)
                .NotEqual(DateTime.MinValue);

            RuleFor(x => x.ValorTotalPrevisto)
                .GreaterThan(0);
        }
    }
}
