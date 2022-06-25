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
    public class MapeadorPessoaJuridica : MapeadorBase<PessoaJuridica>
    {
        public override void ConfigurarParametros(PessoaJuridica registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("NOME", registro.Nome);
            comando.Parameters.AddWithValue("EMAIL", registro.Email);
            comando.Parameters.AddWithValue("TELEFONE", registro.Telefone);
            comando.Parameters.AddWithValue("ENDERECO", registro.Endereco);
            comando.Parameters.AddWithValue("CNPJ", registro.CNPJ);
        }

        public override PessoaJuridica ConverterRegistro(SqlDataReader leitorRegistro)
        {
            int id = Convert.ToInt32(leitorRegistro["PESSOA_JURIDICA_ID"]);
            string nome = Convert.ToString(leitorRegistro["PESSOA_JURIDICA_NOME"]);
            string email = Convert.ToString(leitorRegistro["PESSOA_JURIDICA_EMAIL"]);
            string telefone = Convert.ToString(leitorRegistro["PESSOA_JURIDICA_TELEFONE"]);
            string endereco = Convert.ToString(leitorRegistro["PESSOA_JURIDICA_ENDERECO"]);
            string cnpj = Convert.ToString(leitorRegistro["PESSOA_JURIDICA_CNPJ"]);

            return new PessoaJuridica()
            {
                Id = id,
                Nome = nome,
                Email = email,
                Telefone = telefone,
                Endereco = endereco,
                CNPJ = cnpj
            };
        }
    }
}
