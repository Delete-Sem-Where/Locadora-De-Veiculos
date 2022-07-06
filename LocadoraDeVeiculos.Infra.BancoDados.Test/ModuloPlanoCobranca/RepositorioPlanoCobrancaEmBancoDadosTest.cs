using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
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
            private RepositorioPlanoCobrancaEmBancoDados repositorio;
            public RepositorioPlanoCobrancaEmBancoDadosTest()
            {
                repositorio = new RepositorioPlanoCobrancaEmBancoDados();
            }

            [TestMethod]
            public void Deve_inserir_novo_planoCobranca()
            {
                //arrange
                var planoCobranca = NovoPlanoCobranca();
                //act
                repositorio.Inserir(planoCobranca);
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
                planoCobranca.ValorDiaria = 111111;
                planoCobranca.ValorKm = 111112;
                planoCobranca.LimiteKm = 111113;
            //act
            repositorio.Editar(planoCobranca);
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
                //act
                repositorio.Excluir(planoCobranca);
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
                //act
                var planoCobrancaEncontrado = repositorio.SelecionarPorId(planoCobranca.Id);
                //assert
                planoCobrancaEncontrado.Should().NotBeNull();
                planoCobrancaEncontrado.Should().Be(planoCobranca);
            }

            [TestMethod]
            public void Deve_selecionar_todas_planoCobrancas()
            {
                //arrange
                var p1 = new PlanoCobranca()
                {
                    
                    GrupoVeiculos = new()
                    {
                        Nome = "SUV",
                    },

                    ModalidadePlanoCobranca = ModalidadePlanoCobranca.Diario,
                    ValorDiaria = 101,
                    ValorKm = 11,
                    LimiteKm = 11
                };       

                repositorio.Inserir(p1);

            var p2 = new PlanoCobranca()
            {

                GrupoVeiculos = new()
                {
                    Nome = "SUV",
                },

                ModalidadePlanoCobranca = ModalidadePlanoCobranca.Diario,
                ValorDiaria = 102,
                ValorKm = 12,
                LimiteKm = 12
            };

            repositorio.Inserir(p2);

            var p3 = new PlanoCobranca()
            {

                GrupoVeiculos = new()
                {
                    Nome = "SUV",
                },

                ModalidadePlanoCobranca = ModalidadePlanoCobranca.Diario,
                ValorDiaria = 103,
                ValorKm = 13,
                LimiteKm = 13
            };

            repositorio.Inserir(p3);
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
                var pc = new PlanoCobranca();
            {

                pc.GrupoVeiculos = new()
                {
                    Nome = "SUV",
                };

                pc.ModalidadePlanoCobranca = ModalidadePlanoCobranca.Diario;
                pc.ValorDiaria = 103;
                pc.ValorKm = 13;
                pc.LimiteKm = 13;
            };

            return pc;
            }

           
            #endregion
        }
    }
