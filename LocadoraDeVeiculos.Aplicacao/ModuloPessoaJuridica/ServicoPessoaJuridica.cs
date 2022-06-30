using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloPessoaJuridica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloPessoaJuridica
{
    public class ServicoPessoaJuridica
    {
        private IRepositorioPessoaJuridica repositorioPessoaJuridica;

        public ServicoPessoaJuridica(IRepositorioPessoaJuridica repositorioPessoaJuridica)
        {
            this.repositorioPessoaJuridica = repositorioPessoaJuridica;
        }

        public ValidationResult Inserir(PessoaJuridica pessoaJuridica)
        {
            ValidationResult resultadoValidacao = Validar(pessoaJuridica);

            if (resultadoValidacao.IsValid)
                repositorioPessoaJuridica.Inserir(pessoaJuridica);

            return resultadoValidacao;
        }

        public ValidationResult Editar(PessoaJuridica pessoaJuridica)
        {
            ValidationResult resultadoValidacao = Validar(pessoaJuridica);

            if (resultadoValidacao.IsValid)
                repositorioPessoaJuridica.Editar(pessoaJuridica);

            return resultadoValidacao;
        }

        private ValidationResult Validar(PessoaJuridica pessoaJuridica)
        {
            var validador = new ValidadorPessoaJuridica();

            var resultadoValidacao = validador.Validate(pessoaJuridica);

            if (NomeDuplicado(pessoaJuridica))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome duplicado"));

            if (CNPJDuplicado(pessoaJuridica))
                resultadoValidacao.Errors.Add(new ValidationFailure("CNPJ", "CNPJ duplicado"));

            return resultadoValidacao;
        }

        private bool NomeDuplicado(PessoaJuridica pessoaJuridica)
        {
            var pessoaJuridicaEncontrado = repositorioPessoaJuridica.SelecionarPessoaJuridicaPorNome(pessoaJuridica.Nome);

            return pessoaJuridicaEncontrado != null &&
                   pessoaJuridicaEncontrado.Nome == pessoaJuridica.Nome &&
                   pessoaJuridicaEncontrado.Id != pessoaJuridica.Id;
        }

        private bool CNPJDuplicado(PessoaJuridica pessoaJuridica)
        {
            var pessoaJuridicaEncontrado = repositorioPessoaJuridica.SelecionarPessoaJuridicaPorCNPJ(pessoaJuridica.CNPJ);

            return pessoaJuridicaEncontrado != null &&
                   pessoaJuridicaEncontrado.CNPJ == pessoaJuridica.CNPJ &&
                   pessoaJuridicaEncontrado.Id != pessoaJuridica.Id;
        }

    }
}
