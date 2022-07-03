using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloCliente
{
    [TestClass]
    public class ValidadorClienteTest
    {
        private readonly Cliente cliente;
        private readonly ValidadorCliente validador;

        public ValidadorClienteTest()
        {
            cliente = new Cliente()
            {
                Nome = "nome",
                Email = "email@gmail.com",
                Telefone = "(11)1234-5678",
                Endereco = "endereco"
            };

            validador = new ValidadorCliente();
        }

        [TestMethod]
        public void Nome_deve_ser_obrigatorio()
        {
            cliente.Nome = null;

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Nome);
        }

        [TestMethod]
        public void Nome_deve_ser_valido()
        {
            cliente.Nome = "asdads123adas";

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Nome);
        }

        [TestMethod]
        public void Nome_deve_ter_pelo_menos_2_caracteres()
        {
            cliente.Nome = "a";

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Nome);
        }

        [TestMethod]
        public void Email_deve_ser_obrigatorio()
        {
            cliente.Email = null;

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Email);
        }

        [TestMethod]
        public void Email_deve_ser_valido()
        {
            cliente.Email = "email";

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Email);
        }

        [TestMethod]
        public void Telefone_deve_ser_obrigatorio()
        {
            cliente.Telefone = null;

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Telefone);
        }

        [TestMethod]
        public void Telefone_deve_ser_valido()
        {
            cliente.Telefone = "13212312312";

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Telefone);
        }

        [TestMethod]
        public void Endereco_deve_ser_obrigatorio()
        {
            cliente.Endereco = null;

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Endereco);
        }

        [TestMethod]
        public void Endereco_deve_ser_valido()
        {
            cliente.Endereco = "asdad1215615 %%asdadsa";

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.Endereco);
        }

        [TestMethod]
        public void CPF_deve_ser_obrigatorio()
        {
            cliente.TipoCliente = TipoCliente.PessoaFisica;
            cliente.CPF = null;

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.CPF);
        }

        [TestMethod]
        public void CPF_deve_ser_valido()
        {
            cliente.TipoCliente = TipoCliente.PessoaFisica;
            cliente.CPF = "123456";

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.CPF);
        }

        [TestMethod]
        public void CNPJ_deve_ser_obrigatorio()
        {
            cliente.TipoCliente = TipoCliente.PessoaJuridica;
            cliente.CNPJ = null;

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.CNPJ);
        }

        [TestMethod]
        public void CNPJ_deve_ser_valido()
        {
            cliente.TipoCliente = TipoCliente.PessoaJuridica;
            cliente.CNPJ = "123456";

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(cliente => cliente.CNPJ);
        }
    }
}
