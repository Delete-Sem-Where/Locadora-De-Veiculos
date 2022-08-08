using Configs;
using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm.ModuloCliente;
using LocadoraDeVeiculos.Infra.Orm.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Orm.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.Orm.ModuloLocacao;
using LocadoraDeVeiculos.Infra.Orm.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.Orm.ModuloTaxa;
using LocadoraDeVeiculos.Infra.Orm.ModuloVeiculos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.Test.ModuloLocacao
{
    [TestClass]
    public class RepositorioLocacaoOrmTest : IntegrationTestBase
    {
        private RepositorioLocacaoOrm repositorio;
        private RepositorioClienteOrm repositorioCliente;
        private RepositorioCondutorOrm repositorioCondutor;
        private RepositorioGrupoVeiculosOrm repositorioGrupoVeiculos;
        private RepositorioVeiculosOrm repositorioVeiculos;
        private RepositorioPlanoCobrancaOrm repositorioPlanoCobranca;
        private RepositorioTaxaOrm repositorioTaxa;
        private LocadoraDeVeiculosDbContext dbContext;
        private ConfiguracaoAplicacao configuracao;

        public RepositorioLocacaoOrmTest()
        {
            configuracao = new ConfiguracaoAplicacao();
            dbContext = new LocadoraDeVeiculosDbContext(configuracao.ConnectionStrings);
            repositorio = new RepositorioLocacaoOrm(dbContext);
            repositorioCliente = new RepositorioClienteOrm(dbContext);
            repositorioCondutor = new RepositorioCondutorOrm(dbContext);
            repositorioGrupoVeiculos = new RepositorioGrupoVeiculosOrm(dbContext);
            repositorioVeiculos = new RepositorioVeiculosOrm(dbContext);
            repositorioPlanoCobranca = new RepositorioPlanoCobrancaOrm(dbContext);
            repositorioTaxa = new RepositorioTaxaOrm(dbContext);
        }

        [TestMethod]
        public void Deve_inserir_locacao()
        {
            var locacao = NovaLocacao();

            repositorio.Inserir(locacao);
            dbContext.GravarDados();

            var locacaoEncontrado = repositorio.SelecionarPorId(locacao.Id);

            locacaoEncontrado.Should().NotBeNull();
            locacaoEncontrado.Should().Be(locacao);
        }

        [TestMethod]
        public void Deve_editar_informacoes_locacao()
        {
            var locacao = NovaLocacao();

            repositorio.Inserir(locacao);
            dbContext.GravarDados();

            locacao.Nome = "nome alterado";
            repositorio.Editar(locacao);
            dbContext.GravarDados();

            var locacaoEncontrado = repositorio.SelecionarPorId(locacao.Id);

            locacaoEncontrado.Should().NotBeNull();
            locacaoEncontrado.Should().Be(locacao);
        }

        [TestMethod]
        public void Deve_excluir_locacao()
        {
            var locacao = NovaLocacao();

            repositorio.Inserir(locacao);
            dbContext.GravarDados();

            repositorio.Excluir(locacao);
            dbContext.GravarDados();

            repositorio.SelecionarPorId(locacao.Id)
                .Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_locacao_por_id()
        {
            var locacao = NovaLocacao();

            repositorio.Inserir(locacao);
            dbContext.GravarDados();

            var locacaoEncontrado = repositorio.SelecionarPorId(locacao.Id);

            locacaoEncontrado.Should().NotBeNull();
            locacaoEncontrado.Should().Be(locacao);
        }

        [TestMethod]
        public void Deve_selecionar_todas_locacoes()
        {
            var cliente = NovoCliente();

            repositorioCliente.Inserir(cliente);
            dbContext.GravarDados();

            var clienteEncontrado = repositorioCliente.SelecionarPorId(cliente.Id);

            var condutor = NovoCondutor();

            repositorioCondutor.Inserir(condutor);
            dbContext.GravarDados();

            var condutorEncontrado = repositorioCondutor.SelecionarPorId(condutor.Id);

            var novoGrupoVeiculos = NovoGrupoVeiculos();
            repositorioGrupoVeiculos.Inserir(novoGrupoVeiculos);
            dbContext.GravarDados();

            var grupoVeiculosEncontrado = repositorioGrupoVeiculos.SelecionarPorId(novoGrupoVeiculos.Id);

            var veiculo = NovoVeiculo();

            repositorioVeiculos.Inserir(veiculo);
            dbContext.GravarDados();

            var veiculoEncontrado = repositorioVeiculos.SelecionarPorId(veiculo.Id);

            var planoCobranca = NovoPlanoCobranca();
            repositorioPlanoCobranca.Inserir(planoCobranca);
            dbContext.GravarDados();

            var planoCobrancaEncontrado = repositorioPlanoCobranca.SelecionarPorId(planoCobranca.Id);

            var taxa = NovaTaxa();
            
            repositorioTaxa.Inserir(taxa);
            dbContext.GravarDados();

            var taxaEncontrada = repositorioTaxa.SelecionarPorId(taxa.Id);

            var c1 = new Locacao()
            {
                Cliente = clienteEncontrado,
                Condutor = condutorEncontrado,
                GrupoVeiculos = grupoVeiculosEncontrado,
                Veiculo = veiculoEncontrado,
                PlanoCobranca = planoCobrancaEncontrado,
                DataDevolucaoPrevista = DateTime.Now.AddDays(7),
            };

            repositorio.Inserir(c1);
            dbContext.GravarDados();

            var c2 = new Locacao()
            {
                
            };

            repositorio.Inserir(c2);
            dbContext.GravarDados();

            var c3 = new Locacao()
            {
                
            };

            repositorio.Inserir(c3);
            dbContext.GravarDados();

            var condutores = repositorio.SelecionarTodos();

            condutores.Count.Should().Be(3);

            condutores[0].Should().Be(c1);
            condutores[1].Should().Be(c2);
            condutores[2].Should().Be(c3);
        }

        private Locacao NovaLocacao()
        {
            var cliente = NovoCliente();

            repositorioCliente.Inserir(cliente);
            dbContext.GravarDados();

            var clienteEncontrado = repositorioCliente.SelecionarPorId(cliente.Id);

            var condutor = NovoCondutor();

            repositorioCondutor.Inserir(condutor);
            dbContext.GravarDados();

            var condutorEncontrado = repositorioCondutor.SelecionarPorId(condutor.Id);

            var novoGrupoVeiculos = NovoGrupoVeiculos();
            repositorioGrupoVeiculos.Inserir(novoGrupoVeiculos);
            dbContext.GravarDados();

            var grupoVeiculosEncontrado = repositorioGrupoVeiculos.SelecionarPorId(novoGrupoVeiculos.Id);

            var veiculo = NovoVeiculo();

            repositorioVeiculos.Inserir(veiculo);
            dbContext.GravarDados();

            var veiculoEncontrado = repositorioVeiculos.SelecionarPorId(veiculo.Id);

            var planoCobranca = NovoPlanoCobranca();
            repositorioPlanoCobranca.Inserir(planoCobranca);
            dbContext.GravarDados();

            var planoCobrancaEncontrado = repositorioPlanoCobranca.SelecionarPorId(planoCobranca.Id);

            var taxa = NovaTaxa();

            repositorioTaxa.Inserir(taxa);
            dbContext.GravarDados();

            var taxaEncontrada = repositorioTaxa.SelecionarPorId(taxa.Id);

            return new Locacao()
            {
                Cliente = clienteEncontrado,
                Condutor = condutorEncontrado,
                GrupoVeiculos = grupoVeiculosEncontrado,
                Veiculo = veiculoEncontrado,
                PlanoCobranca = planoCobrancaEncontrado,
                DataDevolucaoPrevista = DateTime.Now.AddDays(7),
            };
        }

        private Condutor NovoCondutor()
        {
            var cliente = NovoCliente();

            repositorioCliente.Inserir(cliente);
            dbContext.GravarDados();

            var cliente_encontrado = repositorioCliente.SelecionarPorId(cliente.Id);

            return new Condutor()
            {
                Nome = "nome",
                Email = "email@gmail.com",
                Telefone = "(13)1656-1235",
                Endereco = "endereco",
                CPF = "123.123.123-12",
                CNH = "12345678912",
                ValidadeCNH = DateTime.Now,
                Cliente = cliente_encontrado,
            };
        }

        private Cliente NovoCliente()
        {
            return new Cliente()
            {
                Nome = "nome",
                Email = "email@gmail.com",
                Telefone = "(13)1656-1235",
                Endereco = "endereco",
                Documento = "123.123.123-12",
                TipoCliente = TipoCliente.PessoaFisica,
            };
        }

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

        private Taxa NovaTaxa()
        {
            var t = new Taxa();
            t.Descricao = "Lavação do Veículo";
            t.Valor = 100;
            t.TipoCalculo = TipoCalculo.Fixo;

            return t;
        }
    }
}
