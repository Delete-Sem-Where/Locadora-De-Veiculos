using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloFuncionario
{
    public class ValidadorFuncionario : AbstractValidator<Funcionario>
    {
        public ValidadorFuncionario()
        {
            RuleFor(x => x.Nome)
                .NotNull().NotEmpty()
                .MinimumLength(2);

            RuleFor(x => x.Email)
                .NotNull().NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Telefone)
                .NotNull().NotEmpty();

            RuleFor(x => x.Endereco)
                .NotNull().NotEmpty();

            RuleFor(x => x.Login)
                .NotNull().NotEmpty();

            RuleFor(x => x.Senha)
                .NotNull().NotEmpty();

            RuleFor(x => x.DataDeAdmissao)
                .NotEqual(DateTime.MinValue);

            RuleFor(x => x.Salario)
                .GreaterThan(0);
        }
    }
}
