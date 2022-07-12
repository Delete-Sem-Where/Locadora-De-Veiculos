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
    public class MapeadorCliente : MapeadorBase<Cliente>
    {
        public override void ConfigurarParametros(Cliente registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("NOME", registro.Nome);
            comando.Parameters.AddWithValue("EMAIL", registro.Email);
            comando.Parameters.AddWithValue("TELEFONE", registro.Telefone);
            comando.Parameters.AddWithValue("ENDERECO", registro.Endereco);
            comando.Parameters.AddWithValue("TIPO_CLIENTE", registro.TipoCliente);

            if (registro.TipoCliente == TipoCliente.PessoaJuridica)
                comando.Parameters.AddWithValue("DOCUMENTO", registro.CNPJ);
            else
                comando.Parameters.AddWithValue("DOCUMENTO", registro.CPF);
        }

        public override Cliente ConverterRegistro(SqlDataReader leitorRegistro)
        {
            var id = Guid.Parse(leitorRegistro["CLIENTE_ID"].ToString());
            var nome = Convert.ToString(leitorRegistro["CLIENTE_NOME"]);
            var email = Convert.ToString(leitorRegistro["CLIENTE_EMAIL"]);
            var telefone = Convert.ToString(leitorRegistro["CLIENTE_TELEFONE"]);
            var endereco = Convert.ToString(leitorRegistro["CLIENTE_ENDERECO"]);
            var tipo = Convert.ToInt32(leitorRegistro["CLIENTE_TIPO_CLIENTE"]);
            var documento = Convert.ToString(leitorRegistro["CLIENTE_DOCUMENTO"]);

            Cliente cliente = new Cliente()
            {
                Id = id,
                Nome = nome,
                Email = email,
                Telefone = telefone,
                Endereco = endereco
            };

            ConfigurarTipoCliente(tipo, documento, cliente);

            return cliente;
        }

        private void ConfigurarTipoCliente(int tipo, string documento, Cliente cliente)
        {
            if (tipo == 0)
            {
                cliente.TipoCliente = TipoCliente.PessoaFisica;
                cliente.CPF = documento;
            }
            else if (tipo == 1)
            {
                cliente.TipoCliente = TipoCliente.PessoaJuridica;
                cliente.CNPJ = documento;
            }
        }

    }
}
