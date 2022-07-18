using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using System.Data.SqlClient;


namespace LocadoraDeVeiculos.Infra.BancoDados.ModuloVeiculos
{
    public class MapeadorVeiculos : MapeadorBase<Veiculos>
    {
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
            comando.Parameters.AddWithValue("GRUPOVEICULOS_ID", novoVeiculo.GrupoVeiculos_Id);
        }
        public override Veiculos ConverterRegistro(SqlDataReader leitorRegistro)
        {
            Guid id = Guid.Parse(leitorRegistro["ID"].ToString());
            string modelo = Convert.ToString(leitorRegistro["MODELO"]);
            string marca = Convert.ToString(leitorRegistro["MARCA"]);
            string ano = Convert.ToString(leitorRegistro["ANO"]);
            string cor = Convert.ToString(leitorRegistro["COR"]);
            string placa = Convert.ToString(leitorRegistro["PLACA"]);
            string quilometroPercorrido = Convert.ToString(leitorRegistro["QUILOMETRO_PERCORRIDO"]);
            string capacidadeTanque = Convert.ToString(leitorRegistro["CAPACIDADE_TANQUE"]);
            string tipoCombustivel = Convert.ToString(leitorRegistro["TIPO_COMBUSTIVEL"]);
            Guid grupoVeiculos_Id = Guid.Parse(leitorRegistro["GRUPOVEICULOS_ID"].ToString());

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
                GrupoVeiculos_Id = grupoVeiculos_Id
            };            
        }
    }
}
