using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloCliente;
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
        private RepositorioCondutorEmBancoDados repositorioCondutor;
        private RepositorioClienteEmBancoDados repositorioCliente;

        public RepositorioCondutorEmBancoDadosTest()
        {
            repositorioCondutor = new RepositorioCondutorEmBancoDados();
            repositorioCliente = new RepositorioClienteEmBancoDados();
        }

        [TestMethod]
        public void Deve_inserir_condutor()
        {
            var condutor = NovoCondutor();

            repositorioCondutor.Inserir(condutor);

            var condutorEncontrado = repositorioCondutor.SelecionarPorId(condutor.Id);

            condutorEncontrado.Should().NotBeNull();
            condutorEncontrado.Should().Be(condutor);
        }

        [TestMethod]
        public void Deve_editar_informacoes_condutor()
        {
            var condutor = NovoCondutor();

            repositorioCondutor.Inserir(condutor);

            condutor.Nome = "nome alterado";
            repositorioCondutor.Editar(condutor);

            var condutorEncontrado = repositorioCondutor.SelecionarPorId(condutor.Id);

            condutorEncontrado.Should().NotBeNull();
            condutorEncontrado.Should().Be(condutor);
        }

        [TestMethod]
        public void Deve_excluir_condutor()
        {
            var condutor = NovoCondutor();

            repositorioCondutor.Inserir(condutor);

            repositorioCondutor.Excluir(condutor);

            repositorioCondutor.SelecionarPorId(condutor.Id)
                .Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_condutor_por_id()
        {
            var condutor = NovoCondutor();

            repositorioCondutor.Inserir(condutor);

            var condutorEncontrado = repositorioCondutor.SelecionarPorId(condutor.Id);

            condutorEncontrado.Should().NotBeNull();
            condutorEncontrado.Should().Be(condutor);
        }

        [TestMethod]
        public void Deve_selecionar_todos_condutores()
        {
            var cliente = NovoCliente();

            repositorioCliente.Inserir(cliente);

            var cliente_encontrado = repositorioCliente.SelecionarPorId(cliente.Id);

            var c1 = new Condutor()
            {
                Nome = "nome um",
                Email = "email@gmail.com",
                Telefone = "(13)1656-1235",
                Endereco = "endereco",
                CPF = "123.123.123-11",
                CNH = "12345678912",
                ValidadeCNH = DateTime.Now,
                //Cliente_Id = cliente_encontrado.Id,
            };

            repositorioCondutor.Inserir(c1);

            var c2 = new Condutor()
            {
                Nome = "nome dois",
                Email = "email@gmail.com",
                Telefone = "(13)1656-1235",
                Endereco = "endereco",
                CPF = "123.123.123-12",
                CNH = "12345678912",
                ValidadeCNH = DateTime.Now,
                //Cliente_Id = cliente_encontrado.Id,
            };

            repositorioCondutor.Inserir(c2);

            var c3 = new Condutor()
            {
                Nome = "nome tres",
                Email = "email@gmail.com",
                Telefone = "(13)1656-1235",
                Endereco = "endereco",
                CPF = "123.123.123-13",
                CNH = "12345678912",
                ValidadeCNH = DateTime.Now,
                //Cliente_Id = cliente_encontrado.Id,
            };

            repositorioCondutor.Inserir(c3);

            var condutores = repositorioCondutor.SelecionarTodos();

            condutores.Count.Should().Be(3);

            condutores[0].Should().Be(c1);
            condutores[1].Should().Be(c2);
            condutores[2].Should().Be(c3);
        }

        private Condutor NovoCondutor()
        {
            var cliente = NovoCliente();

            repositorioCliente.Inserir(cliente);

            var cliente_encontrado = repositorioCliente.SelecionarPorId(cliente.Id);

            return new Condutor()
            {
                Nome = "nome",
                Email = "email@gmail.com",
                Telefone = "(13)1656-1235",
                Endereco = "endereco",
                CPF = "123.123.123-12",
                CNH = "12345678912",
                ValidadeCNH = DateTime.Now,
                //Cliente_Id = cliente_encontrado.Id,
            };
        }

        private Cliente NovoCliente()
        {
            return new Cliente()
            {
                Nome = "nome",
                Email = "email@gmail.com",
                Telefone = "(13)1656-1235",
                Endereco = "endereco",
                Documento = "123.123.123-12",
                TipoCliente = TipoCliente.PessoaFisica,
            };
        }

    }
}
