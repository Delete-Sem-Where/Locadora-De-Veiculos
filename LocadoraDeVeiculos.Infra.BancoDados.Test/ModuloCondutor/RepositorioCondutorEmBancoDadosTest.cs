using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloCondutor;
using LocadoraDeVeiculos.Infra.BancoDados.Test.Compartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDados.Test.ModuloCondutor
{
    [TestClass]
    public class RepositorioCondutorEmBancoDadosTest : IntegrationTestBase
    {
        private RepositorioCondutorEmBancoDados repositorio;

        public RepositorioCondutorEmBancoDadosTest()
        {
            repositorio = new RepositorioCondutorEmBancoDados();
        }

        [TestMethod]
        public void Deve_inserir_condutor()
        {
            var condutor = NovoCondutor();

            repositorio.Inserir(condutor);

            var condutorEncontrado = repositorio.SelecionarPorId(condutor.Id);

            condutorEncontrado.Should().NotBeNull();
            condutorEncontrado.Should().Be(condutor);
        }

        [TestMethod]
        public void Deve_editar_informacoes_condutor()
        {
            var condutor = NovoCondutor();

            repositorio.Inserir(condutor);

            condutor.Nome = "nome alterado";
            repositorio.Editar(condutor);

            var condutorEncontrado = repositorio.SelecionarPorId(condutor.Id);

            condutorEncontrado.Should().NotBeNull();
            condutorEncontrado.Should().Be(condutor);
        }

        [TestMethod]
        public void Deve_excluir_condutor()
        {
            var condutor = NovoCondutor();

            repositorio.Inserir(condutor);

            repositorio.Excluir(condutor);

            repositorio.SelecionarPorId(condutor.Id)
                .Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_condutor_por_id()
        {
            var condutor = NovoCondutor();

            repositorio.Inserir(condutor);

            var condutorEncontrado = repositorio.SelecionarPorId(condutor.Id);

            condutorEncontrado.Should().NotBeNull();
            condutorEncontrado.Should().Be(condutor);
        }

        [TestMethod]
        public void Deve_selecionar_todos_condutores()
        {
            var c1 = new Condutor()
            {
                Nome = "nome um",
                Email = "email@gmail.com",
                Telefone = "(13)1656-1235",
                Endereco = "endereco",
                CPF = "123.123.123-11",
                CNH = "12345678912",
                ValidadeCNH = DateTime.Now
            };

            repositorio.Inserir(c1);

            var c2 = new Condutor()
            {
                Nome = "nome dois",
                Email = "email@gmail.com",
                Telefone = "(13)1656-1235",
                Endereco = "endereco",
                CPF = "123.123.123-12",
                CNH = "12345678912",
                ValidadeCNH = DateTime.Now
            };

            repositorio.Inserir(c2);

            var c3 = new Condutor()
            {
                Nome = "nome tres",
                Email = "email@gmail.com",
                Telefone = "(13)1656-1235",
                Endereco = "endereco",
                CPF = "123.123.123-13",
                CNH = "12345678912",
                ValidadeCNH = DateTime.Now
            };

            repositorio.Inserir(c3);

            var condutores = repositorio.SelecionarTodos();

            condutores.Count.Should().Be(3);

            condutores[0].Should().Be(c1);
            condutores[1].Should().Be(c2);
            condutores[2].Should().Be(c3);
        }

        private Condutor NovoCondutor()
        {
            return new Condutor()
            {
                Nome = "nome",
                Email = "email@gmail.com",
                Telefone = "(13)1656-1235",
                Endereco = "endereco",
                CPF = "123.123.123-12",
                CNH = "12345678912",
                ValidadeCNH = DateTime.Now
            };
        }
    }
}
