using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloGruposVeiculos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDados.ModuloPlanoCobranca
{
    public class MapeadorPlanoCobranca : MapeadorBase<PlanoCobranca>
    {


        RepositorioGrupoVeiculosEmBancoDados repositorioGrupo = new RepositorioGrupoVeiculosEmBancoDados();
        public override void ConfigurarParametros(PlanoCobranca registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("GRUPOVEICULOS_ID", registro.GrupoVeiculos.Id);
            comando.Parameters.AddWithValue("MODALIDADEPLANOCOBRANCA", registro.ModalidadePlanoCobranca);
            comando.Parameters.AddWithValue("VALORDIARIA", registro.ValorDiaria);
            comando.Parameters.AddWithValue("LIMITEKM", registro.LimiteKm);
            comando.Parameters.AddWithValue("VALORKM", registro.ValorKm);
        }

        public override PlanoCobranca ConverterRegistro(SqlDataReader leitorRegistro)
        {
            var id = Guid.Parse(leitorRegistro["ID"].ToString());
            var idGrupo = Guid.Parse(leitorRegistro["GRUPOVEICULOS_ID"].ToString());
            //int idGrupo = Convert.ToInt32(leitorRegistro["GRUPOVEICULOS_ID"]);
            int modalidadePlanoCobranca = Convert.ToInt32(leitorRegistro["MODALIDADEPLANOCOBRANCA"]);
            Decimal valorDiaria = Convert.ToDecimal(leitorRegistro["VALORDIARIA"]);
            Decimal limiteKm = Convert.ToDecimal(leitorRegistro["LIMITEKM"]);
            Decimal valorKm = Convert.ToDecimal(leitorRegistro["VALORKM"]);

            var plano = new PlanoCobranca
            {
                Id = id,
                ModalidadePlanoCobranca = (ModalidadePlanoCobranca)modalidadePlanoCobranca,
                ValorDiaria = valorDiaria,
                LimiteKm = limiteKm,
                ValorKm = valorKm,
                GrupoVeiculos = repositorioGrupo.SelecionarPorId(idGrupo)
            };

            return plano;

        }
    }
}
