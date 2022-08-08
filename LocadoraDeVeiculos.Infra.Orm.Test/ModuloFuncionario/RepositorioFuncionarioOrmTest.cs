using Configs;
using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.Test.ModuloFuncionario
{
    [TestClass]
    public class RepositorioFuncionarioOrmTest : IntegrationTestBase
    {
        private RepositorioFuncionarioOrm repositorio;
        private LocadoraDeVeiculosDbContext dbContext;
        private ConfiguracaoAplicacao configuracao;

        public RepositorioFuncionarioOrmTest()
        {
            configuracao = new ConfiguracaoAplicacao();
            dbContext = new LocadoraDeVeiculosDbContext(configuracao.ConnectionStrings);
            repositorio = new RepositorioFuncionarioOrm(dbContext);
        }

        [TestMethod]
        public void Deve_inserir_novo_funcionario()
        {
            var funcionario = NovoFuncionario();

            repositorio.Inserir(funcionario);
            dbContext.GravarDados();

            var funcionarioEncontrado = repositorio.SelecionarPorId(funcionario.Id);

            funcionarioEncontrado.Should().NotBeNull();
            funcionarioEncontrado.Should().Be(funcionario);
        }

        [TestMethod]
        public void Deve_editar_informacoes_paciente()
        {
            var funcionario = NovoFuncionario();

            repositorio.Inserir(funcionario);
            dbContext.GravarDados();

            funcionario.Nome = "nome alterado";

            repositorio.Editar(funcionario);
            dbContext.GravarDados();

            var funcionarioEncontrado = repositorio.SelecionarPorId(funcionario.Id);

            funcionarioEncontrado.Should().NotBeNull();
            funcionarioEncontrado.Should().Be(funcionario);
        }

        [TestMethod]
        public void Deve_excluir_funcionario()
        {
            var funcionario = NovoFuncionario();

            repositorio.Inserir(funcionario);
            dbContext.GravarDados();

            repositorio.Excluir(funcionario);
            dbContext.GravarDados();

            repositorio.SelecionarPorId(funcionario.Id)
                .Should().BeNull();
        }


        [TestMethod]
        public void Deve_selecionar_funcionario_por_id()
        {
            var funcionario = NovoFuncionario();

            repositorio.Inserir(funcionario);
            dbContext.GravarDados();

            var funcionarioEncontrado = repositorio.SelecionarPorId(funcionario.Id);

            funcionarioEncontrado.Should().NotBeNull();
            funcionarioEncontrado.Should().Be(funcionario);
        }

        [TestMethod]
        public void Deve_selecionar_todos_funcionarios()
        {
            var f1 = new Funcionario()
            {
                Nome = "nome um",
                Email = "email1@gmail.com",
                Telefone = "(11)1234-5671",
                Endereco = "endereco 1",
                Login = "login 1",
                Senha = "senha 1",
                Salario = 1000,
                DataDeAdmissao = DateTime.Now.Date
            };

            repositorio.Inserir(f1);
            dbContext.GravarDados();

            var f2 = new Funcionario()
            {
                Nome = "nome dois",
                Email = "email2@gmail.com",
                Telefone = "(11)1234-5672",
                Endereco = "endereco 2",
                Login = "login 2",
                Senha = "senha 2",
                Salario = 2000,
                DataDeAdmissao = DateTime.Now.Date
            };

            repositorio.Inserir(f2);
            dbContext.GravarDados();

            var f3 = new Funcionario()
            {
                Nome = "nome tres",
                Email = "email3@gmail.com",
                Telefone = "(11)1234-5673",
                Endereco = "endereco 3",
                Login = "login 3",
                Senha = "senha 3",
                Salario = 3000,
                DataDeAdmissao = DateTime.Now.Date
            };

            repositorio.Inserir(f3);
            dbContext.GravarDados();

            var funcionarios = repositorio.SelecionarTodos();

            funcionarios.Count.Should().Be(3);

            funcionarios[0].Should().Be(f1);
            funcionarios[1].Should().Be(f2);
            funcionarios[2].Should().Be(f3);
        }

        private Funcionario NovoFuncionario()
        {
            return new Funcionario()
            {
                Nome = "nome",
                Email = "email@gmail.com",
                Telefone = "(11)1234-5678",
                Endereco = "endereco",
                Login = "login",
                Senha = "senha",
                Salario = 1000,
                DataDeAdmissao = DateTime.Now.Date
            };
        }
    }
}
