using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloPessoaFisica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloPessoaFisica
{
    [TestClass]
    public class ValidadorPessoaFisicaTest
    {
        private readonly PessoaFisica pessoaFisica;
        private readonly ValidadorPessoaFisica validador;

        public ValidadorPessoaFisicaTest()
        {
            pessoaFisica = new()
            {
                Nome = "nome",
                Email = "email@gmail.com",
                Telefone = "(11)1234-5678",
                Endereco = "endereco",
                CPF = "12345678912",
                CNH = "12345678912",
            };

            validador = new ValidadorPessoaFisica();
        }

        [TestMethod]
        public void Nome_deve_ser_obrigatorio()
        {
            pessoaFisica.Nome = null;

            var resultado = validador.TestValidate(pessoaFisica);

            resultado.ShouldHaveValidationErrorFor(pessoaFisica => pessoaFisica.Nome);
        }

        [TestMethod]
        public void Nome_deve_ser_valido()
        {
            pessoaFisica.Nome = "asdads123adas";

            var resultado = validador.TestValidate(pessoaFisica);

            resultado.ShouldHaveValidationErrorFor(pessoaFisica => pessoaFisica.Nome);
        }

        [TestMethod]
        public void Nome_deve_ter_pelo_menos_2_caracteres()
        {
            pessoaFisica.Nome = "a";

            var resultado = validador.TestValidate(pessoaFisica);

            resultado.ShouldHaveValidationErrorFor(pessoaFisica => pessoaFisica.Nome);
        }

        [TestMethod]
        public void Email_deve_ser_obrigatorio()
        {
            pessoaFisica.Email = null;

            var resultado = validador.TestValidate(pessoaFisica);

            resultado.ShouldHaveValidationErrorFor(pessoaFisica => pessoaFisica.Email);
        }

        [TestMethod]
        public void Email_deve_ser_valido()
        {
            pessoaFisica.Email = "email";

            var resultado = validador.TestValidate(pessoaFisica);

            resultado.ShouldHaveValidationErrorFor(pessoaFisica => pessoaFisica.Email);
        }

        [TestMethod]
        public void Telefone_deve_ser_obrigatorio()
        {
            pessoaFisica.Telefone = null;

            var resultado = validador.TestValidate(pessoaFisica);

            resultado.ShouldHaveValidationErrorFor(pessoaFisica => pessoaFisica.Telefone);
        }

        [TestMethod]
        public void Telefone_deve_ser_valido()
        {
            pessoaFisica.Telefone = "13212312312";

            var resultado = validador.TestValidate(pessoaFisica);

            resultado.ShouldHaveValidationErrorFor(pessoaFisica => pessoaFisica.Telefone);
        }

        [TestMethod]
        public void Endereco_deve_ser_obrigatorio()
        {
            pessoaFisica.Endereco = null;

            var resultado = validador.TestValidate(pessoaFisica);

            resultado.ShouldHaveValidationErrorFor(pessoaFisica => pessoaFisica.Endereco);
        }

        [TestMethod]
        public void Endereco_deve_ser_valido()
        {
            pessoaFisica.Endereco = "asdad1215615 %%asdadsa";

            var resultado = validador.TestValidate(pessoaFisica);

            resultado.ShouldHaveValidationErrorFor(pessoaFisica => pessoaFisica.Endereco);
        }

        [TestMethod]
        public void CPF_deve_ser_obrigatorio()
        {
            pessoaFisica.CPF = null;

            var resultado = validador.TestValidate(pessoaFisica);

            resultado.ShouldHaveValidationErrorFor(pessoaFisica => pessoaFisica.CPF);
        }

        [TestMethod]
        public void CPF_deve_ser_valido()
        {
            pessoaFisica.CPF = "123456";

            var resultado = validador.TestValidate(pessoaFisica);

            resultado.ShouldHaveValidationErrorFor(pessoaFisica => pessoaFisica.CPF);
        }

        [TestMethod]
        public void CNH_deve_ser_obrigatorio()
        {
            pessoaFisica.CNH = null;

            var resultado = validador.TestValidate(pessoaFisica);

            resultado.ShouldHaveValidationErrorFor(pessoaFisica => pessoaFisica.CNH);
        }

        [TestMethod]
        public void CNH_deve_ter_tamanho_valido()
        {
            pessoaFisica.CNH = "123456";

            var resultado = validador.TestValidate(pessoaFisica);

            resultado.ShouldHaveValidationErrorFor(pessoaFisica => pessoaFisica.CNH);
        }
    }
}
