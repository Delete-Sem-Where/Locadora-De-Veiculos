using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloGrupoVeiculos
{
    public class ServicoGrupoVeiculos
    {
        private IRepositorioGrupoVeiculos repositorioGrupoVeiculos;

        public ServicoGrupoVeiculos(IRepositorioGrupoVeiculos repositorioGrupoVeiculos)
        {
            this.repositorioGrupoVeiculos = repositorioGrupoVeiculos;
        }

        public ValidationResult Inserir(GrupoVeiculos grupoVeiculos)
        {
            Log.Logger.Debug("Tentando inserir Grupo de Veículos...\r\n {@grupoVeiculos}", grupoVeiculos);

            ValidationResult resultadoValidacao = Validar(grupoVeiculos);

            if (resultadoValidacao.IsValid)
                repositorioGrupoVeiculos.Inserir(grupoVeiculos);

            else
                foreach (var erro in resultadoValidacao.Errors)
                    Log.Logger.Warning("Falha na inserção de Grupo de Veículos {GrupoVeiculos} - {Motivo}",
                    grupoVeiculos.Nome, erro.ErrorMessage);


            return resultadoValidacao;
        }

        public ValidationResult Editar(GrupoVeiculos grupoVeiculos)
        {
            Log.Logger.Debug("Tentando editar um grupo de veiculos...\r\n{@grupoVeiculos}", grupoVeiculos);

            ValidationResult resultadoValidacao = Validar(grupoVeiculos);

            if (resultadoValidacao.IsValid)
                repositorioGrupoVeiculos.Editar(grupoVeiculos);

            else
                foreach (var erro in resultadoValidacao.Errors)
                    Log.Logger.Warning("Falha ao tentar editar grupo de veículos {grupoVeiculos} - {Motivo}",
                     grupoVeiculos.Nome, erro.ErrorMessage);

            return resultadoValidacao;
        }

        private ValidationResult Validar(GrupoVeiculos grupoVeiculos)
        {
            var validador = new ValidadorGrupoVeiculos();

            var resultadoValidacao = validador.Validate(grupoVeiculos);

            if (NomeDuplicado(grupoVeiculos))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome duplicado"));

            return resultadoValidacao;
        }

        private bool NomeDuplicado(GrupoVeiculos grupoVeiculos)
        {
            var grupoVeiculosEncontrado = repositorioGrupoVeiculos.SelecionarGrupoVeiculosPorNome(grupoVeiculos.Nome);

            return grupoVeiculosEncontrado != null &&
                   grupoVeiculosEncontrado.Nome == grupoVeiculos.Nome &&
                   grupoVeiculosEncontrado.Id != grupoVeiculos.Id;
        }
    }
}
