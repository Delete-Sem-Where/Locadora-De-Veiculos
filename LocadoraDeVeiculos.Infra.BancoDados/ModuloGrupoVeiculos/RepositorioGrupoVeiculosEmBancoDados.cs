using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDados.ModuloGruposVeiculos
{
    public class RepositorioGrupoVeiculosEmBancoDados :
        RepositorioBase<GrupoVeiculos, ValidadorGrupoVeiculos, MapeadorGrupoVeiculos>,
        IRepositorioGrupoVeiculos
    {

        #region Sql Queries
        protected override string sqlInserir =>
            @"INSERT INTO [TBGRUPOVEICULOS] 
                (
                    [NOME]

	            )
	            VALUES
                (
                    @NOME

                );SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @"UPDATE [TBGRUPOVEICULOS]	
		        SET
			        [NOME] = @NOME
		        WHERE
			        [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBGRUPOVEICULOS]
		        WHERE
			        [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
		            [ID], 
		            [NOME]

	            FROM 
		            [TBGRUPOVEICULOS]";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
		            [ID], 
		            [NOME]

	            FROM 
		            [TBGRUPOVEICULOS]
		        WHERE
                    [ID] = @ID";

        #endregion
        public override ValidationResult Validar(GrupoVeiculos registro)
        {
            var validador = new ValidadorGrupoVeiculos();

            var resultadoValidacao = validador.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            var registroEncontradoNome = SelecionarTodos()
                .Select(x => x.Nome?.ToLower())
                .Contains(registro.Nome?.ToLower());

            if (registroEncontradoNome)
            {
                if (registro.Id == 0)
                    resultadoValidacao.Errors.Add(new ValidationFailure("", "Agrupamento de veículos já cadastrado"));
                else if (registro.Id != 0)
                {
                    resultadoValidacao.Errors.Add(new ValidationFailure("", "Agrupamento de veículos já cadastrado"));
                }
            }

            return resultadoValidacao;
        }

    }
}
