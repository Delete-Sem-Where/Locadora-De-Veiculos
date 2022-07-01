using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloTaxa;
using LocadoraDeVeiculos.Infra.BancoDados.Test.Compartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDados.Test.ModuloTaxa
{
    [TestClass]
    public class RepositorioTaxaEmBancoDadosTest:IntegrationTestBase
    {
        private RepositorioTaxaEmBancoDados repositorio;
        public RepositorioTaxaEmBancoDadosTest()
        {
            repositorio = new RepositorioTaxaEmBancoDados();
        }

        [TestMethod]
        public void Deve_inserir_nova_taxa()
        {   
            //arrange
            var taxa = NovaTaxa();
            //act
            repositorio.Inserir(taxa);
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
            taxa.Descricao = "Descricao alterada";
            taxa.Valor = 111111;
            //act
            repositorio.Editar(taxa);
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
            //act
            repositorio.Excluir(taxa);
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

            var t2 = new Taxa()
            {
                Descricao = "recurso dois",
                Valor = 12,
                TipoCalculo = TipoCalculo.Fixo
            };

            repositorio.Inserir(t2);

            var t3 = new Taxa()
            {
                Descricao = "recurso tres",
                Valor = 13,
                TipoCalculo = TipoCalculo.Fixo
            };

            repositorio.Inserir(t3);
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

        private List<Taxa> NovasTaxas()
        {
            var t1 = new Taxa("Lavação do Veículo", 100, TipoCalculo.Fixo);
            var t2 = new Taxa("Cadeira de Bebê", 90, TipoCalculo.Diario);
            var t3 = new Taxa("Frigobar", 50, TipoCalculo.Diario);

            var lista = new List<Taxa>();
            lista.Add(t1);
            lista.Add(t2);
            lista.Add(t3);

            return lista;
        }

        #endregion
    }
}
