using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDados.ModuloFuncionario
{
    public class RepositorioFuncionarioEmBancoDados :
        RepositorioBase<Funcionario, MapeadorFuncionario>,
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

		private string sqlSelecionarPorNome =>
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
                [NOME] = @NOME";

		private string sqlSelecionarPorUsuario =>
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
                [LOGIN] = @LOGIN";

		public Funcionario SelecionarFuncionarioPorNome(string nome)
		{
			return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("NOME", nome));
		}

		public Funcionario SelecionarFuncionarioPorLogin(string login)
		{
			return SelecionarPorParametro(sqlSelecionarPorUsuario, new SqlParameter("LOGIN", login));
		}
    }
}
