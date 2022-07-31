using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloLocacao
{
    [TestClass]
    public class ValidadorLocacaoTest
    {
        private readonly Locacao locacao;
        private readonly ValidadorLocacao validador;

        public ValidadorLocacaoTest()
        {
            locacao = new()
            {
                DataLocacao = DateTime.Now,
                DataDevolucaoPrevista = DateTime.Now.AddDays(1),
                ValorTotalPrevisto = 1000
            };

            validador = new ValidadorLocacao();
        }

        [TestMethod]
        public void Data_Locacao_deve_ser_valida()
        {
            locacao.DataLocacao = DateTime.MinValue;

            var resultado = validador.TestValidate(locacao);

            resultado.ShouldHaveValidationErrorFor(locacao => locacao.DataLocacao);
        }

        [TestMethod]
        public void Data_Devolucao_Prevista_deve_ser_valida()
        {
            locacao.DataDevolucaoPrevista = DateTime.MinValue;

            var resultado = validador.TestValidate(locacao);

            resultado.ShouldHaveValidationErrorFor(locacao => locacao.DataDevolucaoPrevista);
        }

        [TestMethod]
        public void Valor_total_previsto_deve_ser_maior_que_0()
        {
            locacao.ValorTotalPrevisto = -1;

            var resultado = validador.TestValidate(locacao);

            resultado.ShouldHaveValidationErrorFor(locacao => locacao.ValorTotalPrevisto);
        }
    }
}
