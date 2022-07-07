using FluentValidation.Results;
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

        public ServicoTaxa(IRepositorioTaxa repositorioTaxa)
        {
            this.repositorioTaxa = repositorioTaxa;
        }

        public ValidationResult Inserir(Taxa taxa)
        {
            Log.Logger.Debug("Tentando inserir taxa... \r\n{@taxa}", taxa);

            ValidationResult resultadoValidacao = Validar(taxa);            

            if (resultadoValidacao.IsValid)
            {
                repositorioTaxa.Inserir(taxa);
                Log.Logger.Debug("Taxa {TaxaDescricao} inserida com sucesso", taxa.Descricao);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir Taxa {TaxaDescricao} - {Motivo}",
                        taxa.Descricao, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        public ValidationResult Editar(Taxa taxa)
        {
            ValidationResult resultadoValidacao = Validar(taxa);
                       
            if (resultadoValidacao.IsValid)
            {
                repositorioTaxa.Editar(taxa);
                Log.Logger.Debug("Taxa {TaxaDescricao} editada com sucesso", taxa.Descricao);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar Taxa {TaxaDescricao} - {Motivo}",
                        taxa.Descricao, erro.ErrorMessage);
                }
            }

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
