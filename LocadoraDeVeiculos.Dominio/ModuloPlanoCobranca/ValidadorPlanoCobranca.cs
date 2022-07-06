using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca
{
    public class ValidadorPlanoCobranca : AbstractValidator<PlanoCobranca>
    {
        public ValidadorPlanoCobranca()
        {
            RuleFor(x => x.GrupoVeiculos)
                .NotNull();

            RuleFor(x => x.ValorDiaria)
               .NotNull();

            RuleFor(x => x.ValorKm)
               .NotNull();

            RuleFor(x => x.LimiteKm)
               .NotNull();

            RuleFor(x => x.ModalidadePlanoCobranca)
               .NotNull();
        }
    }
}
