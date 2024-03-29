﻿using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloLocacao
{
    public class ServicoLocacao
    {
        private IRepositorioLocacao repositorioLocacao;
        private IContextoPersistencia contextoPersistencia;

        public ServicoLocacao(IRepositorioLocacao repositorioLocacao, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioLocacao = repositorioLocacao;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result<Locacao> Inserir(Locacao locacao)
        {
            Log.Logger.Debug("Tentando inserir locacao... \r\n{@locacao}", locacao);

            Result resultadoValidacao = ValidarLocacao(locacao);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o Locacao {LocacaoId} - {Motivo}",
                       locacao.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioLocacao.Inserir(locacao);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Locacao {LocacaoId} inserido com sucesso", locacao.Id);

                return Result.Ok(locacao);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o locacao";

                Log.Logger.Error(ex, msgErro + "{LocacaoId}", locacao.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Locacao> Editar(Locacao locacao)
        {
            Log.Logger.Debug("Tentando editar locacao... \r\n{@locacao}", locacao);

            Result resultadoValidacao = ValidarLocacao(locacao);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o Locacao {LocacaoId} - {Motivo}",
                       locacao.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioLocacao.Editar(locacao);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Locacao {LocacaoId} editado com sucesso", locacao.Id);

                return Result.Ok(locacao);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o locacao";

                Log.Logger.Error(ex, msgErro + "{LocacaoId}", locacao.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Locacao locacao)
        {
            Log.Logger.Debug("Tentando excluir locacao... {@f}", locacao);

            try
            {
                repositorioLocacao.Excluir(locacao);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Locacao {LocacaoId} excluído com sucesso", locacao.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o locacao";

                Log.Logger.Error(ex, msgErro + "{LocacaoId}", locacao.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Locacao> RegistrarDevolucao(Locacao locacao)
        {
            Log.Logger.Debug("Tentando registrar devolucao... \r\n{@locacao}", locacao);

            Result resultadoValidacao = ValidarLocacao(locacao);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar registrar devolucao {LocacaoId} - {Motivo}",
                       locacao.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioLocacao.Editar(locacao);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Locacao {LocacaoId} devolvida com sucesso", locacao.Id);

                return Result.Ok(locacao);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar devolver a locacao";

                Log.Logger.Error(ex, msgErro + "{LocacaoId}", locacao.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Locacao>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioLocacao.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os locacaoes";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Locacao> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioLocacao.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o locacao";

                Log.Logger.Error(ex, msgErro + "{LocacaoId}", id);

                return Result.Fail(msgErro);
            }
        }

        private Result ValidarLocacao(Locacao locacao)
        {
            var validador = new ValidadorLocacao();

            var resultadoValidacao = validador.Validate(locacao);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
                erros.Add(new Error(item.ErrorMessage));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

    }
}
