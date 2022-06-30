using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloPessoaFisica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloPessoaFisica
{
    public class ServicoPessoaFisica
    {
        private IRepositorioPessoaFisica repositorioPessoaFisica;

        public ServicoPessoaFisica(IRepositorioPessoaFisica repositorioPessoaFisica)
        {
            this.repositorioPessoaFisica = repositorioPessoaFisica;
        }

        public ValidationResult Inserir(PessoaFisica pessoaFisica)
        {
            ValidationResult resultadoValidacao = Validar(pessoaFisica);

            if (resultadoValidacao.IsValid)
                repositorioPessoaFisica.Inserir(pessoaFisica);

            return resultadoValidacao;
        }

        public ValidationResult Editar(PessoaFisica pessoaFisica)
        {
            ValidationResult resultadoValidacao = Validar(pessoaFisica);

            if (resultadoValidacao.IsValid)
                repositorioPessoaFisica.Editar(pessoaFisica);

            return resultadoValidacao;
        }

        private ValidationResult Validar(PessoaFisica pessoaFisica)
        {
            var validador = new ValidadorPessoaFisica();

            var resultadoValidacao = validador.Validate(pessoaFisica);

            if (NomeDuplicado(pessoaFisica))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome duplicado"));

            if (UsuarioDuplicado(pessoaFisica))
                resultadoValidacao.Errors.Add(new ValidationFailure("CPF", "CPF duplicado"));

            return resultadoValidacao;
        }

        private bool NomeDuplicado(PessoaFisica pessoaFisica)
        {
            var pessoaFisicaEncontrado = repositorioPessoaFisica.SelecionarPessoaFisicaPorNome(pessoaFisica.Nome);

            return pessoaFisicaEncontrado != null &&
                   pessoaFisicaEncontrado.Nome == pessoaFisica.Nome &&
                   pessoaFisicaEncontrado.Id != pessoaFisica.Id;
        }

        private bool CPFDuplicado(PessoaFisica pessoaFisica)
        {
            var pessoaFisicaEncontrado = repositorioPessoaFisica.SelecionarPessoaFisicaPorCPF(pessoaFisica.CPF);

            return pessoaFisicaEncontrado != null &&
                   pessoaFisicaEncontrado.CPF == pessoaFisica.CPF &&
                   pessoaFisicaEncontrado.Id != pessoaFisica.Id;
        }

    }
}
