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
                .Nomes();

            RuleFor(x => x.Email)
                .NotNull().NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Telefone)
                .NotNull().NotEmpty()
                .Telefone();

            RuleFor(x => x.Endereco)
                .NotNull().NotEmpty()
                .Endereco();

            RuleFor(x => x.CPF)
                .NotNull().NotEmpty()
                .CPF();

            RuleFor(x => x.CNH)
                .NotNull().NotEmpty()
                .MinimumLength(11);
        }
    }
}
