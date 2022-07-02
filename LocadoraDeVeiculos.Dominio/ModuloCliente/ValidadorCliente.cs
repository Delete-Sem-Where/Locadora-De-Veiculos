using FluentValidation;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public class ValidadorCliente : AbstractValidator<Cliente>
    {
        public ValidadorCliente()
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

            When(x => x.TipoCliente == TipoCliente.PessoaJuridica, () =>
            {
                RuleFor(x => x.CNPJ)
                .NotNull().NotEmpty()
                .CNPJ();

            });

            When(x => x.TipoCliente == TipoCliente.PessoaFisica, () =>
            {
                RuleFor(x => x.CPF)
                .NotNull().NotEmpty()
                .CPF();
            });
        }
    }
}
