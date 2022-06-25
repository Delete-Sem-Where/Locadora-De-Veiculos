using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloPessoaJuridica;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloPessoaJuridica;
using LocadoraDeVeiculos.Infra.BancoDados.Test.Compartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDados.Test.ModuloPessoaJuridica
{
    [TestClass]
    public class RepositorioPessoaJuridicaEmBancoDadosTest : IntegrationTestBase
    {
        private RepositorioPessoaJuridicaEmBancoDados repositorio;

        public RepositorioPessoaJuridicaEmBancoDadosTest()
        {
            repositorio = new RepositorioPessoaJuridicaEmBancoDados();
        }

        [TestMethod]
        public void Deve_inserir_pessoa_juridica()
        {
            var pessoaJuridica = NovaPessoaJuridica();

            repositorio.Inserir(pessoaJuridica);

            var pessoaJuridicaEncontrada = repositorio.SelecionarPorId(pessoaJuridica.Id);

            pessoaJuridicaEncontrada.Should().NotBeNull();
            pessoaJuridicaEncontrada.Should().Be(pessoaJuridica);
        }

        [TestMethod]
        public void Deve_editar_informacoes_pessoa_juridica()
        {
            var pessoaJuridica = NovaPessoaJuridica();

            repositorio.Inserir(pessoaJuridica);

            pessoaJuridica.Nome = "nome alterado";
            repositorio.Editar(pessoaJuridica);

            var pessoaJuridicaEncontrada = repositorio.SelecionarPorId(pessoaJuridica.Id);

            pessoaJuridicaEncontrada.Should().NotBeNull();
            pessoaJuridicaEncontrada.Should().Be(pessoaJuridica);
        }

        [TestMethod]
        public void Deve_excluir_funcionario()
        {
            var pessoaJuridica = NovaPessoaJuridica();

            repositorio.Inserir(pessoaJuridica);

            repositorio.Excluir(pessoaJuridica);

            repositorio.SelecionarPorId(pessoaJuridica.Id)
                .Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_pessoa_juridica_por_id()
        {
            var pessoaJuridica = NovaPessoaJuridica();

            repositorio.Inserir(pessoaJuridica);

            var pessoaJuridicaEncontrada = repositorio.SelecionarPorId(pessoaJuridica.Id);

            pessoaJuridicaEncontrada.Should().NotBeNull();
            pessoaJuridicaEncontrada.Should().Be(pessoaJuridica);
        }

        [TestMethod]
        public void Deve_selecionar_todas_pessoas_juridicas()
        {
            var pj1 = new PessoaJuridica()
            {
                Nome = "nome um",
                Email = "email1@gmail.com",
                Telefone = "(13)1656-1235",
                Endereco = "endereco 1",
                CNPJ = "12345678912345"
            };

            repositorio.Inserir(pj1);

            var pj2 = new PessoaJuridica()
            {
                Nome = "nome dois",
                Email = "email2@gmail.com",
                Telefone = "(13)1656-1235",
                Endereco = "endereco 2",
                CNPJ = "12345678912346"
            };

            repositorio.Inserir(pj2);

            var pj3 = new PessoaJuridica()
            {
                Nome = "nome tres",
                Email = "email3@gmail.com",
                Telefone = "(13)1656-1235",
                Endereco = "endereco 3",
                CNPJ = "12345678912347"
            };

            repositorio.Inserir(pj3);

            var pessoasJuridicas = repositorio.SelecionarTodos();

            pessoasJuridicas.Count.Should().Be(3);

            pessoasJuridicas[0].Should().Be(pj1);
            pessoasJuridicas[1].Should().Be(pj2);
            pessoasJuridicas[2].Should().Be(pj3);
        }

        private PessoaJuridica NovaPessoaJuridica()
        {
            return new PessoaJuridica()
            {
                Nome = "nome",
                Email = "email@gmail.com",
                Telefone = "(13)1656-1235",
                Endereco = "endereco",
                CNPJ = "12345678912345"
            };
        }

    }
}
