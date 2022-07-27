using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using System.Data.SqlClient;


namespace LocadoraDeVeiculos.Infra.BancoDados.ModuloVeiculos
{
    public class RepositorioVeiculosEmBancoDados :
        RepositorioBase<Veiculos, MapeadorVeiculos>,
        IRepositorioVeiculos
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBVEICULOS] 
                (
                    [ID]
                   ,[MODELO]
                   ,[MARCA]
                   ,[ANO]
                   ,[COR]
                   ,[PLACA]
                   ,[TIPO_COMBUSTIVEL]
                   ,[QUILOMETRO_PERCORRIDO]
                   ,[CAPACIDADE_TANQUE]
                   ,[GRUPOVEICULOS_ID]
	            )
	            VALUES
                (
                     @ID
                    ,@MODELO
                    ,@MARCA
                    ,@ANO
                    ,@COR
                    ,@PLACA
                    ,@TIPO_COMBUSTIVEL
                    ,@QUILOMETRO_PERCORRIDO
                    ,@CAPACIDADE_TANQUE
                    ,@GRUPOVEICULOS_ID

                );";

        protected override string sqlEditar =>
            @"UPDATE [TBVEICULOS]	
		        SET
			        [MODELO] = @MODELO,
                    [MARCA] = @MARCA,
                    [ANO] = @ANO,
                    [COR] = @COR,
                    [PLACA] = @PLACA,
                    [TIPO_COMBUSTIVEL] = @TIPO_COMBUSTIVEL,
                    [QUILOMETRO_PERCORRIDO] = @QUILOMETRO_PERCORRIDO,
                    [CAPACIDADE_TANQUE] = @CAPACIDADE_TANQUE,
                    [GRUPOVEICULOS_ID] = @GRUPOVEICULOS_ID
		        WHERE
			        [ID] = @ID";
        protected override string sqlExcluir =>
            @"DELETE FROM [TBVEICULOS]
		        WHERE
			        [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
		         [ID]     VEICULO_ID,
                 [MODELO] VEICULO_MODELO,
                 [MARCA]  VEICULO_MARCA,
                 [ANO]    VEICULO_ANO,
                 [COR]    VEICULO_COR,
                 [PLACA]  VEICULO_PLACA,
                 [TIPO_COMBUSTIVEL] VEICULO_TIPO_COMBUSTIVEL,
                 [QUILOMETRO_PERCORRIDO] VEICULO_QUILOMETRO_PERCORRIDO,
                 [CAPACIDADE_TANQUE] VEICULO_CAPACIDADE_TANQUE,
                 [GRUPOVEICULOS_ID] VEICULO_GRUPOVEICULOS_ID            
            FROM 
                [TBVEICULOS]";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
		         [ID]     VEICULO_ID,
                 [MODELO] VEICULO_MODELO,
                 [MARCA]  VEICULO_MARCA,
                 [ANO]    VEICULO_ANO,
                 [COR]    VEICULO_COR,
                 [PLACA]  VEICULO_PLACA,
                 [TIPO_COMBUSTIVEL] VEICULO_TIPO_COMBUSTIVEL,
                 [QUILOMETRO_PERCORRIDO] VEICULO_QUILOMETRO_PERCORRIDO,
                 [CAPACIDADE_TANQUE] VEICULO_CAPACIDADE_TANQUE,
                 [GRUPOVEICULOS_ID] VEICULO_GRUPOVEICULOS_ID              
            FROM 
                [TBVEICULOS]
            WHERE 
                [ID] = @ID";

        private string sqlSelecionarPorPlaca =>
            @"SELECT 
		         [ID]     VEICULO_ID,
                 [MODELO] VEICULO_MODELO,
                 [MARCA]  VEICULO_MARCA,
                 [ANO]    VEICULO_ANO,
                 [COR]    VEICULO_COR,
                 [PLACA]  VEICULO_PLACA,
                 [TIPO_COMBUSTIVEL] VEICULO_TIPO_COMBUSTIVEL,
                 [QUILOMETRO_PERCORRIDO] VEICULO_QUILOMETRO_PERCORRIDO,
                 [CAPACIDADE_TANQUE] VEICULO_CAPACIDADE_TANQUE,
                 [GRUPOVEICULOS_ID] VEICULO_GRUPOVEICULOS_ID              
            FROM 
                [TBVEICULOS]
            WHERE 
                [PLACA] = @PLACA";

        public Veiculos SelecionarVeiculosPorPlaca(string placa)
        {
            return SelecionarPorParametro(sqlSelecionarPorPlaca, new SqlParameter("PLACA", placa));
        }
    }
}
