using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDados.ModuloVeiculos
{
    public class MapeadorVeiculos : MapeadorBase<Veiculos>
    {
        public override Veiculos ConverterRegistro(SqlDataReader leitorRegistro)
        {
            int id = Convert.ToInt32(leitorRegistro["ID"]);
            string modelo = Convert.ToString(leitorRegistro["MODELO"]);
            string marca = Convert.ToString(leitorRegistro["MARCA"]);
            string ano = Convert.ToString(leitorRegistro["ANO"]);
            string cor = Convert.ToString(leitorRegistro["COR"]);
            string placa = Convert.ToString(leitorRegistro["PLACA"]);
            string quilometroPercorrido = Convert.ToString(leitorRegistro["QUILOMETRO_PERCORRIDO"]);
            string capacidadeTanque = Convert.ToString(leitorRegistro["CAPACIDADE_TANQUE"]);
            int grupoVeiculos_Id = Convert.ToInt32(leitorRegistro["GRUPOVEICULOS_ID"]);
            string tipoCombustivel = Convert.ToString(leitorRegistro["TIPO_COMBUSTIVEL"]);

            var veiculos = new Veiculos
            {
                Id = id,
                Modelo = modelo,
                Marca = marca,
                Ano = ano,
                Cor = cor,
                Placa = placa,
                TipoCombustivel = tipoCombustivel,
                QuilometroPercorrido = quilometroPercorrido,
                CapacidadeTanque = capacidadeTanque,
                GrupoVeiculos_Id = grupoVeiculos_Id
            };

            return veiculos;
        }

        public override void ConfigurarParametros(Veiculos novoVeiculo, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", novoVeiculo.Id);
            comando.Parameters.AddWithValue("MODELO", novoVeiculo.Modelo);
            comando.Parameters.AddWithValue("MARCA", novoVeiculo.Marca);
            comando.Parameters.AddWithValue("ANO", novoVeiculo.Ano);
            comando.Parameters.AddWithValue("COR", novoVeiculo.Cor);
            comando.Parameters.AddWithValue("PLACA", novoVeiculo.Placa);
            comando.Parameters.AddWithValue("QUILOMETRO_PERCORRIDO", novoVeiculo.QuilometroPercorrido);
            comando.Parameters.AddWithValue("CAPACIDADE_TANQUE", novoVeiculo.CapacidadeTanque);
            comando.Parameters.AddWithValue("TIPO_COMBUSTIVEL", novoVeiculo.TipoCombustivel);
            comando.Parameters.AddWithValue("GRUPO_VEICULOS_ID", novoVeiculo.GrupoVeiculos_Id);


        }
    }
}
