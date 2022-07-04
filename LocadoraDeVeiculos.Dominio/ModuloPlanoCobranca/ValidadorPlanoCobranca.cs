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
            //não sei se precisa de validador, se as casas são todas numéricas e já estão limitadas em max e min...
        }
    }
}
