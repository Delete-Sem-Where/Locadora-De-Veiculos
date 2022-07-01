using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloPessoaFisica;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDados.ModuloPessoaFisica
{
    public class RepositorioPessoaFisicaEmBancoDados :
        RepositorioBase<PessoaFisica, MapeadorPessoaFisica>,
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

        private string sqlSelecionarPorNome =>
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
	            [NOME] = @NOME";

        private string sqlSelecionarPorCPF =>
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
	            [CPF] = @CPF";

        public PessoaFisica SelecionarPessoaFisicaPorCPF(string cpf)
        {
            return SelecionarPorParametro(sqlSelecionarPorCPF, new SqlParameter("CPF", cpf));
        }

        public PessoaFisica SelecionarPessoaFisicaPorNome(string nome)
        {
            return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("NOME", nome));
        }
    }
}
