using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloTaxas
{
    public class ServicoTaxa
    {
        private IRepositorioTaxa repositorioTaxa;
        private IContextoPersistencia contextoPersistencia;


        public ServicoTaxa(IRepositorioTaxa repositorioTaxa, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioTaxa = repositorioTaxa;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result<Taxa> Inserir(Taxa taxa)
        {
            Log.Logger.Debug("Tentando inserir taxa... \r\n{@taxa}", taxa);

            Result resultadoValidacao = ValidarTaxa(taxa);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir Taxa {TaxaDescricao} - {Motivo}",
                        taxa.Descricao, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioTaxa.Inserir(taxa);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Taxa {TaxaDescricao} inserida com sucesso", taxa.Descricao);

                return Result.Ok(taxa);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir a taxa";

                Log.Logger.Error(ex, msgErro + "{TaxaDescricao}, Id: {TaxaId}", taxa.Descricao, taxa.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Taxa> Editar(Taxa taxa)
        {
            Log.Logger.Debug("Tentando editar taxa... \r\n{@taxa}", taxa);

            Result resultadoValidacao = ValidarTaxa(taxa);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar Taxa {TaxaDescricao} - {Motivo}",
                        taxa.Descricao, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioTaxa.Editar(taxa);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Taxa {TaxaDescricao} editada com sucesso", taxa.Descricao);

                return Result.Ok(taxa);
            }

            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir a taxa";

                Log.Logger.Error(ex, msgErro + "{TaxaDescricao}, {TaxaId}", taxa.Descricao, taxa.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Taxa taxa)
        {
            Log.Logger.Debug("Tentando excluir taxa... {@f}", taxa);

            try
            {
                repositorioTaxa.Excluir(taxa);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Taxa {TaxaDescricao} excluída com sucesso", taxa.Descricao);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir a taxa";

                Log.Logger.Error(ex, msgErro + "{TaxaDescricao}, {TaxaId}", taxa.Descricao, taxa.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Taxa>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioTaxa.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todas as taxas";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Taxa> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioTaxa.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar a taxa";

                Log.Logger.Error(ex, msgErro + "{TaxaId}", id);

                return Result.Fail(msgErro);
            }
        }


        //corrigir
        private Result ValidarTaxa(Taxa taxa)
        {
            var validador = new ValidadorTaxa();

            var resultadoValidacao = validador.Validate(taxa);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
                erros.Add(new Error(item.ErrorMessage));

            if (NomeDuplicado(taxa))
                erros.Add(new Error("Descrição duplicada"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool NomeDuplicado(Taxa taxa)
        {
            var taxaEncontrado = repositorioTaxa.SelecionarTaxaPorDescricao(taxa.Descricao);

            return taxaEncontrado != null &&
                   taxaEncontrado.Descricao == taxa.Descricao &&
                   taxaEncontrado.Id != taxa.Id;
        }
    }
}
