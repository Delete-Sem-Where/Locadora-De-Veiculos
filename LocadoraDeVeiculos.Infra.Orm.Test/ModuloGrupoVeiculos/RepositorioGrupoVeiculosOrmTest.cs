using Configs;
using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm.ModuloGrupoVeiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.Test.ModuloGrupoVeiculos
{
    [TestClass]
    public class RepositorioGrupoVeiculosOrmTest : IntegrationTestBase
    {
        private RepositorioGrupoVeiculosOrm repositorio;
        private LocadoraDeVeiculosDbContext dbContext;
        private ConfiguracaoAplicacao configuracao;

        public RepositorioGrupoVeiculosOrmTest()
        {
            configuracao = new ConfiguracaoAplicacao();
            dbContext = new LocadoraDeVeiculosDbContext(configuracao.ConnectionStrings);
            repositorio = new RepositorioGrupoVeiculosOrm(dbContext);
        }

        [TestMethod]
        public void Deve_inserir_grupo_de_veiculos()
        {
            var grupoVeiculos = NovoGrupoVeiculos();

            repositorio.Inserir(grupoVeiculos);
            dbContext.GravarDados();

            var grupoVeiculosEncontrado = repositorio.SelecionarPorId(grupoVeiculos.Id);

            grupoVeiculosEncontrado.Should().NotBeNull();
            grupoVeiculosEncontrado.Should().Be(grupoVeiculos);
        }

        [TestMethod]
        public void Deve_editar_grupo_de_veiculos()
        {
            var grupoVeiculos = NovoGrupoVeiculos();

            repositorio.Inserir(grupoVeiculos);
            dbContext.GravarDados();

            grupoVeiculos.Nome = "Nome alterado";
            repositorio.Editar(grupoVeiculos);
            dbContext.GravarDados();

            var grupoVeiculosEncontrado = repositorio.SelecionarPorId(grupoVeiculos.Id);

            grupoVeiculosEncontrado.Should().NotBeNull();
            grupoVeiculosEncontrado.Should().Be(grupoVeiculos);
        }

        [TestMethod]
        public void Deve_excluir_grupo_de_veiculos()
        {
            var grupoVeiculos = NovoGrupoVeiculos();

            repositorio.Inserir(grupoVeiculos);
            dbContext.GravarDados();

            repositorio.Excluir(grupoVeiculos);
            dbContext.GravarDados();

            repositorio.SelecionarPorId(grupoVeiculos.Id)
                .Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_grupo_de_veiculos_por_id()
        {
            var grupoVeiculos = NovoGrupoVeiculos();

            repositorio.Inserir(grupoVeiculos);
            dbContext.GravarDados();

            var grupoVeiculosEncontrado = repositorio.SelecionarPorId(grupoVeiculos.Id);

            grupoVeiculosEncontrado.Should().NotBeNull();
            grupoVeiculosEncontrado.Should().Be(grupoVeiculos);
        }

        [TestMethod]
        public void Deve_selecionar_todos_grupos_de_veiculos()
        {
            var gv1 = new GrupoVeiculos()
            {
                Nome = "Nome um",
            };

            repositorio.Inserir(gv1);
            dbContext.GravarDados();

            var gv2 = new GrupoVeiculos()
            {
                Nome = "Nome dois",
            };

            repositorio.Inserir(gv2);
            dbContext.GravarDados();

            var gv3 = new GrupoVeiculos()
            {
                Nome = "Nome tres",
            };

            repositorio.Inserir(gv3);
            dbContext.GravarDados();

            var grupos_veiculos = repositorio.SelecionarTodos();

            grupos_veiculos.Count.Should().Be(3);

            grupos_veiculos[0].Should().Be(gv1);
            grupos_veiculos[1].Should().Be(gv2);
            grupos_veiculos[2].Should().Be(gv3);
        }

        private GrupoVeiculos NovoGrupoVeiculos()
        {
            return new GrupoVeiculos()
            {
                Nome = "Nome Teste",
            };
        }
    }
}
