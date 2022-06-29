using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos
{
    public class ValidadorGrupoVeiculos : AbstractValidator<GrupoVeiculos>
    {
        public ValidadorGrupoVeiculos()
        {
            Regex regex = new Regex("^[a-z A-Z0-9]*$");

            RuleFor(x => x.Nome)
                    .NotNull().NotEmpty()
                    .MinimumLength(2)
                    .Matches(regex);
        }
    }
}
