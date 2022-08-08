using Configs;
using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.Test.ModuloCliente
{
    [TestClass]
    public class RepositorioClienteOrmTest : IntegrationTestBase
    {
        private RepositorioClienteOrm repositorio;
        private LocadoraDeVeiculosDbContext dbContext;
        private ConfiguracaoAplicacao configuracao;

        public RepositorioClienteOrmTest()
        {
            configuracao = new ConfiguracaoAplicacao();
            dbContext = new LocadoraDeVeiculosDbContext(configuracao.ConnectionStrings);
            repositorio = new RepositorioClienteOrm(dbContext);
        }

        [TestMethod]
        public void Deve_inserir_cliente()
        {
            var cliente = NovoCliente();

            repositorio.Inserir(cliente);
            dbContext.SaveChanges();

            var clienteEncontrada = repositorio.SelecionarPorId(cliente.Id);

            clienteEncontrada.Should().NotBeNull();
            clienteEncontrada.Should().Be(cliente);
        }

        [TestMethod]
        public void Deve_editar_informacoes_cliente()
        {
            var cliente = NovoCliente();

            repositorio.Inserir(cliente);
            dbContext.SaveChanges();

            cliente.Nome = "nome alterado";
            repositorio.Editar(cliente);
            dbContext.SaveChanges();

            var clienteEncontrada = repositorio.SelecionarPorId(cliente.Id);

            clienteEncontrada.Should().NotBeNull();
            clienteEncontrada.Should().Be(cliente);
        }

        [TestMethod]
        public void Deve_excluir_funcionario()
        {
            var cliente = NovoCliente();

            repositorio.Inserir(cliente);
            dbContext.SaveChanges();

            repositorio.Excluir(cliente);
            dbContext.SaveChanges();

            repositorio.SelecionarPorId(cliente.Id)
                .Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_cliente_por_id()
        {
            var cliente = NovoCliente();

            repositorio.Inserir(cliente);
            dbContext.SaveChanges();

            var clienteEncontrada = repositorio.SelecionarPorId(cliente.Id);

            clienteEncontrada.Should().NotBeNull();
            clienteEncontrada.Should().Be(cliente);
        }

        [TestMethod]
        public void Deve_selecionar_todas_pessoas_fisicas()
        {
            var pj1 = new Cliente()
            {
                Nome = "nome um",
                Email = "email1@gmail.com",
                Telefone = "(13)1656-1235",
                Endereco = "endereco 1",
                Documento = "123.123.123-11",
                TipoCliente = TipoCliente.PessoaFisica
            };

            repositorio.Inserir(pj1);
            dbContext.SaveChanges();

            var pj2 = new Cliente()
            {
                Nome = "nome dois",
                Email = "email2@gmail.com",
                Telefone = "(13)1656-1235",
                Endereco = "endereco 2",
                Documento = "12.345.678/9123-45",
                TipoCliente = TipoCliente.PessoaJuridica
            };

            repositorio.Inserir(pj2);
            dbContext.SaveChanges();

            var pj3 = new Cliente()
            {
                Nome = "nome tres",
                Email = "email3@gmail.com",
                Telefone = "(13)1656-1235",
                Endereco = "endereco 3",
                Documento = "123.123.123-13",
                TipoCliente = TipoCliente.PessoaFisica
            };

            repositorio.Inserir(pj3);
            dbContext.SaveChanges();

            var pessoasFisicas = repositorio.SelecionarTodos();

            pessoasFisicas.Count.Should().Be(3);

            pessoasFisicas[0].Should().Be(pj1);
            pessoasFisicas[1].Should().Be(pj2);
            pessoasFisicas[2].Should().Be(pj3);
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
