using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloPessoaFisica;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDados.ModuloPessoaFisica
{
    public class RepositorioPessoaFisicaEmBancoDados :
        RepositorioBase<PessoaFisica, ValidadorPessoaFisica, MapeadorPessoaFisica>,
        IRepositorioPessoaFisica
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBPESSOAFISICA] 
            (
                [NOME],
                [EMAIL],
                [TELEFONE],
                [ENDERECO],
                [CPF],
                [CNH]
            )
            VALUES
            (
                @NOME,
                @EMAIL,
                @TELEFONE,
                @ENDERECO,
                @CPF,
                @CNH
            ); SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @"UPDATE [TBPESSOAFISICA]	
            SET
                [NOME] = @NOME,
                [EMAIL] = @EMAIL,
                [TELEFONE] = @TELEFONE,
                [ENDERECO] = @ENDERECO,
                [CPF] = @CPF,
                [CNH] = @CNH
            WHERE
                [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBPESSOAFISICA]			        
            WHERE
                [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
	            [ID] PESSOA_FISICA_ID, 
	            [NOME] PESSOA_FISICA_NOME, 
	            [EMAIL] PESSOA_FISICA_EMAIL,
	            [TELEFONE] PESSOA_FISICA_TELEFONE,
	            [ENDERECO] PESSOA_FISICA_ENDERECO,
	            [CPF] PESSOA_FISICA_CPF,
	            [CNH] PESSOA_FISICA_CNH
            FROM 
	            [TBPESSOAFISICA]";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
	            [ID] PESSOA_FISICA_ID, 
	            [NOME] PESSOA_FISICA_NOME, 
	            [EMAIL] PESSOA_FISICA_EMAIL,
	            [TELEFONE] PESSOA_FISICA_TELEFONE,
	            [ENDERECO] PESSOA_FISICA_ENDERECO,
	            [CPF] PESSOA_FISICA_CPF,
	            [CNH] PESSOA_FISICA_CNH
            FROM 
	            [TBPESSOAFISICA]
            WHERE
	            [ID] = @ID";

		public override ValidationResult Validar(PessoaFisica registro)
		{
			var validador = new ValidadorPessoaFisica();

			var resultadoValidacao = validador.Validate(registro);

			if (resultadoValidacao.IsValid == false)
				return resultadoValidacao;

			var registroEncontradoNome = SelecionarTodos()
				.Select(x => x.Nome.ToLower())
				.Contains(registro.Nome.ToLower());

			if (registroEncontradoNome)
			{
				if (registro.Id == 0)
					resultadoValidacao.Errors.Add(new ValidationFailure("", "Pessoa Física já cadastrado com esse Nome"));
				else if (registro.Id != 0)
				{
					resultadoValidacao.Errors.Add(new ValidationFailure("", "Pessoa Física já cadastrado com esse Nome"));
				}
			}

			var registroEncontradoCNPJ = SelecionarTodos()
				.Select(x => x.CPF.ToLower())
				.Contains(registro.CPF.ToLower());

			if (registroEncontradoCNPJ)
			{
				if (registro.Id == 0)
					resultadoValidacao.Errors.Add(new ValidationFailure("", "Pessoa Física já cadastrado com esse CNPJ"));
				else if (registro.Id != 0)
				{
					resultadoValidacao.Errors.Add(new ValidationFailure("", "Pessoa Física já cadastrado com esse CNPJ"));
				}
			}

			return resultadoValidacao;
		}
	}
}
