using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloVeiculos
{
    public class ServicoVeiculos
    {
        private IRepositorioVeiculos repositorioVeiculos;

        public ServicoVeiculos(IRepositorioVeiculos repositorioVeiculos)
        {
            this.repositorioVeiculos = repositorioVeiculos;
        }

        public ValidationResult Inserir(Veiculos veiculos)
        {
            ValidationResult resultadoValidacao = Validar(veiculos);

            if (resultadoValidacao.IsValid)
                repositorioVeiculos.Inserir(veiculos);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Veiculos veiculos)
        {
            ValidationResult resultadoValidacao = Validar(veiculos);

            if (resultadoValidacao.IsValid)
                repositorioVeiculos.Editar(veiculos);

            return resultadoValidacao;
        }

        private ValidationResult Validar(Veiculos veiculos)
        {
            var validador = new ValidadorVeiculos();

            var resultadoValidacao = validador.Validate(veiculos);

            if (PlacaDuplicada(veiculos))
                resultadoValidacao.Errors.Add(new ValidationFailure("Placa", "Placa duplicada!!"));

            return resultadoValidacao;
        }

        private bool PlacaDuplicada(Veiculos veiculos)
        {
            var veiculosEncontrado = repositorioVeiculos.SelecionarVeiculosPorPlaca(veiculos.Placa);

            return veiculosEncontrado != null &&
                   veiculosEncontrado.Placa == veiculos.Placa &&
                   veiculosEncontrado.Id != veiculos.Id;
        }
    }
}
