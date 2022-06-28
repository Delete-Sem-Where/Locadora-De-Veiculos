﻿using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDados.ModuloFuncionario
{
    public class RepositorioFuncionarioEmBancoDados :
        RepositorioBase<Funcionario, ValidadorFuncionario, MapeadorFuncionario>,
        IRepositorioFuncionario
    {
        protected override string sqlInserir =>
			@"INSERT INTO [TBFUNCIONARIO] 
			(
				[NOME],
				[EMAIL],
				[TELEFONE],
				[ENDERECO],
				[LOGIN],
				[SENHA],
				[SALARIO],
				[DATADEADMISSAO]
			)
			VALUES
			(
				@NOME,
				@EMAIL,
				@TELEFONE,
				@ENDERECO,
				@LOGIN,
				@SENHA,
				@SALARIO,
				@DATADEADMISSAO
			); SELECT SCOPE_IDENTITY();";

		protected override string sqlEditar =>
			@"UPDATE [TBFUNCIONARIO]	
			SET
				[NOME] = @NOME,
				[EMAIL] = @EMAIL,
				[TELEFONE] = @TELEFONE,
				[ENDERECO] = @ENDERECO,
				[LOGIN] = @LOGIN,
				[SENHA] = @SENHA,
				[SALARIO] = @SALARIO,
				[DATADEADMISSAO] = @DATADEADMISSAO
			WHERE
				[ID] = @ID";

		protected override string sqlExcluir =>
			@"DELETE FROM [TBFUNCIONARIO]			        
			WHERE
				[ID] = @ID";

		protected override string sqlSelecionarTodos =>
			@"SELECT 
				[ID] FUNCIONARIO_ID, 
				[NOME] FUNCIONARIO_NOME, 
				[EMAIL] FUNCIONARIO_EMAIL,
				[TELEFONE] FUNCIONARIO_TELEFONE,
				[ENDERECO] FUNCIONARIO_ENDERECO,
				[LOGIN] FUNCIONARIO_LOGIN,
				[SENHA] FUNCIONARIO_SENHA,
				[SALARIO] FUNCIONARIO_SALARIO,
				[DATADEADMISSAO] FUNCIONARIO_DATADEADMISSAO
			FROM 
				[TBFUNCIONARIO]";

		protected override string sqlSelecionarPorId =>
			@"SELECT 
				[ID] FUNCIONARIO_ID, 
				[NOME] FUNCIONARIO_NOME, 
				[EMAIL] FUNCIONARIO_EMAIL,
				[TELEFONE] FUNCIONARIO_TELEFONE,
				[ENDERECO] FUNCIONARIO_ENDERECO,
				[LOGIN] FUNCIONARIO_LOGIN,
				[SENHA] FUNCIONARIO_SENHA,
				[SALARIO] FUNCIONARIO_SALARIO,
				[DATADEADMISSAO] FUNCIONARIO_DATADEADMISSAO
			FROM 
				[TBFUNCIONARIO]
			WHERE
				[ID] = @ID";

        public override ValidationResult Validar(Funcionario registro)
        {
			var validador = new ValidadorFuncionario();

			var resultadoValidacao = validador.Validate(registro);

			if (resultadoValidacao.IsValid == false)
				return resultadoValidacao;

			var registroEncontradoNome = SelecionarTodos()
				.Select(x => x.Nome.ToLower())
				.Contains(registro.Nome.ToLower());

			if (registroEncontradoNome)
			{
				if (registro.Id == 0)
					resultadoValidacao.Errors.Add(new ValidationFailure("", "Funcionario já cadastrado com esse Nome"));
				else if (registro.Id != 0)
				{
					resultadoValidacao.Errors.Add(new ValidationFailure("", "Funcionario já cadastrado com esse Nome"));
				}
			}

			var registroEncontradoLogin = SelecionarTodos()
				.Select(x => x.Login.ToLower())
				.Contains(registro.Login.ToLower());

			if (registroEncontradoLogin)
			{
				if (registro.Id == 0)
					resultadoValidacao.Errors.Add(new ValidationFailure("", "Funcionario já cadastrado com esse Login"));
				else if (registro.Id != 0)
				{
					resultadoValidacao.Errors.Add(new ValidationFailure("", "Funcionario já cadastrado com esse Login"));
				}
			}

			return resultadoValidacao;
		}

    }
}
