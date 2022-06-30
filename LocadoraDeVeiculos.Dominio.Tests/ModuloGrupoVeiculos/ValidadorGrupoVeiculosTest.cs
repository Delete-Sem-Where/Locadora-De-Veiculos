using FluentAssertions;
using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloGrupoVeiculos
{
    [TestClass]
    public class ValidadorGrupoVeiculosTest
    {
        private readonly GrupoVeiculos grupoVeiculos;
        private readonly ValidadorGrupoVeiculos validadorGrupoVeiculos;

        public ValidadorGrupoVeiculosTest()
        {
            grupoVeiculos = new()
            {
                Nome = "Nome Teste"
            };

            validadorGrupoVeiculos = new ValidadorGrupoVeiculos();
        }

        [TestMethod]
        public void Nome_deve_ser_obrigatorio()
        {
            grupoVeiculos.Nome = null;
            var res = validadorGrupoVeiculos.TestValidate(grupoVeiculos);
            res.ShouldHaveValidationErrorFor(grupoVeiculos => grupoVeiculos.Nome);
        }

        [TestMethod]
        public void Nome_deve_ser_valido()
        {
            grupoVeiculos.Nome = "Sdad15ew";

            var res = validadorGrupoVeiculos.TestValidate(grupoVeiculos);

            res.ShouldHaveValidationErrorFor(grupoVeiculos => grupoVeiculos.Nome);
        }

        [TestMethod]
        public void Nome_nao_deve_inserir_menos_de_2_caracteres()
        {
            grupoVeiculos.Nome = "g";
            var res = validadorGrupoVeiculos.TestValidate(grupoVeiculos);
            res.ShouldHaveValidationErrorFor(grupoVeiculos => grupoVeiculos.Nome);
        }
    }  
}
