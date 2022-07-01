using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloCondutor
{
    [TestClass]
    public class ValidadorCondutorTest
    {
        private readonly Condutor condutor;
        private readonly ValidadorCondutor validador;

        public ValidadorCondutorTest()
        {
            condutor = new()
            {
                Nome = "nome",
                Email = "email@gmail.com",
                Telefone = "(13)1656-1235",
                Endereco = "endereco",
                CPF = "123.123.123-12",
                CNH = "12345678912",
                ValidadeCNH = DateTime.Now
            };

            validador = new ValidadorCondutor();
        }

        [TestMethod]
        public void Nome_deve_ser_obrigatorio()
        {
            condutor.Nome = null;

            var resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Nome);
        }

        [TestMethod]
        public void Nome_deve_ser_valido()
        {
            condutor.Nome = "asdads123adas";

            var resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Nome);
        }

        [TestMethod]
        public void Nome_deve_ter_pelo_menos_2_caracteres()
        {
            condutor.Nome = "a";

            var resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Nome);
        }

        [TestMethod]
        public void Email_deve_ser_obrigatorio()
        {
            condutor.Email = null;

            var resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Email);
        }

        [TestMethod]
        public void Email_deve_ser_valido()
        {
            condutor.Email = "email";

            var resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Email);
        }

        [TestMethod]
        public void Telefone_deve_ser_obrigatorio()
        {
            condutor.Telefone = null;

            var resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Telefone);
        }

        [TestMethod]
        public void Telefone_deve_ser_valido()
        {
            condutor.Telefone = "13212312312";

            var resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Telefone);
        }

        [TestMethod]
        public void Endereco_deve_ser_obrigatorio()
        {
            condutor.Endereco = null;

            var resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Endereco);
        }

        [TestMethod]
        public void Endereco_deve_ser_valido()
        {
            condutor.Endereco = "asdad1215615 %%asdadsa";

            var resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(condutor => condutor.Endereco);
        }

        [TestMethod]
        public void CPF_deve_ser_obrigatorio()
        {
            condutor.CPF = null;

            var resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(condutor => condutor.CPF);
        }

        [TestMethod]
        public void CPF_deve_ser_valido()
        {
            condutor.CPF = "123456";

            var resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(condutor => condutor.CPF);
        }

        [TestMethod]
        public void CNH_deve_ser_obrigatorio()
        {
            condutor.CNH = null;

            var resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(condutor => condutor.CNH);
        }

        [TestMethod]
        public void CNH_deve_ter_tamanho_valido()
        {
            condutor.CNH = "123456";

            var resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(condutor => condutor.CNH);
        }

        [TestMethod]
        public void ValidadeCNH_deve_ser_valida()
        {
            condutor.ValidadeCNH = DateTime.MinValue;

            var resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(condutor => condutor.ValidadeCNH);
        }
    }
}
