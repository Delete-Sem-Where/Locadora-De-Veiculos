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

            When(x => x.ModalidadePlanoCobranca == ModalidadePlanoCobranca.Diario, () =>
            {
                RuleFor(x => x.ValorDiaria)
               .GreaterThan(0);

                RuleFor(x => x.ValorKm)
                   .GreaterThan(0);
            });

            When(x => x.ModalidadePlanoCobranca == ModalidadePlanoCobranca.Livre, () =>
            {
                RuleFor(x => x.ValorDiaria)
               .GreaterThan(0);

            });

            When(x => x.ModalidadePlanoCobranca == ModalidadePlanoCobranca.Controle, () =>
            {
                RuleFor(x => x.ValorDiaria)
                    .GreaterThan(0);

                RuleFor(x => x.ValorKm)
                    .GreaterThan(0);

                RuleFor(x => x.LimiteKm)
                    .GreaterThan(0);

            });            
        }
    }
}
