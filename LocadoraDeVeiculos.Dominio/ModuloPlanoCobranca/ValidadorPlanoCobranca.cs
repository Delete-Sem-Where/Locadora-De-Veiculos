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
            //RuleFor(x => x.Nome)
            //    .NotNull().NotEmpty()
            //    .Nomes();

            //RuleFor(x => x.Email)
            //    .NotNull().NotEmpty()
            //    .EmailAddress();

            //RuleFor(x => x.Telefone)
            //    .NotNull().NotEmpty()
            //    .Telefone();

            //RuleFor(x => x.Endereco)
            //    .NotNull().NotEmpty()
            //    .Endereco();

            //When(x => x.TipoPlanoCobranca == TipoPlanoCobranca.PessoaJuridica, () =>
            //{
            //    RuleFor(x => x.CNPJ)
            //    .NotNull().NotEmpty()
            //    .CNPJ();

            //});

            //When(x => x.TipoPlanoCobranca == TipoPlanoCobranca.PessoaFisica, () =>
            //{
            //    RuleFor(x => x.CPF)
            //    .NotNull().NotEmpty()
            //    .CPF();
            //});
        }
    }
}
