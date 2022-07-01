using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDados.ModuloTaxa
{
    public class MapeadorTaxa:MapeadorBase<Taxa>
    {
        public override Taxa ConverterRegistro(SqlDataReader leitorTaxa)
        {
            int numero = Convert.ToInt32(leitorTaxa["ID"]);
            string? descricao = Convert.ToString(leitorTaxa["DESCRICAO"]);
            decimal valor = Convert.ToDecimal(leitorTaxa["VALOR"]);
            var tipoCalculo = Convert.ToInt32(leitorTaxa["TIPOCALCULO"]);


            var taxa = new Taxa
            {
                Id = numero,
                Descricao = descricao,
                Valor = valor,
                TipoCalculo = (TipoCalculo)tipoCalculo

            };

            return taxa;
        }

        public override void ConfigurarParametros(Taxa novaTaxa, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", novaTaxa.Id);
            comando.Parameters.AddWithValue("DESCRICAO", novaTaxa.Descricao);
            comando.Parameters.AddWithValue("VALOR", novaTaxa.Valor);
            comando.Parameters.AddWithValue("TIPOCALCULO", novaTaxa.TipoCalculo);

        }
    }
}
