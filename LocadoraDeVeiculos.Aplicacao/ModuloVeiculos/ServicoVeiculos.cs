using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao
{
    public class ServicoVeiculos
    {
        private IRepositorioVeiculos repositorioVeiculos;

        public ServicoVeiculos(IRepositorioVeiculos repositorioVeiculos)
        {
            this.repositorioVeiculos = repositorioVeiculos;
        }

        public ValidationResult Inserir(Veiculos veiculo)
        {
            Log.Logger.Debug("Tentando inserir veículo... \r\n{@veiculo}", veiculo);

            ValidationResult resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsValid)
            {
                repositorioVeiculos.Inserir(veiculo);
                Log.Logger.Debug("Veículo {VeículoModelo} inserido com sucesso", veiculo.Modelo);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o Veículo {VeículoModelo} - {Motivo}",
                        veiculo.Modelo, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        public ValidationResult Editar(Veiculos veiculo)
        {
            Log.Logger.Debug("Tentando editar veículo... \r\n{@veiculo}", veiculo);

            ValidationResult resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsValid)
            {
                repositorioVeiculos.Inserir(veiculo);
                Log.Logger.Debug("Veículo {VeiculoModelo} editado com sucesso", veiculo.Modelo);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar veículo {VeiculoModelo} - {Motivo}",
                        veiculo.Modelo, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        private ValidationResult Validar(Veiculos veiculo)
        {
            var validador = new ValidadorVeiculos();

            var resultadoValidacao = validador.Validate(veiculo);

            if (PlacaDuplicada(veiculo))
                resultadoValidacao.Errors.Add(new ValidationFailure("Placa", "Placa duplicada"));

            return resultadoValidacao;
        }

        private bool PlacaDuplicada(Veiculos veiculos)
        {
            var veiculoEncontrado = repositorioVeiculos.SelecionarVeiculosPorPlaca(veiculos.Placa);

            return veiculoEncontrado != null &&
                   veiculoEncontrado.Placa == veiculos.Placa &&
                   veiculoEncontrado.Id != veiculos.Id;
        }
    }
}
