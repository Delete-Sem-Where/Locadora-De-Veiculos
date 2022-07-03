using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDados.ModuloCliente
{
    public class RepositorioClienteEmBancoDados :
        RepositorioBase<Cliente, MapeadorCliente>,
        IRepositorioCliente
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBCLIENTE]
            (
                [NOME],
                [DOCUMENTO],
                [EMAIL],
                [TELEFONE],
                [ENDERECO],
                [TIPO_CLIENTE]
            )
            VALUES
            (
                @NOME, 
                @DOCUMENTO, 
                @EMAIL,
                @TELEFONE,
                @ENDERECO,
                @TIPO_CLIENTE
            );SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @"UPDATE [TBCLIENTE]
            SET
                [NOME] = @NOME,
                [DOCUMENTO] = @DOCUMENTO,
                [EMAIL] = @EMAIL,
                [TELEFONE] = @TELEFONE,
                [ENDERECO] = @ENDERECO,
                [TIPO_CLIENTE] = @TIPO_CLIENTE
            WHERE
                [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBCLIENTE]
                WHERE [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                [ID] CLIENTE_ID,
                [NOME] CLIENTE_NOME,
                [DOCUMENTO] CLIENTE_DOCUMENTO,
                [EMAIL] CLIENTE_EMAIL,
                [TELEFONE] CLIENTE_TELEFONE,
                [ENDERECO] CLIENTE_ENDERECO,
                [TIPO_CLIENTE] CLIENTE_TIPO_CLIENTE
            FROM
                [TBCLIENTE]";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                [ID] CLIENTE_ID,
                [NOME] CLIENTE_NOME,
                [DOCUMENTO] CLIENTE_DOCUMENTO,
                [EMAIL] CLIENTE_EMAIL,
                [TELEFONE] CLIENTE_TELEFONE,
                [ENDERECO] CLIENTE_ENDERECO,
                [TIPO_CLIENTE] CLIENTE_TIPO_CLIENTE
            FROM
                [TBCLIENTE]
            WHERE
                [ID] = @ID";

        private string sqlSelecionarPorNome =>
            @"SELECT 
                [ID] CLIENTE_ID,
                [NOME] CLIENTE_NOME,
                [DOCUMENTO] CLIENTE_DOCUMENTO,
                [EMAIL] CLIENTE_EMAIL,
                [TELEFONE] CLIENTE_TELEFONE,
                [ENDERECO] CLIENTE_ENDERECO,
                [TIPO_CLIENTE] CLIENTE_TIPO_CLIENTE
            FROM
                [TBCLIENTE]
            WHERE
                [NOME] = @NOME";

        private string sqlSelecionarPorDocumento => 
            @"SELECT 
                [ID] CLIENTE_ID,
                [NOME] CLIENTE_NOME,
                [DOCUMENTO] CLIENTE_DOCUMENTO,
                [EMAIL] CLIENTE_EMAIL,
                [TELEFONE] CLIENTE_TELEFONE,
                [ENDERECO] CLIENTE_ENDERECO,
                [TIPO_CLIENTE] CLIENTE_TIPO_CLIENTE
            FROM
                [TBCLIENTE]
            WHERE
                [DOCUMENTO] = @DOCUMENTO";

        public Cliente SelecionarClientePorCNPJ(string cnpj)
        {
            return SelecionarPorParametro(sqlSelecionarPorDocumento, new SqlParameter("DOCUMENTO", cnpj));
        }

        public Cliente SelecionarClientePorCPF(string cpf)
        {
            return SelecionarPorParametro(sqlSelecionarPorDocumento, new SqlParameter("DOCUMENTO", cpf));
        }

        public Cliente SelecionarClientePorNome(string nome)
        {
            return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("NOME", nome));
        }
    }
}
