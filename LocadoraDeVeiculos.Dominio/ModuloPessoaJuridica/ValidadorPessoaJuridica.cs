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

            RuleFor(x => x.CNPJ)
                .NotNull().NotEmpty()
                .CNPJ();
        }
    }
}
