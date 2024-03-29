﻿using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloCliente;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloCliente
{
    public class ServicoCliente
    {
        private IRepositorioCliente repositorioCliente;
        private IContextoPersistencia contextoPersistencia;

        public ServicoCliente(IRepositorioCliente repositorioCliente, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioCliente = repositorioCliente;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result<Cliente> Inserir(Cliente cliente)
        {
            Log.Logger.Debug("Tentando inserir cliente... \r\n{@cliente}", cliente);
            
            Result resultadoValidacao = ValidarCliente(cliente);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o Cliente {ClienteId} - {Motivo}",
                       cliente.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCliente.Inserir(cliente);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Cliente {ClienteId} inserido com sucesso", cliente.Id);

                return Result.Ok(cliente);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o cliente";

                Log.Logger.Error(ex, msgErro + "{ClienteId}", cliente.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Cliente> Editar(Cliente cliente)
        {
            Log.Logger.Debug("Tentando editar cliente... \r\n{@cliente}", cliente);

            Result resultadoValidacao = ValidarCliente(cliente);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o Cliente {ClienteId} - {Motivo}",
                       cliente.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCliente.Editar(cliente);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Cliente {ClienteId} editado com sucesso", cliente.Id);

                return Result.Ok(cliente);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o cliente";

                Log.Logger.Error(ex, msgErro + "{ClienteId}", cliente.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Cliente cliente)
        {
            Log.Logger.Debug("Tentando excluir cliente... {@f}", cliente);

            try
            {
                repositorioCliente.Excluir(cliente);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Cliente {ClienteId} excluído com sucesso", cliente.Id);

                return Result.Ok();
            }
            catch (NaoPodeExcluirEsteRegistroException ex)
            {
                string msgErro = $"O cliente {cliente.Nome} está relacionado com um condutor e não pode ser excluído";

                Log.Logger.Error(ex, msgErro + "{ClienteId}", cliente.Id);

                return Result.Fail(msgErro);
            }
            catch (DbUpdateException ex)
            {
                string msgErro = $"O cliente {cliente.Nome} está relacionado com um condutor e não pode ser excluído";

                contextoPersistencia.RollBack();

                Log.Logger.Error(ex, msgErro + "{ClienteId}", cliente.Id);

                return Result.Fail(msgErro);
            }
            catch (InvalidOperationException ex)
            {
                string msgErro = $"O cliente {cliente.Nome} está relacionado com um condutor e não pode ser excluído";

                contextoPersistencia.RollBack();

                Log.Logger.Error(ex, msgErro + "{ClienteId}", cliente.Id);

                return Result.Fail(msgErro);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o cliente";

                Log.Logger.Error(ex, msgErro + "{ClienteId}", cliente.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Cliente>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioCliente.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os clientes";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Cliente> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioCliente.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o cliente";

                Log.Logger.Error(ex, msgErro + "{ClienteId}", id);

                return Result.Fail(msgErro);
            }
        }

        private Result ValidarCliente(Cliente cliente)
        {
            var validador = new ValidadorCliente();

            var resultadoValidacao = validador.Validate(cliente);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
                erros.Add(new Error(item.ErrorMessage));

            if (NomeDuplicado(cliente))
                erros.Add(new Error("Nome duplicado"));

            if (cliente.TipoCliente == TipoCliente.PessoaJuridica)
                if (DocumentoDuplicado(cliente))
                erros.Add(new Error("CNPJ duplicado"));

            if (cliente.TipoCliente == TipoCliente.PessoaFisica)
                if (DocumentoDuplicado(cliente))
                    erros.Add(new Error("CPF duplicado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool NomeDuplicado(Cliente cliente)
        {
            var clienteEncontrado = repositorioCliente.SelecionarClientePorNome(cliente.Nome);

            return clienteEncontrado != null &&
                   clienteEncontrado.Nome == cliente.Nome &&
                   clienteEncontrado.Id != cliente.Id;
        }

        private bool DocumentoDuplicado(Cliente cliente)
        {
            var clienteEncontrado = repositorioCliente.SelecionarClientePorDocumento(cliente.Documento);

            return clienteEncontrado != null &&
                   clienteEncontrado.Documento == cliente.Documento &&
                   clienteEncontrado.Id != cliente.Id;
        }

    }
}
