using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloPessoaFisica;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloPessoaFisica;
using LocadoraDeVeiculos.Infra.BancoDados.Test.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDados.Test.ModuloPessoaFisica
{
    [TestClass]
    public class RepositorioPessoaFisicaEmBancoDadosTest : IntegrationTestBase
    {
        private RepositorioPessoaFisicaEmBancoDados repositorio;

        public RepositorioPessoaFisicaEmBancoDadosTest()
        {
            repositorio = new RepositorioPessoaFisicaEmBancoDados();
        }

        [TestMethod]
        public void Deve_inserir_pessoa_fisica()
        {
            var pessoaFisica = NovaPessoaFisica();

            repositorio.Inserir(pessoaFisica);

            var pessoaFisicaEncontrada = repositorio.SelecionarPorId(pessoaFisica.Id);

            pessoaFisicaEncontrada.Should().NotBeNull();
            pessoaFisicaEncontrada.Should().Be(pessoaFisica);
        }

        [TestMethod]
        public void Deve_editar_informacoes_pessoa_fisica()
        {
            var pessoaFisica = NovaPessoaFisica();

            repositorio.Inserir(pessoaFisica);

            pessoaFisica.Nome = "nome alterado";
            repositorio.Editar(pessoaFisica);

            var pessoaFisicaEncontrada = repositorio.SelecionarPorId(pessoaFisica.Id);

            pessoaFisicaEncontrada.Should().NotBeNull();
            pessoaFisicaEncontrada.Should().Be(pessoaFisica);
        }

        [TestMethod]
        public void Deve_excluir_funcionario()
        {
            var pessoaFisica = NovaPessoaFisica();

            repositorio.Inserir(pessoaFisica);

            repositorio.Excluir(pessoaFisica);

            repositorio.SelecionarPorId(pessoaFisica.Id)
                .Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_pessoa_fisica_por_id()
        {
            var pessoaFisica = NovaPessoaFisica();

            repositorio.Inserir(pessoaFisica);

            var pessoaFisicaEncontrada = repositorio.SelecionarPorId(pessoaFisica.Id);

            pessoaFisicaEncontrada.Should().NotBeNull();
            pessoaFisicaEncontrada.Should().Be(pessoaFisica);
        }

        [TestMethod]
        public void Deve_selecionar_todas_pessoas_fisicas()
        {
            var pj1 = new PessoaFisica()
            {
                Nome = "nome um",
                Email = "email1@gmail.com",
                Telefone = "(13)1656-1235",
                Endereco = "endereco 1",
                CPF = "123.123.123-11",
                CNH = "12345678912",
            };

            repositorio.Inserir(pj1);

            var pj2 = new PessoaFisica()
            {
                Nome = "nome dois",
                Email = "email2@gmail.com",
                Telefone = "(13)1656-1235",
                Endereco = "endereco 2",
                CPF = "123.123.123-12",
                CNH = "12345678912",
            };

            repositorio.Inserir(pj2);

            var pj3 = new PessoaFisica()
            {
                Nome = "nome tres",
                Email = "email3@gmail.com",
                Telefone = "(13)1656-1235",
                Endereco = "endereco 3",
                CPF = "123.123.123-13",
                CNH = "12345678912",
            };

            repositorio.Inserir(pj3);

            var pessoasFisicas = repositorio.SelecionarTodos();

            pessoasFisicas.Count.Should().Be(3);

            pessoasFisicas[0].Should().Be(pj1);
            pessoasFisicas[1].Should().Be(pj2);
            pessoasFisicas[2].Should().Be(pj3);
        }

        private PessoaFisica NovaPessoaFisica()
        {
            return new PessoaFisica()
            {
                Nome = "nome",
                Email = "email@gmail.com",
                Telefone = "(13)1656-1235",
                Endereco = "endereco",
                CPF = "123.123.123-12",
                CNH = "12345678912",
            };
        }

    }
}
