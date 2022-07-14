using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDados.ModuloGruposVeiculos
{
    public class MapeadorGrupoVeiculos : MapeadorBase<GrupoVeiculos>
    {
        public override GrupoVeiculos ConverterRegistro(SqlDataReader leitor)
        {
            Guid id = Guid.Parse(leitor["ID"].ToString());
            string? nome = Convert.ToString(leitor["NOME"]);

            var grupoVeiculos = new GrupoVeiculos
            {
                Id = id,
                Nome = nome,
            };

            return grupoVeiculos;
        }

        public override void ConfigurarParametros(GrupoVeiculos novoGrupoVeiculos, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", novoGrupoVeiculos.Id);
            comando.Parameters.AddWithValue("NOME", novoGrupoVeiculos.Nome);
        }
    }
}
