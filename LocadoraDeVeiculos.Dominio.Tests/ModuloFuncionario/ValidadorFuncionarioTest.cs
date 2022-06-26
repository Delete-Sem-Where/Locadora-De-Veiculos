using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloFuncionario
{
    [TestClass]
    public class ValidadorFuncionarioTest
    {
        private readonly Funcionario funcionario;
        private readonly ValidadorFuncionario validador;

        public ValidadorFuncionarioTest()
        {
            funcionario = new()
            {
                Nome = "nome",
                Email = "email@gmail.com",
                Telefone = "(11)1234-5678",
                Endereco = "endereco",
                Login = "login",
                Senha = "senha",
                Salario = 1000,
                DataDeAdmissao = DateTime.Now
            };

            validador = new ValidadorFuncionario();
        }

        [TestMethod]
        public void Nome_deve_ser_obrigatorio()
        {
            funcionario.Nome = null;

            var resultado = validador.TestValidate(funcionario);

            resultado.ShouldHaveValidationErrorFor(funcionario => funcionario.Nome);
        }

        [TestMethod]
        public void Nome_deve_ser_valido()
        {
            funcionario.Nome = "asdads123adas";

            var resultado = validador.TestValidate(funcionario);

            resultado.ShouldHaveValidationErrorFor(funcionario => funcionario.Nome);
        }

        [TestMethod]
        public void Nome_deve_ter_pelo_menos_2_caracteres()
        {
            funcionario.Nome = "a";

            var resultado = validador.TestValidate(funcionario);

            resultado.ShouldHaveValidationErrorFor(funcionario => funcionario.Nome);
        }

        [TestMethod]
        public void Email_deve_ser_obrigatorio()
        {
            funcionario.Email = null;

            var resultado = validador.TestValidate(funcionario);

            resultado.ShouldHaveValidationErrorFor(funcionario => funcionario.Email);
        }

        [TestMethod]
        public void Email_deve_ser_valido()
        {
            funcionario.Email = "email";

            var resultado = validador.TestValidate(funcionario);

            resultado.ShouldHaveValidationErrorFor(funcionario => funcionario.Email);
        }

        [TestMethod]
        public void Telefone_deve_ser_obrigatorio()
        {
            funcionario.Telefone = null;

            var resultado = validador.TestValidate(funcionario);

            resultado.ShouldHaveValidationErrorFor(funcionario => funcionario.Telefone);
        }

        [TestMethod]
        public void Telefone_deve_ser_valido()
        {
            funcionario.Telefone = "5456asad";

            var resultado = validador.TestValidate(funcionario);

            resultado.ShouldHaveValidationErrorFor(funcionario => funcionario.Telefone);
        }

        [TestMethod]
        public void Endereco_deve_ser_obrigatorio()
        {
            funcionario.Endereco = null;

            var resultado = validador.TestValidate(funcionario);

            resultado.ShouldHaveValidationErrorFor(funcionario => funcionario.Endereco);
        }

        [TestMethod]
        public void Endereco_deve_ser_valido()
        {
            funcionario.Endereco = "asdad1215615 %%asdadsa";

            var resultado = validador.TestValidate(funcionario);

            resultado.ShouldHaveValidationErrorFor(funcionario => funcionario.Endereco);
        }

        [TestMethod]
        public void Endereco_deve_ter_pelo_menos_2_caracteres()
        {
            funcionario.Endereco = "a";

            var resultado = validador.TestValidate(funcionario);

            resultado.ShouldHaveValidationErrorFor(funcionario => funcionario.Endereco);
        }

        [TestMethod]
        public void Login_deve_ser_obrigatorio()
        {
            funcionario.Login = null;

            var resultado = validador.TestValidate(funcionario);

            resultado.ShouldHaveValidationErrorFor(funcionario => funcionario.Login);
        }

        [TestMethod]
        public void Senha_deve_ser_obrigatoria()
        {
            funcionario.Senha = null;

            var resultado = validador.TestValidate(funcionario);

            resultado.ShouldHaveValidationErrorFor(funcionario => funcionario.Senha);
        }

        [TestMethod]
        public void Salario_deve_ser_valido()
        {
            funcionario.Salario = -1;

            var resultado = validador.TestValidate(funcionario);

            resultado.ShouldHaveValidationErrorFor(funcionario => funcionario.Salario);
        }

        [TestMethod]
        public void Data_de_admissao_deve_ser_valida()
        {
            funcionario.DataDeAdmissao = DateTime.MinValue;

            var resultado = validador.TestValidate(funcionario);

            resultado.ShouldHaveValidationErrorFor(funcionario => funcionario.DataDeAdmissao);
        }
    }
}
