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
        

        public override void ConfigurarParametros(Taxa novaTaxa, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", novaTaxa.Id);
            comando.Parameters.AddWithValue("DESCRICAO", novaTaxa.Descricao);
            comando.Parameters.AddWithValue("VALOR", novaTaxa.Valor);
            comando.Parameters.AddWithValue("TIPOCALCULO", novaTaxa.TipoCalculo);

        }
        public override Taxa ConverterRegistro(SqlDataReader leitorTaxa)
        {
            var numero = Guid.Parse(leitorTaxa["ID"].ToString());
            string? descricao = Convert.ToString(leitorTaxa["DESCRICAO"]);
            decimal valor = Convert.ToDecimal(leitorTaxa["VALOR"]);
            var tipoCalculo = Convert.ToInt32(leitorTaxa["TIPOCALCULO"]);


            var taxa = new Taxa();
            {
                taxa.Id = numero;
                taxa.Descricao = descricao;
                taxa.Valor = valor;
                taxa.TipoCalculo = (TipoCalculo)tipoCalculo;

            };

            return taxa;
        }
    }
}
