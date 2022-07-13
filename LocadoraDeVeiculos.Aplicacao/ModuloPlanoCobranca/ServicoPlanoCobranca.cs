using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloPlanoCobranca;
using Serilog;
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
            Log.Logger.Debug("Tentando inserir Plano de Cobrança... \r\n{@grupoVeiculos}", planoCobranca.GrupoVeiculos.Nome);

            ValidationResult resultadoValidacao = Validar(planoCobranca);


            if (resultadoValidacao.IsValid)
            {
                repositorioPlanoCobranca.Inserir(planoCobranca);
                Log.Logger.Debug("Plano de Cobrança para o Grupo {GrupoVeiculos} inserido com sucesso", planoCobranca.GrupoVeiculos.Nome);

            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir Plano de Cobrança para o Grupo {GrupoVeiculos} - {Motivo}",
                        planoCobranca.GrupoVeiculos.Nome, erro.ErrorMessage);
                }
            }
            return resultadoValidacao;
        }

        public ValidationResult Editar(PlanoCobranca planoCobranca)
        {
            Log.Logger.Debug("Tentando editar Plano de Cobrança... \r\n{@planoCobranca}", planoCobranca.GrupoVeiculos.Nome);

            ValidationResult resultadoValidacao = Validar(planoCobranca);

            if (resultadoValidacao.IsValid)
            {
                    repositorioPlanoCobranca.Editar(planoCobranca);
                    Log.Logger.Debug("Plano de Cobrança para o Grupo {GrupoVeiculos} editado com sucesso", planoCobranca.GrupoVeiculos.Nome);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar Plano de Cobrança para o Grupo {GrupoVeiculos} - {Motivo}",
                        planoCobranca.GrupoVeiculos.Nome, erro.ErrorMessage);
                }
            }

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