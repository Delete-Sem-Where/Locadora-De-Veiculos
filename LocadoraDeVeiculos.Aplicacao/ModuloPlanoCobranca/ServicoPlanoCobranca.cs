using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloPlanoCobranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloPlanoCobranca
{
    public class ServicoPlanoCobranca
    {
        private RepositorioPlanoCobrancaEmBancoDados repositorioPlanoCobranca;

        public ServicoPlanoCobranca(RepositorioPlanoCobrancaEmBancoDados repositorioPlanoCobranca)
        {
            this.repositorioPlanoCobranca = repositorioPlanoCobranca;
        }

        public ValidationResult Inserir(PlanoCobranca planoCobranca)
        {
            ValidationResult resultadoValidacao = Validar(planoCobranca);

            if (resultadoValidacao.IsValid)
                repositorioPlanoCobranca.Inserir(planoCobranca);

            return resultadoValidacao;
        }

        public ValidationResult Editar(PlanoCobranca planoCobranca)
        {
            ValidationResult resultadoValidacao = Validar(planoCobranca);

            if (resultadoValidacao.IsValid)
                repositorioPlanoCobranca.Editar(planoCobranca);

            return resultadoValidacao;
        }

        private ValidationResult Validar(PlanoCobranca planoCobranca)
        {
            var validador = new ValidadorPlanoCobranca();

            var resultadoValidacao = validador.Validate(planoCobranca);

            if (resultadoValidacao.IsValid)
                if (GrupoVeiculos_do_planoCobranca_Duplicado(planoCobranca) && ModalidadeDuplicada(planoCobranca))
                    resultadoValidacao.Errors.Add(new ValidationFailure("Plano de Cobrança", "Plano de Cobrança para esta Modalidade já cadastrado"));

            return resultadoValidacao;
        }
        //aqui linha 56 gravar sem grupo
        private bool GrupoVeiculos_do_planoCobranca_Duplicado(PlanoCobranca planoCobranca)
        {
            var planoEncontrado = repositorioPlanoCobranca.SelecionarPlanoPorGrupo(planoCobranca.GrupoVeiculos.Id);

            return planoEncontrado != null &&
                   planoEncontrado.GrupoVeiculos.Id == planoCobranca.GrupoVeiculos.Id &&
                   planoEncontrado.Id != planoCobranca.Id;
        }

        private bool ModalidadeDuplicada(PlanoCobranca planoCobranca)
        {
            var planoEncontrado = repositorioPlanoCobranca.SelecionarPlanoPorTipoPlano(planoCobranca.ModalidadePlanoCobranca);

            return planoEncontrado != null &&
                   planoEncontrado.ModalidadePlanoCobranca == planoCobranca.ModalidadePlanoCobranca &&
                   planoEncontrado.Id != planoCobranca.Id;
        }
    }
}