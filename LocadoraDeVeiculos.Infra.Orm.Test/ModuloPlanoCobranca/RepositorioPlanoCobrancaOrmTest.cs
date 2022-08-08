using Configs;
using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.Orm.ModuloPlanoCobranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.Test.ModuloPlanoCobranca
{
    [TestClass]
    public class RepositorioPlanoCobrancaOrmTest : IntegrationTestBase
    {
        private RepositorioPlanoCobrancaOrm repositorio;
        private RepositorioGrupoVeiculosOrm repositorioGrupoVeiculos;
        private LocadoraDeVeiculosDbContext dbContext;
        private ConfiguracaoAplicacao configuracao;

        public RepositorioPlanoCobrancaOrmTest()
        {
            configuracao = new ConfiguracaoAplicacao();
            dbContext = new LocadoraDeVeiculosDbContext(configuracao.ConnectionStrings);
            repositorio = new RepositorioPlanoCobrancaOrm(dbContext);
            repositorioGrupoVeiculos = new RepositorioGrupoVeiculosOrm(dbContext);
        }

        [TestMethod]
        public void Deve_inserir_novo_planoCobranca()
        {
            //arrange
            var planoCobranca = NovoPlanoCobranca();
            //act
            repositorio.Inserir(planoCobranca);
            dbContext.GravarDados();

            var planoCobrancaEncontrada = repositorio.SelecionarPorId(planoCobranca.Id);
            //assert
            planoCobrancaEncontrada.Should().NotBeNull();
            planoCobrancaEncontrada.Should().Be(planoCobranca);
        }

        [TestMethod]
        public void Deve_editar_informacoes_planoCobranca()
        {
            //arrange
            var planoCobranca = NovoPlanoCobranca();
            repositorio.Inserir(planoCobranca);
            dbContext.GravarDados();

            planoCobranca.ValorDiaria = 111111;
            planoCobranca.ValorKm = 111112;
            planoCobranca.LimiteKm = 111113;
            //act
            repositorio.Editar(planoCobranca);
            dbContext.GravarDados();

            var planoCobrancaEncontrado = repositorio.SelecionarPorId(planoCobranca.Id);
            //assert
            planoCobrancaEncontrado.Should().NotBeNull();
            planoCobrancaEncontrado.Should().Be(planoCobranca);
        }

        [TestMethod]
        public void Deve_excluir_planoCobranca()
        {
            //arrange
            var planoCobranca = NovoPlanoCobranca();
            repositorio.Inserir(planoCobranca);
            dbContext.GravarDados();

            //act
            repositorio.Excluir(planoCobranca);
            dbContext.GravarDados();

            //assert
            repositorio.SelecionarPorId(planoCobranca.Id)
                .Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_planoCobranca_por_id()
        {
            //arrange
            var planoCobranca = NovoPlanoCobranca();
            repositorio.Inserir(planoCobranca);
            dbContext.GravarDados();

            //act
            var planoCobrancaEncontrado = repositorio.SelecionarPorId(planoCobranca.Id);
            //assert
            planoCobrancaEncontrado.Should().NotBeNull();
            planoCobrancaEncontrado.Should().Be(planoCobranca);
        }

        [TestMethod]
        public void Deve_selecionar_todas_planoCobrancas()
        {
            var novoGrupoVeiculos = NovoGrupoVeiculos();
            repositorioGrupoVeiculos.Inserir(novoGrupoVeiculos);
            dbContext.GravarDados();

            var grupoVeiculosEncontrado = repositorioGrupoVeiculos.SelecionarPorId(novoGrupoVeiculos.Id);

            //arrange
            var p1 = new PlanoCobranca()
            {
                GrupoVeiculos = grupoVeiculosEncontrado,

                ModalidadePlanoCobranca = ModalidadePlanoCobranca.Diario,
                ValorDiaria = 101,
                ValorKm = 11,
                LimiteKm = 11
            };

            repositorio.Inserir(p1);
            dbContext.GravarDados();


            var p2 = new PlanoCobranca()
            {
                GrupoVeiculos = grupoVeiculosEncontrado,

                ModalidadePlanoCobranca = ModalidadePlanoCobranca.Diario,
                ValorDiaria = 102,
                ValorKm = 12,
                LimiteKm = 12
            };

            repositorio.Inserir(p2);
            dbContext.GravarDados();


            var p3 = new PlanoCobranca()
            {
                GrupoVeiculos = grupoVeiculosEncontrado,

                ModalidadePlanoCobranca = ModalidadePlanoCobranca.Diario,
                ValorDiaria = 103,
                ValorKm = 13,
                LimiteKm = 13
            };

            repositorio.Inserir(p3);
            dbContext.GravarDados();

            //act
            var planoCobrancas = repositorio.SelecionarTodos();
            //assert
            planoCobrancas.Count.Should().Be(3);
            planoCobrancas[0].Should().Be(p1);
            planoCobrancas[1].Should().Be(p2);
            planoCobrancas[2].Should().Be(p3);
        }

        #region MÉTODOS PRIVADOS

        private PlanoCobranca NovoPlanoCobranca()
        {
            var novoGrupoVeiculos = NovoGrupoVeiculos();
            repositorioGrupoVeiculos.Inserir(novoGrupoVeiculos);
            dbContext.GravarDados();

            var grupoVeiculosEncontrado = repositorioGrupoVeiculos.SelecionarPorId(novoGrupoVeiculos.Id);

            var pc = new PlanoCobranca();
            {
                pc.GrupoVeiculos = grupoVeiculosEncontrado;
                pc.ModalidadePlanoCobranca = ModalidadePlanoCobranca.Controle;
                pc.ValorDiaria = 103;
                pc.ValorKm = 13;
                pc.LimiteKm = 13;
            };

            return pc;
        }

        private GrupoVeiculos NovoGrupoVeiculos()
        {
            return new GrupoVeiculos()
            {
                Nome = "SUV"
            };

        }
        #endregion
    }
}
