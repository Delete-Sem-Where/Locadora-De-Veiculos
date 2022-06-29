using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloGruposVeiculos;
using LocadoraDeVeiculos.Infra.BancoDados.Test.Compartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDados.Test.ModuloGrupoVeiculos
{
    [TestClass]
    public class RepositorioGrupoVeiculosTest : IntegrationTestBase
    {
        private RepositorioGrupoVeiculosEmBancoDados repositorioGrupoVeiculos;
        
        public RepositorioGrupoVeiculosTest()
        {
            repositorioGrupoVeiculos = new RepositorioGrupoVeiculosEmBancoDados();
        }

        [TestMethod]
        public void Deve_inserir_grupo_de_veiculos()
        {
            var grupoVeiculos = NovoGrupoVeiculos();

            repositorioGrupoVeiculos.Inserir(grupoVeiculos);

            var grupoVeiculosEncontrado = repositorioGrupoVeiculos.SelecionarPorId(grupoVeiculos.Id);

            grupoVeiculosEncontrado.Should().NotBeNull();
            grupoVeiculosEncontrado.Should().Be(grupoVeiculos);
        }

        [TestMethod]
        public void Deve_editar_grupo_de_veiculos()
        {
            var grupoVeiculos = NovoGrupoVeiculos();

            repositorioGrupoVeiculos.Inserir(grupoVeiculos);

            grupoVeiculos.Nome = "Nome alterado";
            repositorioGrupoVeiculos.Editar(grupoVeiculos);

            var grupoVeiculosEncontrado = repositorioGrupoVeiculos.SelecionarPorId(grupoVeiculos.Id);

            grupoVeiculosEncontrado.Should().NotBeNull();
            grupoVeiculosEncontrado.Should().Be(grupoVeiculos);
        }
        
        [TestMethod]
        public void Deve_excluir_grupo_de_veiculos()
        {
            var grupoVeiculos = NovoGrupoVeiculos();

            repositorioGrupoVeiculos.Inserir(grupoVeiculos);

            repositorioGrupoVeiculos.Excluir(grupoVeiculos);

            repositorioGrupoVeiculos.SelecionarPorId(grupoVeiculos.Id)
                .Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_grupo_de_veiculos_por_id()
        {
            var grupoVeiculos = NovoGrupoVeiculos();

            repositorioGrupoVeiculos.Inserir(grupoVeiculos);

            var grupoVeiculosEncontrado = repositorioGrupoVeiculos.SelecionarPorId(grupoVeiculos.Id);

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

            repositorioGrupoVeiculos.Inserir(gv1);

            var gv2 = new GrupoVeiculos()
            {
                Nome = "Nome dois",
            };

            repositorioGrupoVeiculos.Inserir(gv2);

            var gv3 = new GrupoVeiculos()
            {
                Nome = "Nome tres",
            };

            repositorioGrupoVeiculos.Inserir(gv3);

            var grupos_veiculos = repositorioGrupoVeiculos.SelecionarTodos();

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
