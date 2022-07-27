using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloCondutor
{
    public class ServicoCondutor
    {
        private IRepositorioCondutor repositorioCondutor;
        private IContextoPersistencia contextoPersistencia;

        public ServicoCondutor(IRepositorioCondutor repositorioCondutor, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioCondutor = repositorioCondutor;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result<Condutor> Inserir(Condutor condutor)
        {
            Log.Logger.Debug("Tentando inserir condutor... \r\n{@condutor}", condutor);

            Result resultadoValidacao = ValidarCondutor(condutor);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o Condutor {CondutorId} - {Motivo}",
                       condutor.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCondutor.Inserir(condutor);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Condutor {CondutorId} inserido com sucesso", condutor.Id);

                return Result.Ok(condutor);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o condutor";

                Log.Logger.Error(ex, msgErro + "{CondutorId}", condutor.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Condutor> Editar(Condutor condutor)
        {
            Log.Logger.Debug("Tentando editar condutor... \r\n{@condutor}", condutor);

            Result resultadoValidacao = ValidarCondutor(condutor);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o Condutor {CondutorId} - {Motivo}",
                       condutor.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCondutor.Editar(condutor);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Condutor {CondutorId} editado com sucesso", condutor.Id);

                return Result.Ok(condutor);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o condutor";

                Log.Logger.Error(ex, msgErro + "{CondutorId}", condutor.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Condutor condutor)
        {
            Log.Logger.Debug("Tentando excluir condutor... {@f}", condutor);

            try
            {
                repositorioCondutor.Excluir(condutor);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Condutor {CondutorId} excluído com sucesso", condutor.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o condutor";

                Log.Logger.Error(ex, msgErro + "{CondutorId}", condutor.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Condutor>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioCondutor.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os condutores";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Condutor> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioCondutor.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o condutor";

                Log.Logger.Error(ex, msgErro + "{CondutorId}", id);

                return Result.Fail(msgErro);
            }
        }

        private Result ValidarCondutor(Condutor condutor)
        {
            var validador = new ValidadorCondutor();

            var resultadoValidacao = validador.Validate(condutor);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
                erros.Add(new Error(item.ErrorMessage));

            if (NomeDuplicado(condutor))
                erros.Add(new Error("Nome duplicado"));

            if(CPFDuplicado(condutor))
                    erros.Add(new Error("CPF duplicado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool NomeDuplicado(Condutor condutor)
        {
            var condutorEncontrado = repositorioCondutor.SelecionarCondutorPorNome(condutor.Nome);

            return condutorEncontrado != null &&
                   condutorEncontrado.Nome == condutor.Nome &&
                   condutorEncontrado.Id != condutor.Id;
        }

        private bool CPFDuplicado(Condutor condutor)
        {
            var condutorEncontrado = repositorioCondutor.SelecionarCondutorPorCPF(condutor.CPF);

            return condutorEncontrado != null &&
                   condutorEncontrado.CPF == condutor.CPF &&
                   condutorEncontrado.Id != condutor.Id;
        }
    }
}
