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
                .Matches(@"^[a-zA-Z ]+$");

            return options;
        }               
    }
}