﻿using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloGruposVeiculos;
using System.Data.SqlClient;


namespace LocadoraDeVeiculos.Infra.BancoDados.ModuloVeiculos
{
    public class MapeadorVeiculos : MapeadorBase<Veiculos>
    {
        RepositorioGrupoVeiculosEmBancoDados repositorioGrupo = new RepositorioGrupoVeiculosEmBancoDados();
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
            comando.Parameters.AddWithValue("GRUPOVEICULOS_ID", novoVeiculo.GrupoVeiculos);
        }
        public override Veiculos ConverterRegistro(SqlDataReader leitorRegistro)
        {
            Guid id = Guid.Parse(leitorRegistro["VEICULO_ID"].ToString());
            string modelo = Convert.ToString(leitorRegistro["VEICULO_MODELO"]);
            string marca = Convert.ToString(leitorRegistro["VEICULO_MARCA"]);
            string ano = Convert.ToString(leitorRegistro["VEICULO_ANO"]);
            string cor = Convert.ToString(leitorRegistro["VEICULO_COR"]);
            string placa = Convert.ToString(leitorRegistro["VEICULO_PLACA"]);
            string quilometroPercorrido = Convert.ToString(leitorRegistro["VEICULO_QUILOMETRO_PERCORRIDO"]);
            string capacidadeTanque = Convert.ToString(leitorRegistro["VEICULO_CAPACIDADE_TANQUE"]);
            string tipoCombustivel = Convert.ToString(leitorRegistro["VEICULO_TIPO_COMBUSTIVEL"]);
            Guid grupoVeiculos_Id = Guid.Parse(leitorRegistro["VEICULO_GRUPOVEICULOS_ID"].ToString());

            return new Veiculos()
            {
                Id = id,
                Modelo = modelo,
                Marca = marca,
                Ano = ano,
                Cor = cor,
                Placa = placa,
                QuilometroPercorrido = quilometroPercorrido,
                CapacidadeTanque = capacidadeTanque,
                TipoCombustivel = tipoCombustivel,
                GrupoVeiculos = repositorioGrupo.SelecionarPorId(grupoVeiculos_Id)

            };            
        }
    }
}
