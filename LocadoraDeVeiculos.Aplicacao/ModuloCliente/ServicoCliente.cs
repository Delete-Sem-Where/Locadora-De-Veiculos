using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloCliente;
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
        private RepositorioClienteEmBancoDados repositorioCliente;

        public ServicoCliente(RepositorioClienteEmBancoDados repositorioCliente)
        {
            this.repositorioCliente = repositorioCliente;
        }

        public ValidationResult Inserir(Cliente cliente)
        {
            Log.Logger.Debug("Tentando inserir cliente... \r\n{@cliente}", cliente);

            ValidationResult resultadoValidacao = ValidarCliente(cliente);

            if (resultadoValidacao.IsValid)
            {
                repositorioCliente.Inserir(cliente);
                Log.Logger.Debug("Cliente {ClienteNome} inserido com sucesso", cliente.Nome);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir Cliente {ClienteNome} - {Motivo}",
                        cliente.Nome, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        public ValidationResult Editar(Cliente cliente)
        {
            Log.Logger.Debug("Tentando inserir cliente... \r\n{@cliente}", cliente);

            ValidationResult resultadoValidacao = ValidarCliente(cliente);

            if (resultadoValidacao.IsValid)
            {
                repositorioCliente.Editar(cliente);
                Log.Logger.Debug("Cliente {ClienteNome} inserido com sucesso", cliente.Nome);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir Cliente {ClienteNome} - {Motivo}",
                        cliente.Nome, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        private ValidationResult ValidarCliente(Cliente cliente)
        {
            var validador = new ValidadorCliente();

            var resultadoValidacao = validador.Validate(cliente);

            if (NomeDuplicado(cliente))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome duplicado"));

            if (cliente.TipoCliente == TipoCliente.PessoaJuridica)
                if (CNPJDuplicado(cliente))
                {
                    resultadoValidacao.Errors.Add(new ValidationFailure("CNPJ", "CNPJ duplicado"));
                    return resultadoValidacao;
                }
            
            if(cliente.TipoCliente == TipoCliente.PessoaFisica)
                if (CPFDuplicado(cliente))
                {
                    resultadoValidacao.Errors.Add(new ValidationFailure("CPF", "CPF duplicado"));
                    return resultadoValidacao;
                }

            return resultadoValidacao;
        }

        private bool NomeDuplicado(Cliente cliente)
        {
            var clienteEncontrado = repositorioCliente.SelecionarClientePorNome(cliente.Nome);

            return clienteEncontrado != null &&
                   clienteEncontrado.Nome == cliente.Nome &&
                   clienteEncontrado.Id != cliente.Id;
        }

        private bool CNPJDuplicado(Cliente cliente)
        {
            var clienteEncontrado = repositorioCliente.SelecionarClientePorCNPJ(cliente.CNPJ);

            return clienteEncontrado != null &&
                   clienteEncontrado.CNPJ == cliente.CNPJ &&
                   clienteEncontrado.Id != cliente.Id;
        }

        private bool CPFDuplicado(Cliente cliente)
        {
            var clienteEncontrado = repositorioCliente.SelecionarClientePorCPF(cliente.CPF);

            return clienteEncontrado != null &&
                   clienteEncontrado.CPF == cliente.CPF &&
                   clienteEncontrado.Id != cliente.Id;
        }

    }
}
