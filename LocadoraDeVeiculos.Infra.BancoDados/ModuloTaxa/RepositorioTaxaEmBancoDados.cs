using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;

namespace LocadoraDeVeiculos.Infra.BancoDados.ModuloTaxa
{
    public class RepositorioTaxaEmBancoDados : 
        RepositorioBase<Taxa, ValidadorTaxa, MapeadorTaxa>,        
        IRepositorioTaxa
    {
        
        #region Sql Queries
        protected override string sqlInserir =>
            @"INSERT INTO [TAXA] 
                (
                    [DESCRICAO],
                    [VALOR]

	            )
	            VALUES
                (
                    @DESCRICAO,
                    @VALOR

                );SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @"UPDATE [TAXA]	
		        SET
			        [DESCRICAO] = @DESCRICAO,
			        [VALOR] = @VALOR
		        WHERE
			        [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TAXA]
		        WHERE
			        [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
		            [ID], 
		            [DESCRICAO],
		            [VALOR]

	            FROM 
		            [TAXA]";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
		            [ID], 
		            [DESCRICAO],
		            [VALOR]

	            FROM 
		            [TAXA]
		        WHERE
                    [ID] = @ID";

        #endregion
        public override ValidationResult Validar(Taxa registro)
        {
            var validador = new ValidadorTaxa();

            var resultadoValidacao = validador.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            var registroEncontradoNome = SelecionarTodos()
                .Select(x => x.Descricao?.ToLower())
                .Contains(registro.Descricao?.ToLower());

            if (registroEncontradoNome)
            {
                if (registro.Id == 0)
                    resultadoValidacao.Errors.Add(new ValidationFailure("", "Taxa já cadastrado com esse Nome"));
                else if (registro.Id != 0)
                {
                    resultadoValidacao.Errors.Add(new ValidationFailure("", "Taxa já cadastrado com esse Nome"));
                }
            }

            return resultadoValidacao;
        }

    }
}
