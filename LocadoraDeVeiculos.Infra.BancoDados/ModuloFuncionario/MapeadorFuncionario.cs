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
    public class MapeadorFuncionario : MapeadorBase<Funcionario>
    {
        public override void ConfigurarParametros(Funcionario registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("NOME", registro.Nome);
            comando.Parameters.AddWithValue("EMAIL", registro.Email);
            comando.Parameters.AddWithValue("TELEFONE", registro.Telefone);
            comando.Parameters.AddWithValue("ENDERECO", registro.Endereco);
            comando.Parameters.AddWithValue("LOGIN", registro.Login);
            comando.Parameters.AddWithValue("SENHA", registro.Senha);
            comando.Parameters.AddWithValue("SALARIO", registro.Salario);
            comando.Parameters.AddWithValue("DATADEADMISSAO", registro.DataDeAdmissao);
        }

        public override Funcionario ConverterRegistro(SqlDataReader leitorRegistro)
        {
            int id = Convert.ToInt32(leitorRegistro["FUNCIONARIO_ID"]);
            string nome = Convert.ToString(leitorRegistro["FUNCIONARIO_NOME"]);
            string email = Convert.ToString(leitorRegistro["FUNCIONARIO_EMAIL"]);
            string telefone = Convert.ToString(leitorRegistro["FUNCIONARIO_TELEFONE"]);
            string endereco = Convert.ToString(leitorRegistro["FUNCIONARIO_ENDERECO"]);
            string login = Convert.ToString(leitorRegistro["FUNCIONARIO_LOGIN"]);
            string senha = Convert.ToString(leitorRegistro["FUNCIONARIO_SENHA"]);
            double salario = Convert.ToDouble(leitorRegistro["FUNCIONARIO_SALARIO"]);
            DateTime datadeadmissao = Convert.ToDateTime(leitorRegistro["FUNCIONARIO_DATADEADMISSAO"]);

            return new Funcionario()
            {
                Id = id,
                Nome = nome,
                Email = email,
                Telefone = telefone,
                Endereco = endereco,
                Login = login,
                Senha = senha,
                Salario = salario,
                DataDeAdmissao = datadeadmissao
            };
        }
    }
}
