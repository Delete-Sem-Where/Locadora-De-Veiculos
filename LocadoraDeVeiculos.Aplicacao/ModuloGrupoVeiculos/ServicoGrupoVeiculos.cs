using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloGrupoVeiculos
{
    public class ServicoGrupoVeiculos
    {
        private IRepositorioGrupoVeiculos repositorioGrupoVeiculos;

        public ServicoGrupoVeiculos(IRepositorioGrupoVeiculos repositorioGrupoVeiculos)
        {
            this.repositorioGrupoVeiculos = repositorioGrupoVeiculos;
        }

        public ValidationResult Inserir(GrupoVeiculos grupoVeiculos)
        {
            ValidationResult resultadoValidacao = Validar(grupoVeiculos);

            if (resultadoValidacao.IsValid)
                repositorioGrupoVeiculos.Inserir(grupoVeiculos);

            return resultadoValidacao;
        }

        public ValidationResult Editar(GrupoVeiculos grupoVeiculos)
        {
            ValidationResult resultadoValidacao = Validar(grupoVeiculos);

            if (resultadoValidacao.IsValid)
                repositorioGrupoVeiculos.Editar(grupoVeiculos);

            return resultadoValidacao;
        }

        private ValidationResult Validar(GrupoVeiculos grupoVeiculos)
        {
            var validador = new ValidadorGrupoVeiculos();

            var resultadoValidacao = validador.Validate(grupoVeiculos);

            if (NomeDuplicado(grupoVeiculos))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome duplicado"));

            return resultadoValidacao;
        }

        private bool NomeDuplicado(GrupoVeiculos grupoVeiculos)
        {
            var grupoVeiculosEncontrado = repositorioGrupoVeiculos.SelecionarGrupoVeiculosPorNome(grupoVeiculos.Nome);

            return grupoVeiculosEncontrado != null &&
                   grupoVeiculosEncontrado.Nome == grupoVeiculos.Nome &&
                   grupoVeiculosEncontrado.Id != grupoVeiculos.Id;
        }
    }
}
