using Configs;
using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.Orm.ModuloVeiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.Test.ModuloVeiculos
{
    [TestClass]
    public class RepositorioVeiculosOrmTest : IntegrationTestBase
    {
        private RepositorioVeiculosOrm repositorio;
        private RepositorioGrupoVeiculosOrm repositorioGrupoVeiculos;
        private LocadoraDeVeiculosDbContext dbContext;
        private ConfiguracaoAplicacao configuracao;

        public RepositorioVeiculosOrmTest()
        {
            configuracao = new ConfiguracaoAplicacao();
            dbContext = new LocadoraDeVeiculosDbContext(configuracao.ConnectionStrings);
            repositorio = new RepositorioVeiculosOrm(dbContext);
            repositorioGrupoVeiculos = new RepositorioGrupoVeiculosOrm(dbContext);
        }

        [TestMethod]
        public void Deve_inserir_veiculo()
        {
            var veiculo = NovoVeiculo();

            repositorio.Inserir(veiculo);
            dbContext.GravarDados();

            var veiculoEncontrado = repositorio.SelecionarPorId(veiculo.Id);

            veiculoEncontrado.Should().NotBeNull();
            veiculoEncontrado.Should().Be(veiculo);
        }

        [TestMethod]
        public void Deve_editar_informacoes_veiculo()
        {
            var veiculo = NovoVeiculo();

            repositorio.Inserir(veiculo);
            dbContext.GravarDados();

            veiculo.Modelo = "Modelo alterado";
            repositorio.Editar(veiculo);
            dbContext.GravarDados();

            var veiculoEncontrado = repositorio.SelecionarPorId(veiculo.Id);

            veiculoEncontrado.Should().NotBeNull();
            veiculoEncontrado.Should().Be(veiculo);
        }

        [TestMethod]
        public void Deve_excluir_veiculo()
        {
            var veiculo = NovoVeiculo();

            repositorio.Inserir(veiculo);
            dbContext.GravarDados();

            repositorio.Excluir(veiculo);
            dbContext.GravarDados();

            repositorio.SelecionarPorId(veiculo.Id)
                .Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_veiculos_por_id()
        {
            var veiculo = NovoVeiculo();

            repositorio.Inserir(veiculo);
            dbContext.GravarDados();

            var veiculoEncontrado = repositorio.SelecionarPorId(veiculo.Id);

            veiculoEncontrado.Should().NotBeNull();
            veiculoEncontrado.Should().Be(veiculo);
        }

        [TestMethod]
        public void Deve_selecionar_todos_veiculos()
        {
            var grupoVeiculos = NovoGrupoVeiculos();

            repositorioGrupoVeiculos.Inserir(grupoVeiculos);
            dbContext.GravarDados();

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

            repositorio.Inserir(v1);
            dbContext.GravarDados();

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

            repositorio.Inserir(v2);
            dbContext.GravarDados();

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

            repositorio.Inserir(v3);
            dbContext.GravarDados();

            var veiculos = repositorio.SelecionarTodos();

            veiculos.Count.Should().Be(3);

            veiculos[0].Should().Be(v1);
            veiculos[1].Should().Be(v2);
            veiculos[2].Should().Be(v3);
        }

        private Veiculos NovoVeiculo()
        {
            var grupoVeiculos = NovoGrupoVeiculos();

            repositorioGrupoVeiculos.Inserir(grupoVeiculos);
            dbContext.GravarDados();

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
