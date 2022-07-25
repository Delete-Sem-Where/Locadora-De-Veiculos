using FluentValidation.Results;
using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using Serilog;

namespace LocadoraDeVeiculos.Aplicacao.ModuloVeiculos
{
    public class ServicoVeiculos
    {
        private IRepositorioVeiculos repositorioVeiculos;

        public ServicoVeiculos(IRepositorioVeiculos repositorioVeiculos)
        {
            this.repositorioVeiculos = repositorioVeiculos;
        }

        public Result<Veiculos> Inserir(Veiculos veiculo)
        {
            Log.Logger.Debug("Tentando inserir veículo... \r\n{@veiculo}", veiculo);

            Result resultadoValidacao = ValidarVeiculo(veiculo);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    repositorioVeiculos.Inserir(veiculo);
                    Log.Logger.Debug("Falha ao tentar inserir o Veículo {VeículoModelo} - {Motivo}", veiculo.Modelo, erro.Message);
                }
                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioVeiculos.Inserir(veiculo);

                Log.Logger.Information("Veículo {VeiculoId} inserido com sucesso", veiculo.Id);

                return Result.Ok(veiculo);

            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o veículo";

                Log.Logger.Error(ex, msgErro + "{VeículoId}", veiculo.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Veiculos> Editar(Veiculos veiculo)
        {
            Log.Logger.Debug("Tentando editar veículo... \r\n{@veiculo}", veiculo);

            Result resultadoValidacao = ValidarVeiculo(veiculo);


            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar veículo {VeiculoId} - {Motivo}",
                        veiculo.Id, erro.Message);
                }
                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioVeiculos.Editar(veiculo);

                Log.Logger.Information("Veículo {VeiculoId} editado com sucesso", veiculo.Id);

                return Result.Ok(veiculo);
            }

            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o veículo";

                Log.Logger.Error(ex, msgErro + "{VeiculoId}", veiculo.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Veiculos veiculos)
        {
            Log.Logger.Debug("Tentando excluir veiculo... {@f}", veiculos);

            try
            {
                repositorioVeiculos.Excluir(veiculos);

                Log.Logger.Information("Veículo {VeiculosId} excluído com sucesso", veiculos.Id);
                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o veículo";

                Log.Logger.Error(ex, msgErro + "{VeiculosId}", veiculos.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Veiculos>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioVeiculos.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os veículos";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Veiculos> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioVeiculos.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o veículo";
                Log.Logger.Error(ex, msgErro + "{VeiculoId}", id);

                return Result.Fail(msgErro);
            }
        }
        private Result<Veiculos> ValidarVeiculo(Veiculos veiculo)
        {
            var validador = new ValidadorVeiculos();

            var resultadoValidacao = validador.Validate(veiculo);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
                erros.Add(new Error(item.ErrorMessage));

            if (PlacaDuplicada(veiculo))
                erros.Add(new Error("Placa duplicado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
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
