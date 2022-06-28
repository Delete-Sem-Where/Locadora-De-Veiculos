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
    public class MapeadorPessoaFisica : MapeadorBase<PessoaFisica>
    {
        public override void ConfigurarParametros(PessoaFisica registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("NOME", registro.Nome);
            comando.Parameters.AddWithValue("EMAIL", registro.Email);
            comando.Parameters.AddWithValue("TELEFONE", registro.Telefone);
            comando.Parameters.AddWithValue("ENDERECO", registro.Endereco);
            comando.Parameters.AddWithValue("CPF", registro.CPF);
            comando.Parameters.AddWithValue("CNH", registro.CNH);
        }

        public override PessoaFisica ConverterRegistro(SqlDataReader leitorRegistro)
        {
            int id = Convert.ToInt32(leitorRegistro["PESSOA_FISICA_ID"]);
            string nome = Convert.ToString(leitorRegistro["PESSOA_FISICA_NOME"]);
            string email = Convert.ToString(leitorRegistro["PESSOA_FISICA_EMAIL"]);
            string telefone = Convert.ToString(leitorRegistro["PESSOA_FISICA_TELEFONE"]);
            string endereco = Convert.ToString(leitorRegistro["PESSOA_FISICA_ENDERECO"]);
            string cpf = Convert.ToString(leitorRegistro["PESSOA_FISICA_CPF"]);
            string cnh = Convert.ToString(leitorRegistro["PESSOA_FISICA_CNH"]);

            return new PessoaFisica()
            {
                Id = id,
                Nome = nome,
                Email = email,
                Telefone = telefone,
                Endereco = endereco,
                CPF = cpf,
                CNH = cnh,
            };
        }
    }
}
