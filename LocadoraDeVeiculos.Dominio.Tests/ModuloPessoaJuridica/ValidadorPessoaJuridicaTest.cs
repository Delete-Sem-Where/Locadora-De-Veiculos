using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloPessoaJuridica;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloPessoaJuridica
{
    [TestClass]
    public class ValidadorPessoaJuridicaTest
    {
        private readonly PessoaJuridica pessoaJuridica;
        private readonly ValidadorPessoaJuridica validador;

        public ValidadorPessoaJuridicaTest()
        {
            pessoaJuridica = new()
            {
                Nome = "nome",
                Email = "email@gmail.com",
                Telefone = "(11)1234-5678",
                Endereco = "endereco",
                CNPJ = "12345678912345",
            };

            validador = new ValidadorPessoaJuridica();
        }

        [TestMethod]
        public void Nome_deve_ser_obrigatorio()
        {
            pessoaJuridica.Nome = null;

            var resultado = validador.TestValidate(pessoaJuridica);

            resultado.ShouldHaveValidationErrorFor(pessoaJuridica => pessoaJuridica.Nome);
        }

        [TestMethod]
        public void Nome_deve_ser_valido()
        {
            pessoaJuridica.Nome = "asdads123adas";

            var resultado = validador.TestValidate(pessoaJuridica);

            resultado.ShouldHaveValidationErrorFor(pessoaJuridica => pessoaJuridica.Nome);
        }

        [TestMethod]
        public void Nome_deve_ter_pelo_menos_2_caracteres()
        {
            pessoaJuridica.Nome = "a";

            var resultado = validador.TestValidate(pessoaJuridica);

            resultado.ShouldHaveValidationErrorFor(pessoaJuridica => pessoaJuridica.Nome);
        }

        [TestMethod]
        public void Email_deve_ser_obrigatorio()
        {
            pessoaJuridica.Email = null;

            var resultado = validador.TestValidate(pessoaJuridica);

            resultado.ShouldHaveValidationErrorFor(pessoaJuridica => pessoaJuridica.Email);
        }

        [TestMethod]
        public void Email_deve_ser_valido()
        {
            pessoaJuridica.Email = "email";

            var resultado = validador.TestValidate(pessoaJuridica);

            resultado.ShouldHaveValidationErrorFor(pessoaJuridica => pessoaJuridica.Email);
        }

        [TestMethod]
        public void Telefone_deve_ser_obrigatorio()
        {
            pessoaJuridica.Telefone = null;

            var resultado = validador.TestValidate(pessoaJuridica);

            resultado.ShouldHaveValidationErrorFor(pessoaJuridica => pessoaJuridica.Telefone);
        }

        [TestMethod]
        public void Telefone_deve_ser_valido()
        {
            pessoaJuridica.Telefone = "13212312312";

            var resultado = validador.TestValidate(pessoaJuridica);

            resultado.ShouldHaveValidationErrorFor(pessoaJuridica => pessoaJuridica.Telefone);
        }

        [TestMethod]
        public void Endereco_deve_ser_obrigatorio()
        {
            pessoaJuridica.Endereco = null;

            var resultado = validador.TestValidate(pessoaJuridica);

            resultado.ShouldHaveValidationErrorFor(pessoaJuridica => pessoaJuridica.Endereco);
        }

        [TestMethod]
        public void Endereco_deve_ser_valido()
        {
            pessoaJuridica.Endereco = "asdad1215615 %%asdadsa";

            var resultado = validador.TestValidate(pessoaJuridica);

            resultado.ShouldHaveValidationErrorFor(pessoaJuridica => pessoaJuridica.Endereco);
        }

        [TestMethod]
        public void CNPJ_deve_ser_obrigatorio()
        {
            pessoaJuridica.CNPJ = null;

            var resultado = validador.TestValidate(pessoaJuridica);

            resultado.ShouldHaveValidationErrorFor(pessoaJuridica => pessoaJuridica.CNPJ);
        }

        [TestMethod]
        public void CNPJ_deve_ser_valido()
        {
            pessoaJuridica.CNPJ = "123456";

            var resultado = validador.TestValidate(pessoaJuridica);

            resultado.ShouldHaveValidationErrorFor(pessoaJuridica => pessoaJuridica.CNPJ);
        }

    }
}
