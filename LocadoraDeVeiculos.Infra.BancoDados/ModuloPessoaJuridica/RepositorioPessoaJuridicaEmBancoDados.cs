using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloPessoaJuridica;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDados.ModuloPessoaJuridica
{
    public class RepositorioPessoaJuridicaEmBancoDados :
        RepositorioBase<PessoaJuridica, MapeadorPessoaJuridica>,
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

		private string sqlSelecionarPorNome =>
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
				[NOME] = @NOME";

		private string sqlSelecionarPorCNPJ =>
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
				[CNPJ] = @CNPJ";

		public PessoaJuridica SelecionarPessoaJuridicaPorCNPJ(string cnpj)
        {
			return SelecionarPorParametro(sqlSelecionarPorCNPJ, new SqlParameter("CNPJ", cnpj));
        }

        public PessoaJuridica SelecionarPessoaJuridicaPorNome(string nome)
        {
			return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("NOME", nome));
		}
    }
}
