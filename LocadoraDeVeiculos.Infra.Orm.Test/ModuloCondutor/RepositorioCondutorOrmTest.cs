using Configs;
using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm.ModuloCliente;
using LocadoraDeVeiculos.Infra.Orm.ModuloCondutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.Test.ModuloCondutor
{
    [TestClass]
    public class RepositorioCondutorOrmTest : IntegrationTestBase
    {
        private RepositorioCondutorOrm repositorio;
        private RepositorioClienteOrm repositorioCliente;
        private LocadoraDeVeiculosDbContext dbContext;
        private ConfiguracaoAplicacao configuracao;

        public RepositorioCondutorOrmTest()
        {
            configuracao = new ConfiguracaoAplicacao();
            dbContext = new LocadoraDeVeiculosDbContext(configuracao.ConnectionStrings);
            repositorio = new RepositorioCondutorOrm(dbContext);
            repositorioCliente = new RepositorioClienteOrm(dbContext);
        }

        [TestMethod]
        public void Deve_inserir_condutor()
        {
            var condutor = NovoCondutor();

            repositorio.Inserir(condutor);
            dbContext.GravarDados();

            var condutorEncontrado = repositorio.SelecionarPorId(condutor.Id);

            condutorEncontrado.Should().NotBeNull();
            condutorEncontrado.Should().Be(condutor);
        }

        [TestMethod]
        public void Deve_editar_informacoes_condutor()
        {
            var condutor = NovoCondutor();

            repositorio.Inserir(condutor);
            dbContext.GravarDados();

            condutor.Nome = "nome alterado";
            repositorio.Editar(condutor);
            dbContext.GravarDados();

            var condutorEncontrado = repositorio.SelecionarPorId(condutor.Id);

            condutorEncontrado.Should().NotBeNull();
            condutorEncontrado.Should().Be(condutor);
        }

        [TestMethod]
        public void Deve_excluir_condutor()
        {
            var condutor = NovoCondutor();

            repositorio.Inserir(condutor);
            dbContext.GravarDados();

            repositorio.Excluir(condutor);
            dbContext.GravarDados();

            repositorio.SelecionarPorId(condutor.Id)
                .Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_condutor_por_id()
        {
            var condutor = NovoCondutor();

            repositorio.Inserir(condutor);
            dbContext.GravarDados();

            var condutorEncontrado = repositorio.SelecionarPorId(condutor.Id);

            condutorEncontrado.Should().NotBeNull();
            condutorEncontrado.Should().Be(condutor);
        }

        [TestMethod]
        public void Deve_selecionar_todos_condutores()
        {
            var cliente = NovoCliente();

            repositorioCliente.Inserir(cliente);
            dbContext.GravarDados();

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
                Cliente = cliente_encontrado,
            };

            repositorio.Inserir(c1);
            dbContext.GravarDados();

            var c2 = new Condutor()
            {
                Nome = "nome dois",
                Email = "email@gmail.com",
                Telefone = "(13)1656-1235",
                Endereco = "endereco",
                CPF = "123.123.123-12",
                CNH = "12345678912",
                ValidadeCNH = DateTime.Now,
                Cliente = cliente_encontrado,
            };

            repositorio.Inserir(c2);
            dbContext.GravarDados();

            var c3 = new Condutor()
            {
                Nome = "nome tres",
                Email = "email@gmail.com",
                Telefone = "(13)1656-1235",
                Endereco = "endereco",
                CPF = "123.123.123-13",
                CNH = "12345678912",
                ValidadeCNH = DateTime.Now,
                Cliente = cliente_encontrado,
            };

            repositorio.Inserir(c3);
            dbContext.GravarDados();

            var condutores = repositorio.SelecionarTodos();

            condutores.Count.Should().Be(3);

            condutores[0].Should().Be(c1);
            condutores[1].Should().Be(c2);
            condutores[2].Should().Be(c3);
        }

        private Condutor NovoCondutor()
        {
            var cliente = NovoCliente();

            repositorioCliente.Inserir(cliente);
            dbContext.GravarDados();

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
                Cliente = cliente_encontrado,
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
