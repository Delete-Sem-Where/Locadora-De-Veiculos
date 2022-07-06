using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloPlanoCobranca
{
    [TestClass]
    public class ValidadorPlanoCobrancaTest
    {
            private readonly PlanoCobranca planoCobranca;
            private readonly ValidadorPlanoCobranca validador;

        public ValidadorPlanoCobrancaTest()
        {
            planoCobranca = new()
            {
                GrupoVeiculos = new()
                {
                    Nome = "SUV",
                },
                
                ModalidadePlanoCobranca = ModalidadePlanoCobranca.Controle,
                ValorDiaria = 100,
                ValorKm = 11,
                LimiteKm = 10
            };

            validador = new ValidadorPlanoCobranca();
        }

        [TestMethod]
        public void GrupoVeiculos_Nao_Pode_Ser_Nulo()
        {
            // arrange
            planoCobranca.GrupoVeiculos = null;

            // action
            var resultado = validador.TestValidate(planoCobranca);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.GrupoVeiculos);
        }
             
        [TestMethod]
        public void ValorDiaria_Deve_Ser_Maior_Que_0()
        {
            // arrange
            planoCobranca.ValorDiaria = 0;

            // action
            var resultado = validador.TestValidate(planoCobranca);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.ValorDiaria);
        }

        [TestMethod]
        public void ValorKm_Deve_Ser_Maior_Que_0()
        {
            // arrange
            planoCobranca.ValorKm = 0;

            // action
            var resultado = validador.TestValidate(planoCobranca);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.ValorKm);
        }

        [TestMethod]
        public void LimiteKm_Deve_Ser_Maior_Que_0()
        {
            // arrange
            planoCobranca.LimiteKm = 0;

            // action
            var resultado = validador.TestValidate(planoCobranca);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.LimiteKm);
        }
    }
}
