using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloVeiculos;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloGruposVeiculos;
using LocadoraDeVeiculos.Infra.BancoDados.Test.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace LocadoraDeVeiculos.Infra.BancoDados.Test.ModuloVeiculos
{
    [TestClass]
    public class RepositorioVeiculosEmBancoDadosTest : IntegrationTestBase
    {
        private RepositorioVeiculosEmBancoDados repositorioVeiculos;
        private RepositorioGrupoVeiculosEmBancoDados repositorioGrupoVeiculos;

        public RepositorioVeiculosEmBancoDadosTest()
        {
            repositorioVeiculos = new RepositorioVeiculosEmBancoDados();
            repositorioGrupoVeiculos = new RepositorioGrupoVeiculosEmBancoDados();
        }

        [TestMethod]
        public void Deve_inserir_veiculo()
        {
            var veiculo = NovoVeiculo();

            repositorioVeiculos.Inserir(veiculo);

            var veiculoEncontrado = repositorioVeiculos.SelecionarPorId(veiculo.Id);

            veiculoEncontrado.Should().NotBeNull();
            veiculoEncontrado.Should().Be(veiculo);
        }

        [TestMethod]
        public void Deve_editar_informacoes_veiculo()
        {
            var veiculo = NovoVeiculo();

            repositorioVeiculos.Inserir(veiculo);

            veiculo.Modelo = "Modelo alterado";
            repositorioVeiculos.Editar(veiculo);

            var veiculoEncontrado = repositorioVeiculos.SelecionarPorId(veiculo.Id);

            veiculoEncontrado.Should().NotBeNull();
            veiculoEncontrado.Should().Be(veiculo);
        }

        [TestMethod]
        public void Deve_excluir_veiculo()
        {
            var veiculo = NovoVeiculo();

            repositorioVeiculos.Inserir(veiculo);

            repositorioVeiculos.Excluir(veiculo);

            repositorioVeiculos.SelecionarPorId(veiculo.Id)
                .Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_veiculos_por_id()
        {
            var veiculo = NovoVeiculo();

            repositorioVeiculos.Inserir(veiculo);

            var veiculoEncontrado = repositorioVeiculos.SelecionarPorId(veiculo.Id);

            veiculoEncontrado.Should().NotBeNull();
            veiculoEncontrado.Should().Be(veiculo);
        }

        [TestMethod]
        public void Deve_selecionar_todos_veiculos()
        {
            var grupoVeiculos = NovoGrupoVeiculos();

            repositorioGrupoVeiculos.Inserir(grupoVeiculos);

            var grupoVeiculos_encontrado = repositorioGrupoVeiculos.SelecionarPorId(grupoVeiculos.Id);

            var v1 = new Veiculos()
            {
                Modelo = "Fuscão 99",
                Marca = "Volkswagen",
                Placa = "ASD9874",
                Ano = "2003",
                Cor = "Azul",
                TipoCombustivel = "Gasolina",
                QuilometroPercorrido = "90000",
                CapacidadeTanque = "17",
                GrupoVeiculos = grupoVeiculos_encontrado,
            };

            repositorioVeiculos.Inserir(v1);

            var v2 = new Veiculos()
            {
                Modelo = "Fuscão 98",
                Marca = "Volkswagen",
                Placa = "ASD9624",
                Ano = "2003",
                Cor = "Azul",
                TipoCombustivel = "Gasolina",
                QuilometroPercorrido = "90000",
                CapacidadeTanque = "15",
                GrupoVeiculos = grupoVeiculos_encontrado,
            };

            repositorioVeiculos.Inserir(v2);

            var v3 = new Veiculos()
            {
                Modelo = "Fuscão 97",
                Marca = "Volkswagen",
                Placa = "AQD3794",
                Ano = "2003",
                Cor = "Azul",
                TipoCombustivel = "Gasolina",
                QuilometroPercorrido = "90000",
                CapacidadeTanque = "16",
                GrupoVeiculos = grupoVeiculos_encontrado,
            };

            repositorioVeiculos.Inserir(v3);

            var veiculos = repositorioVeiculos.SelecionarTodos();

            veiculos.Count.Should().Be(3);

            veiculos[0].Should().Be(v1);
            veiculos[1].Should().Be(v2);
            veiculos[2].Should().Be(v3);
        }

        private Veiculos NovoVeiculo()
        {
            var grupoVeiculos = NovoGrupoVeiculos();

            repositorioGrupoVeiculos.Inserir(grupoVeiculos);

            var grupoVeiculos_encontrado = repositorioGrupoVeiculos.SelecionarPorId(grupoVeiculos.Id);

            return new Veiculos()
            {
                Modelo = "Fuscão",
                Marca = "Volkswagen",
                Placa = "AQD3794",
                Ano = "2002",
                Cor = "Azul",
                TipoCombustivel = "Gasolina",
                QuilometroPercorrido = "90000",
                CapacidadeTanque = "17",
                GrupoVeiculos = grupoVeiculos_encontrado,
            };
        }

        private GrupoVeiculos NovoGrupoVeiculos()
        {
            return new GrupoVeiculos()
            {
                Nome = "Grupo do Fuscão"
            };
        }

    }
}

