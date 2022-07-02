using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDados.ModuloCondutor
{
    public class RepositorioCondutorEmBancoDados :
        RepositorioBase<Condutor, MapeadorCondutor>,
        IRepositorioCondutor
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBCONDUTOR] 
            (
                [NOME],
                [EMAIL],
                [TELEFONE],
                [ENDERECO],
                [CPF],
                [CNH],
                [VALIDADECNH],
                [CLIENTE_ID]
            )
            VALUES
            (
                @NOME,
                @EMAIL,
                @TELEFONE,
                @ENDERECO,
                @CPF,
                @CNH,
                @VALIDADECNH,
                @CLIENTE_ID
            ); SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @"UPDATE [TBCONDUTOR] 
            SET
                [NOME] = @NOME,
                [EMAIL] = @EMAIL,
                [TELEFONE] = @TELEFONE,
                [ENDERECO] = @ENDERECO,
                [CPF] = @CPF,
                [CNH] = @CNH,
                [VALIDADECNH] = @VALIDADECNH,
                [CLIENTE_ID] = @CLIENTE_ID
            WHERE
                [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBCONDUTOR]                    
            WHERE
                [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                [ID] CONDUTOR_ID, 
                [NOME] CONDUTOR_NOME, 
                [EMAIL] CONDUTOR_EMAIL,
                [TELEFONE] CONDUTOR_TELEFONE,
                [ENDERECO] CONDUTOR_ENDERECO,
                [CPF] CONDUTOR_CPF,
                [CNH] CONDUTOR_CNH,
                [VALIDADECNH] CONDUTOR_VALIDADECNH,
                [CLIENTE_ID] CONDUTOR_CLIENTE_ID
            FROM 
                [TBCONDUTOR]";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                [ID] CONDUTOR_ID, 
                [NOME] CONDUTOR_NOME, 
                [EMAIL] CONDUTOR_EMAIL,
                [TELEFONE] CONDUTOR_TELEFONE,
                [ENDERECO] CONDUTOR_ENDERECO,
                [CPF] CONDUTOR_CPF,
                [CNH] CONDUTOR_CNH,
                [VALIDADECNH] CONDUTOR_VALIDADECNH,
                [CLIENTE_ID] CONDUTOR_CLIENTE_ID
            FROM 
                [TBCONDUTOR]
            WHERE
                [ID] = @ID";

        private string sqlSelecionarPorCPF =>
            @"SELECT 
                [ID] CONDUTOR_ID, 
                [NOME] CONDUTOR_NOME, 
                [EMAIL] CONDUTOR_EMAIL,
                [TELEFONE] CONDUTOR_TELEFONE,
                [ENDERECO] CONDUTOR_ENDERECO,
                [CPF] CONDUTOR_CPF,
                [CNH] CONDUTOR_CNH,
                [VALIDADECNH] CONDUTOR_VALIDADECNH,
                [CLIENTE_ID] CONDUTOR_CLIENTE_ID
            FROM 
                [TBCONDUTOR]
            WHERE
                [CPF] = @CPF";

        private string sqlSelecionarPorNome =>
            @"SELECT 
                [ID] CONDUTOR_ID, 
                [NOME] CONDUTOR_NOME, 
                [EMAIL] CONDUTOR_EMAIL,
                [TELEFONE] CONDUTOR_TELEFONE,
                [ENDERECO] CONDUTOR_ENDERECO,
                [CPF] CONDUTOR_CPF,
                [CNH] CONDUTOR_CNH,
                [VALIDADECNH] CONDUTOR_VALIDADECNH,
                [CLIENTE_ID] CONDUTOR_CLIENTE_ID
            FROM 
                [TBCONDUTOR]
            WHERE
                [NOME] = @NOME";

        public Condutor SelecionarCondutorPorCPF(string cpf)
        {
            return SelecionarPorParametro(sqlSelecionarPorCPF, new SqlParameter("CPF", cpf));
        }

        public Condutor SelecionarCondutorPorNome(string nome)
        {
            return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("NOME", nome));
        }
    }
}
