using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Compartilhado
{
    public static class RuleBuilderExtensions
    {
        /// <typeparam name="T"></typeparam>
        /// <param name="ruleBuilder"></param>
        /// <returns></returns>
        public static IRuleBuilder<T, string> Nomes<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                .MinimumLength(2)
                .Matches(@"^[a-zA-Zà-úÀ-ÚçÇ ]+$");

            return options;
        }

        public static IRuleBuilder<T, string> Endereco<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                .MinimumLength(2)
                .Matches(@"^[a-zA-Zà-úÀ-ÚçÇ0-9 ]+$");

            return options;
        }

        public static IRuleBuilder<T, string> Telefone<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                .Matches(@"(\(?\d{2}\)?\s)?(\d{4,5}\-\d{4})");

            return options;
        }
    }
}
