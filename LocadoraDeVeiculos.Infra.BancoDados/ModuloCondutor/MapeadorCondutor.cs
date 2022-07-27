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
    public class MapeadorCondutor : MapeadorBase<Condutor>
    {
        public override void ConfigurarParametros(Condutor registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("NOME", registro.Nome);
            comando.Parameters.AddWithValue("EMAIL", registro.Email);
            comando.Parameters.AddWithValue("TELEFONE", registro.Telefone);
            comando.Parameters.AddWithValue("ENDERECO", registro.Endereco);
            comando.Parameters.AddWithValue("CPF", registro.CPF);
            comando.Parameters.AddWithValue("CNH", registro.CNH);
            comando.Parameters.AddWithValue("VALIDADECNH", registro.ValidadeCNH);
            comando.Parameters.AddWithValue("CLIENTE_ID", registro.Cliente_Id);
        }

        public override Condutor ConverterRegistro(SqlDataReader leitorRegistro)
        {
            Guid id = Guid.Parse(leitorRegistro["CONDUTOR_ID"].ToString());
            string nome = Convert.ToString(leitorRegistro["CONDUTOR_NOME"]);
            string email = Convert.ToString(leitorRegistro["CONDUTOR_EMAIL"]);
            string telefone = Convert.ToString(leitorRegistro["CONDUTOR_TELEFONE"]);
            string endereco = Convert.ToString(leitorRegistro["CONDUTOR_ENDERECO"]);
            string cpf = Convert.ToString(leitorRegistro["CONDUTOR_CPF"]);
            string cnh = Convert.ToString(leitorRegistro["CONDUTOR_CNH"]);
            DateTime validade_cnh = Convert.ToDateTime(leitorRegistro["CONDUTOR_VALIDADECNH"]);
            Guid cliente_id = Guid.Parse(leitorRegistro["CONDUTOR_CLIENTE_ID"].ToString());

            return new Condutor()
            {
                Id = id,
                Nome = nome,
                Email = email,
                Telefone = telefone,
                Endereco = endereco,
                CPF = cpf,
                CNH = cnh,
                ValidadeCNH = validade_cnh,
                Cliente_Id = cliente_id,
            };
        }
    }
}
