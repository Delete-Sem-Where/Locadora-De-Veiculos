using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloPlanoCobranca;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloPlanoCobranca
{
    public class ServicoPlanoCobranca
    {
        private IRepositorioPlanoCobranca repositorioPlanoCobranca;
        private IContextoPersistencia contextoPersistencia;


        public ServicoPlanoCobranca(IRepositorioPlanoCobranca repositorioPlanoCobranca, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioPlanoCobranca = repositorioPlanoCobranca;
            this.contextoPersistencia = contextoPersistencia;
        }


        public Result<PlanoCobranca> Inserir(PlanoCobranca planoCobranca)
        {
            Log.Logger.Debug("Tentando inserir plano de cobrança... \r\n{@planoCobranca}", planoCobranca);

            Result resultadoValidacao = ValidarPlanoCobranca(planoCobranca);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o Plano de Cobrança {PlanoCobrancaId} - {Motivo}",
                       planoCobranca.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioPlanoCobranca.Inserir(planoCobranca);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Plano de Cobrança {PlanoCobrancaId} inserido com sucesso", planoCobranca.Id);

                return Result.Ok(planoCobranca);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o plano de cobrança";

                Log.Logger.Error(ex, msgErro + "{PlanoCobrancaId}", planoCobranca.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<PlanoCobranca> Editar(PlanoCobranca planoCobranca)
        {
            Log.Logger.Debug("Tentando editar plano de cobrança... \r\n{@planoCobranca}", planoCobranca);

            Result resultadoValidacao = ValidarPlanoCobranca(planoCobranca);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o Plano de Cobrança {PlanoCobrancaId} - {Motivo}",
                       planoCobranca.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioPlanoCobranca.Editar(planoCobranca);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Plano de Cobrança {PlanoCobrancaId} editado com sucesso", planoCobranca.Id);

                return Result.Ok(planoCobranca);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o plano de cobrança";

                Log.Logger.Error(ex, msgErro + "{PlanoCobrancaModalidade}, {PlanoCobrancaId}", planoCobranca.ModalidadePlanoCobranca, planoCobranca.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(PlanoCobranca planoCobranca)
        {
            Log.Logger.Debug("Tentando excluir plano de cobrança... {@f}", planoCobranca);

            try
            {
                repositorioPlanoCobranca.Excluir(planoCobranca);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Plano de Cobrança {PlanoCobrancaId} excluído com sucesso", planoCobranca.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o plano de cobrança";

                Log.Logger.Error(ex, msgErro + "{PlanoCobrancaId}", planoCobranca.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<PlanoCobranca>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioPlanoCobranca.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os planos de cobrança";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<PlanoCobranca> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioPlanoCobranca.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o plano de cobrança";

                Log.Logger.Error(ex, msgErro + "{PlanoCobrancaId}", id);

                return Result.Fail(msgErro);
            }
        }

        private Result ValidarPlanoCobranca(PlanoCobranca planoCobranca)
        {
            var validador = new ValidadorPlanoCobranca();

            var resultadoValidacao = validador.Validate(planoCobranca);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
                erros.Add(new Error(item.ErrorMessage));

            if (GrupoVeiculos_do_planoCobranca_Duplicado(planoCobranca))
                erros.Add(new Error("Modalidade duplicada para o Grupo de Veículos selecionado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool GrupoVeiculos_do_planoCobranca_Duplicado(PlanoCobranca planoCobranca)
        {
            var planoEncontrado = repositorioPlanoCobranca.SelecionarPlanoPorGrupo_E_Modalidade(planoCobranca.GrupoVeiculos.Id, planoCobranca.ModalidadePlanoCobranca);

            return planoEncontrado != null &&
                   planoEncontrado.Id != planoCobranca.Id;
        }
    }
}