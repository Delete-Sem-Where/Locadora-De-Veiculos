using FluentValidation;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloVeiculos
{
    public class ValidadorVeiculos : AbstractValidator<Veiculos>
    {
        public ValidadorVeiculos()
        {
            RuleFor(x => x.Modelo)
                    .NotNull().NotEmpty()
                    .MinimumLength(2)
                    .Matches(@"^[a-zA-Zà-úÀ-ÚçÇ0-9 ]+$");

            RuleFor(x => x.Marca)
                    .NotNull().NotEmpty()
                    .MinimumLength(2)
                    .Matches(@"^[a-zA-Zà-úÀ-ÚçÇ ]+$");
           
            RuleFor(x => x.Placa)
                    .NotNull().NotEmpty()
                    .MinimumLength(7)
                    .MaximumLength(7)
                    .Matches(@"^[^0-9a-zA-Z]+$");

            RuleFor(x => x.Cor)
                    .NotNull().NotEmpty()
                    .MinimumLength(3);

            RuleFor(x => x.Ano)
                    .NotNull()
                    .NotEmpty()
                    .MinimumLength(4)
                    .MaximumLength(4)
                    .Matches(@"^[^0-9]")
            // TODO .GreaterThanOrEqualTo(2000)
                    ;

            RuleFor(x => x.QuilometroPercorrido)
                    .NotNull().NotEmpty();

            RuleFor(x => x.TipoCombustivel)
                    .NotNull().NotEmpty();

            RuleFor(x => x.CapacidadeTanque)
                    .NotNull().NotEmpty()
                    .Matches(@"^[^0-9]")
             //TODO .GreaterThan(0);
                    ;

            RuleFor(x => x.GrupoVeiculos_Id)
                    .NotNull().NotEmpty();
        }
    }
}
