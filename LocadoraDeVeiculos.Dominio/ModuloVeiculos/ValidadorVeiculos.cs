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
                    .Matches(@"^[a-zA-Zà-úÀ-ÚçÇ ]+$");
           
            RuleFor(x => x.Marca)
                    .NotNull().NotEmpty()
                    .MinimumLength(2)
                    .Matches(@"^[a-zA-Zà-úÀ-ÚçÇ ]+$");
           
            RuleFor(x => x.Placa)
                    .NotNull().NotEmpty()
                    .MinimumLength(7)
                    .Matches(@"^[a-zA-Zà-úÀ-ÚçÇ ]+$");

            RuleFor(x => x.Cor)
                    .NotNull().NotEmpty()
                    .MinimumLength(3)
                    .Matches(@"^[a-zA-Zà-úÀ-ÚçÇ ]+$");

            RuleFor(x => x.Ano)
                    .NotNull().NotEmpty();

            RuleFor(x => x.QuilometroPercorrido)
                    .NotNull().NotEmpty();

            RuleFor(x => x.TipoCombustivel)
                    .NotNull().NotEmpty();

            RuleFor(x => x.CapacidadeTanque)
                    .NotNull().NotEmpty();

            RuleFor(x => x.GrupoVeiculos_Id)
                    .NotNull().NotEmpty();

            //RuleFor(x => x.Foto)
            //        .NotNull().NotEmpty();

            //Pode ocorrer de não haver uma boa foto no momento de cadastro e o operator preferir deixar para cadastrar dps...

        }
    }
}
