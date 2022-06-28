using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloPessoaJuridica;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDados.ModuloPessoaJuridica
{
    public class RepositorioPessoaJuridicaEmBancoDados :
        RepositorioBase<PessoaJuridica, ValidadorPessoaJuridica, MapeadorPessoaJuridica>,
        IRepositorioPessoaJuridica
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBPESSOAJURIDICA] 
            (
	            [NOME],
	            [EMAIL],
	            [TELEFONE],
	            [ENDERECO],
	            [CNPJ]
            )
            VALUES
            (
	            @NOME,
	            @EMAIL,
	            @TELEFONE,
	            @ENDERECO,
	            @CNPJ
            ); SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @"UPDATE [TBPESSOAJURIDICA]	
            SET
	            [NOME] = @NOME,
	            [EMAIL] = @EMAIL,
	            [TELEFONE] = @TELEFONE,
	            [ENDERECO] = @ENDERECO,
	            [CNPJ] = @CNPJ
            WHERE
	            [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBPESSOAJURIDICA]			        
            WHERE
	            [ID] = @ID";

        protected override string sqlSelecionarTodos =>
			@"SELECT 
				[ID] PESSOA_JURIDICA_ID, 
				[NOME] PESSOA_JURIDICA_NOME, 
				[EMAIL] PESSOA_JURIDICA_EMAIL,
				[TELEFONE] PESSOA_JURIDICA_TELEFONE,
				[ENDERECO] PESSOA_JURIDICA_ENDERECO,
				[CNPJ] PESSOA_JURIDICA_CNPJ
			FROM 
				[TBPESSOAJURIDICA]";

		protected override string sqlSelecionarPorId =>
			@"SELECT 
				[ID] PESSOA_JURIDICA_ID, 
				[NOME] PESSOA_JURIDICA_NOME, 
				[EMAIL] PESSOA_JURIDICA_EMAIL,
				[TELEFONE] PESSOA_JURIDICA_TELEFONE,
				[ENDERECO] PESSOA_JURIDICA_ENDERECO,
				[CNPJ] PESSOA_JURIDICA_CNPJ
			FROM 
				[TBPESSOAJURIDICA]
			WHERE
				[ID] = @ID";

		public override ValidationResult Validar(PessoaJuridica registro)
		{
			var validador = new ValidadorPessoaJuridica();

			var resultadoValidacao = validador.Validate(registro);

			if (resultadoValidacao.IsValid == false)
				return resultadoValidacao;

			var registroEncontradoNome = SelecionarTodos()
				.Select(x => x.Nome.ToLower())
				.Contains(registro.Nome.ToLower());

			if (registroEncontradoNome)
			{
				if (registro.Id == 0)
					resultadoValidacao.Errors.Add(new ValidationFailure("", "Pessoa Juridica já cadastrado com esse Nome"));
				else if (registro.Id != 0)
				{
					resultadoValidacao.Errors.Add(new ValidationFailure("", "Pessoa Juridica já cadastrado com esse Nome"));
				}
			}

			var registroEncontradoCNPJ = SelecionarTodos()
				.Select(x => x.CNPJ.ToLower())
				.Contains(registro.CNPJ.ToLower());

			if (registroEncontradoCNPJ)
			{
				if (registro.Id == 0)
					resultadoValidacao.Errors.Add(new ValidationFailure("", "Pessoa Juridica já cadastrado com esse CNPJ"));
				else if (registro.Id != 0)
				{
					resultadoValidacao.Errors.Add(new ValidationFailure("", "Pessoa Juridica já cadastrado com esse CNPJ"));
				}
			}

			return resultadoValidacao;
		}
    }
}
