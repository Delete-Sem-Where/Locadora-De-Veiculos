using FluentValidation;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloPessoaJuridica
{
    public class ValidadorPessoaJuridica : AbstractValidator<PessoaJuridica>
    {
        public ValidadorPessoaJuridica()
        {
            RuleFor(x => x.Nome)
                .NotNull().NotEmpty()
                .RegrasNomes();

            RuleFor(x => x.Email)
                .NotNull().NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Telefone)
                .Telefone();

            RuleFor(x => x.Endereco)
                .NotNull().NotEmpty();

            RuleFor(x => x.CNPJ)
                .NotNull().NotEmpty()
                .MinimumLength(14);
        }
    }
}
