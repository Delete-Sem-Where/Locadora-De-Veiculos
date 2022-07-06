using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloGruposVeiculos;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.BancoDados.Test.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDados.Test.ModuloPlanoCobranca
{
    [TestClass]
    public class RepositorioPlanoCobrancaEmBancoDadosTest : IntegrationTestBase
    {
        private RepositorioPlanoCobrancaEmBancoDados repositorioPlanoCobranca;
        private RepositorioGrupoVeiculosEmBancoDados repositorioGrupoVeiculos;
        public RepositorioPlanoCobrancaEmBancoDadosTest()
        {
            repositorioPlanoCobranca = new RepositorioPlanoCobrancaEmBancoDados();
            repositorioGrupoVeiculos = new RepositorioGrupoVeiculosEmBancoDados();
        }

        [TestMethod]
        public void Deve_inserir_novo_planoCobranca()
        {
            //arrange
            var planoCobranca = NovoPlanoCobranca();
            //act
            repositorioPlanoCobranca.Inserir(planoCobranca);
            var planoCobrancaEncontrada = repositorioPlanoCobranca.SelecionarPorId(planoCobranca.Id);
            //assert
            planoCobrancaEncontrada.Should().NotBeNull();
            planoCobrancaEncontrada.Should().Be(planoCobranca);
        }

        [TestMethod]
        public void Deve_editar_informacoes_planoCobranca()
        {
            //arrange
            var planoCobranca = NovoPlanoCobranca();
            repositorioPlanoCobranca.Inserir(planoCobranca);
            planoCobranca.ValorDiaria = 111111;
            planoCobranca.ValorKm = 111112;
            planoCobranca.LimiteKm = 111113;
            //act
            repositorioPlanoCobranca.Editar(planoCobranca);
            var planoCobrancaEncontrado = repositorioPlanoCobranca.SelecionarPorId(planoCobranca.Id);
            //assert
            planoCobrancaEncontrado.Should().NotBeNull();
            planoCobrancaEncontrado.Should().Be(planoCobranca);
        }

        [TestMethod]
        public void Deve_excluir_planoCobranca()
        {
            //arrange
            var planoCobranca = NovoPlanoCobranca();
            repositorioPlanoCobranca.Inserir(planoCobranca);
            //act
            repositorioPlanoCobranca.Excluir(planoCobranca);
            //assert
            repositorioPlanoCobranca.SelecionarPorId(planoCobranca.Id)
                .Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_planoCobranca_por_id()
        {
            //arrange
            var planoCobranca = NovoPlanoCobranca();
            repositorioPlanoCobranca.Inserir(planoCobranca);
            //act
            var planoCobrancaEncontrado = repositorioPlanoCobranca.SelecionarPorId(planoCobranca.Id);
            //assert
            planoCobrancaEncontrado.Should().NotBeNull();
            planoCobrancaEncontrado.Should().Be(planoCobranca);
        }

        [TestMethod]
        public void Deve_selecionar_todas_planoCobrancas()
        {
            var novoGrupoVeiculos = NovoGrupoVeiculos();
            repositorioGrupoVeiculos.Inserir(novoGrupoVeiculos);
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

            repositorioPlanoCobranca.Inserir(p1);

            var p2 = new PlanoCobranca()
            {
                GrupoVeiculos = grupoVeiculosEncontrado,

                ModalidadePlanoCobranca = ModalidadePlanoCobranca.Diario,
                ValorDiaria = 102,
                ValorKm = 12,
                LimiteKm = 12
            };

            repositorioPlanoCobranca.Inserir(p2);

            var p3 = new PlanoCobranca()
            {
                GrupoVeiculos = grupoVeiculosEncontrado,

                ModalidadePlanoCobranca = ModalidadePlanoCobranca.Diario,
                ValorDiaria = 103,
                ValorKm = 13,
                LimiteKm = 13
            };

            repositorioPlanoCobranca.Inserir(p3);
            //act
            var planoCobrancas = repositorioPlanoCobranca.SelecionarTodos();
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
