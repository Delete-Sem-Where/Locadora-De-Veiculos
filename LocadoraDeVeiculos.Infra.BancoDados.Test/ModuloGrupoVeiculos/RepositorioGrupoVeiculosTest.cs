using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.BancoDados.Test.Compartilhado;
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
        private RepositorioGrupoVeiculosEmBancoDados;
          
        public RepositorioGrupoVeiculosEmBancoDados repositorioGrupoVeiculos()
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


    }
}
