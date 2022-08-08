using Configs;
using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm.ModuloTaxa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.Test.ModuloTaxa
{
    [TestClass]
    public class RepositorioTaxaOrmTest : IntegrationTestBase
    {
        private RepositorioTaxaOrm repositorio;
        private LocadoraDeVeiculosDbContext dbContext;
        private ConfiguracaoAplicacao configuracao;

        public RepositorioTaxaOrmTest()
        {
            configuracao = new ConfiguracaoAplicacao();
            dbContext = new LocadoraDeVeiculosDbContext(configuracao.ConnectionStrings);
            repositorio = new RepositorioTaxaOrm(dbContext);
        }

        [TestMethod]
        public void Deve_inserir_nova_taxa()
        {
            //arrange
            var taxa = NovaTaxa();
            //act
            repositorio.Inserir(taxa);
            dbContext.GravarDados();

            var taxaEncontrada = repositorio.SelecionarPorId(taxa.Id);
            //assert
            taxaEncontrada.Should().NotBeNull();
            taxaEncontrada.Should().Be(taxa);
        }

        [TestMethod]
        public void Deve_editar_informacoes_taxa()
        {
            //arrange
            var taxa = NovaTaxa();
            repositorio.Inserir(taxa);
            dbContext.GravarDados();

            taxa.Descricao = "Descricao alterada";
            taxa.Valor = 111111;
            //act
            repositorio.Editar(taxa);
            dbContext.GravarDados();

            var taxaEncontrado = repositorio.SelecionarPorId(taxa.Id);
            //assert
            taxaEncontrado.Should().NotBeNull();
            taxaEncontrado.Should().Be(taxa);
        }

        [TestMethod]
        public void Deve_excluir_taxa()
        {
            //arrange
            var taxa = NovaTaxa();
            repositorio.Inserir(taxa);
            dbContext.GravarDados();

            //act
            repositorio.Excluir(taxa);
            dbContext.GravarDados();

            //assert
            repositorio.SelecionarPorId(taxa.Id)
                .Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_taxa_por_id()
        {
            //arrange
            var taxa = NovaTaxa();
            repositorio.Inserir(taxa);
            dbContext.GravarDados();

            //act
            var taxaEncontrado = repositorio.SelecionarPorId(taxa.Id);
            //assert
            taxaEncontrado.Should().NotBeNull();
            taxaEncontrado.Should().Be(taxa);
        }

        [TestMethod]
        public void Deve_selecionar_todas_taxas()
        {
            //arrange
            var t1 = new Taxa()
            {
                Descricao = "recurso um",
                Valor = 11,
                TipoCalculo = TipoCalculo.Fixo
            };

            repositorio.Inserir(t1);
            dbContext.GravarDados();


            var t2 = new Taxa()
            {
                Descricao = "recurso dois",
                Valor = 12,
                TipoCalculo = TipoCalculo.Fixo
            };

            repositorio.Inserir(t2);
            dbContext.GravarDados();


            var t3 = new Taxa()
            {
                Descricao = "recurso tres",
                Valor = 13,
                TipoCalculo = TipoCalculo.Fixo
            };

            repositorio.Inserir(t3);
            dbContext.GravarDados();

            //act
            var taxas = repositorio.SelecionarTodos();
            //assert
            taxas.Count.Should().Be(3);
            taxas[0].Should().Be(t1);
            taxas[1].Should().Be(t2);
            taxas[2].Should().Be(t3);
        }

        #region MÉTODOS PRIVADOS

        private Taxa NovaTaxa()
        {
            var t = new Taxa();
            t.Descricao = "Lavação do Veículo";
            t.Valor = 100;
            t.TipoCalculo = TipoCalculo.Fixo;

            return t;
        }

        #endregion
    }
}
