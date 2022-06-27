using FluentValidation;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloPessoaFisica
{
    public class ValidadorPessoaFisica : AbstractValidator<PessoaFisica>
    {
        public ValidadorPessoaFisica()
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
                .NotNull().NotEmpty()
                .RegrasNomes();

            RuleFor(x => x.CPF)
                .NotNull().NotEmpty();

            RuleFor(x => x.CNH)
                .NotNull().NotEmpty();
        }
    }
}
