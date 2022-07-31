using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;
using Microsoft.EntityFrameworkCore;
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
        private IContextoPersistencia contextoPersistencia;

        public ServicoGrupoVeiculos(IRepositorioGrupoVeiculos repositorioGrupoVeiculos, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioGrupoVeiculos = repositorioGrupoVeiculos;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result<GrupoVeiculos> Inserir(GrupoVeiculos grupoVeiculos)
        {
            Log.Logger.Debug("Tentando inserir Grupo de Veículos...\r\n {@grupoVeiculos}", grupoVeiculos);

            Result resultadoValidacao = ValidarGrupoVeiculos(grupoVeiculos);

            if (resultadoValidacao.IsFailed)
                return Result.Fail(resultadoValidacao.Errors);

            try
            {
                repositorioGrupoVeiculos.Inserir(grupoVeiculos);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Grupo de Veículos {GrupoVeiculosId} inserido com sucesso", grupoVeiculos.Id);

                return Result.Ok(grupoVeiculos);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o grupo de veículos";

                Log.Logger.Error(ex, msgErro + "{GrupoVeiculosId}", grupoVeiculos.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<GrupoVeiculos> Editar(GrupoVeiculos grupoVeiculos)
        {
            Log.Logger.Debug("Tentando editar um grupo de veiculos...\r\n{@grupoVeiculos}", grupoVeiculos);

            Result resultadoValidacao = ValidarGrupoVeiculos(grupoVeiculos);

            if (resultadoValidacao.IsFailed)
                return Result.Fail(resultadoValidacao.Errors);

            try
            {
                repositorioGrupoVeiculos.Editar(grupoVeiculos);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Grupo de Veículos {GrupoVeiculosId} editado com sucesso", grupoVeiculos.Id);

                return Result.Ok(grupoVeiculos);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o grupo de veículos";

                Log.Logger.Error(ex, msgErro + "{GrupoVeiculosId}", grupoVeiculos.Id);

                return Result.Fail(msgErro);
            }

        }

        public Result Excluir(GrupoVeiculos grupoVeiculos)
        {
            Log.Logger.Debug("Tentando excluir grupo de veiculos... {@f}", grupoVeiculos);

            try
            {
                repositorioGrupoVeiculos.Excluir(grupoVeiculos);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Grupo de Veículos {GrupoVeiculosId} excluído com sucesso", grupoVeiculos.Id);

                return Result.Ok();
            }
            catch (NaoPodeExcluirEsteRegistroException ex)
            {
                string msgErro = $"O grupo de veículos {grupoVeiculos.Nome} está relacionado com uma entidade e não pode ser excluído";

                Log.Logger.Error(ex, msgErro + "{GrupoVeiculosId}", grupoVeiculos.Id);

                return Result.Fail(msgErro);
            }
            catch (DbUpdateException ex)
            {
                string msgErro = $"O grupoVeiculos {grupoVeiculos.Nome} está relacionado com uma entidade e não pode ser excluído";

                contextoPersistencia.RollBack();

                Log.Logger.Error(ex, msgErro + "{GrupoVeiculosId}", grupoVeiculos.Id);

                return Result.Fail(msgErro);
            }
            catch (InvalidOperationException ex)
            {
                string msgErro = $"O grupo de veículos {grupoVeiculos.Nome} está relacionado com uma entidade e não pode ser excluído";

                contextoPersistencia.RollBack();

                Log.Logger.Error(ex, msgErro + "{GrupoVeiculosId}", grupoVeiculos.Id);

                return Result.Fail(msgErro);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o grupo de veículos";

                Log.Logger.Error(ex, msgErro + "{GrupoVeiculosId}", grupoVeiculos.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<GrupoVeiculos>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioGrupoVeiculos.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os grupos de veículos";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<GrupoVeiculos> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioGrupoVeiculos.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o grupo de veículo";

                Log.Logger.Error(ex, msgErro + "{GrupoVeiculosId}", id);

                return Result.Fail(msgErro);
            }
        }

        private Result ValidarGrupoVeiculos(GrupoVeiculos grupoVeiculos)
        {
            var validador = new ValidadorGrupoVeiculos();

            var resultadoValidacao = validador.Validate(grupoVeiculos);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
                erros.Add(new Error(item.ErrorMessage));

            if (NomeDuplicado(grupoVeiculos))
                erros.Add(new Error("Nome duplicado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
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
