using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
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

        public ServicoTaxa(IRepositorioTaxa repositorioTaxa)
        {
            this.repositorioTaxa = repositorioTaxa;
        }

        public ValidationResult Inserir(Taxa taxa)
        {
            ValidationResult resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
                repositorioTaxa.Inserir(taxa);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Taxa taxa)
        {
            ValidationResult resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
                repositorioTaxa.Editar(taxa);

            return resultadoValidacao;
        }

        private ValidationResult Validar(Taxa taxa)
        {
            var validador = new ValidadorTaxa();

            var resultadoValidacao = validador.Validate(taxa);

            if (NomeDuplicado(taxa))
                resultadoValidacao.Errors.Add(new ValidationFailure("Descricao", "Descricao duplicada"));

            return resultadoValidacao;
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
