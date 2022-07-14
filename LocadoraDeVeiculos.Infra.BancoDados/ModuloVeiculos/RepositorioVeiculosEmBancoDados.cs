using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using LocadoraDeVeiculos.Infra.BancoDados.ModuloVeiculos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		       VEICULOS.[ID],
               VEICULOS.[MODELO],
               VEICULOS.[MARCA],
               VEICULOS.[ANO],
               VEICULOS.[COR],
               VEICULOS.[PLACA],
               VEICULOS.[TIPO_COMBUSTIVEL],
               VEICULOS.[QUILOMETRO_PERCORRIDO],
               VEICULOS.[CAPACIDADE_TANQUE],
               VEICULOS.[GRUPOVEICULOS_ID],
               
               GRUPOVEICULOS.[ID] GRUPOVEICULOS_ID,
               GRUPOVEICULOS.[NOME] GRUPOVEICULOS_NOME

            FROM [TBVEICULOS] AS VEICULOS

            INNER JOIN [TBGRUPOVEICULOS] AS GRUPOVEICULOS
                ON GRUPOVEICULOS.ID = VEICULO.GRUPOVEICULOS_ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
		        VEICULOS.[ID],
                VEICULOS.[MODELO],
                VEICULOS.[MARCA],
                VEICULOS.[ANO],
                VEICULOS.[COR],
                VEICULOS.[PLACA],
                VEICULOS.[TIPO_COMBUSTIVEL],
                VEICULOS.[QUILOMETRO_PERCORRIDO],
                VEICULOS.[CAPACIDADE_TANQUE],
                VEICULOS.[GRUPOVEICULOS_ID],

                GRUPOVEICULOS.[ID] GRUPOVEICULOS_ID,
                GRUPOVEICULOS.[NOME] GRUPOVEICULOS_NOME

            FROM [TBVEICULOS] AS VEICULOS

                INNER JOIN [TBGRUPOVEICULOS] AS GRUPOVEICULOS
                                            ON GRUPOVEICULOS.ID = VEICULOS.GRUPOVEICULOS_ID

            WHERE VEICULOS.ID = @ID";

        private string sqlSelecionarPorPlaca =>
            @"SELECT 
		       VEICULOS.[ID],
               VEICULOS.[MODELO],
               VEICULOS.[MARCA],
               VEICULOS.[ANO],
               VEICULOS.[COR],
               VEICULOS.[PLACA],
               VEICULOS.[TIPO_COMBUSTIVEL],
               VEICULOS.[QUILOMETRO_PERCORRIDO],
               VEICULOS.[CAPACIDADE_TANQUE],
               VEICULOS.[GRUPOVEICULOS_ID],

               GRUPOVEICULOS.[ID] GRUPOVEICULOS_ID,
               GRUPOVEICULOS.[NOME] GRUPOVEICULOS_NOME

            FROM [TBVEICULOS] AS VEICULOS

            INNER JOIN [TBGRUPOVEICULOS] AS GRUPOVEICULOS
                ON GRUPOVEICULOS.ID = VEICULOS.GRUPOVEICULOS_ID

            WHERE VEICULOS.PLACA = @PLACA
            ";


        public Veiculos SelecionarVeiculosPorPlaca(string placa)
        {
            return SelecionarPorParametro(sqlSelecionarPorPlaca, new SqlParameter("PLACA", placa));
        }
    }
}
