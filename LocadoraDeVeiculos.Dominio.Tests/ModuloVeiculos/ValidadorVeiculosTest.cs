using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloVeiculos
{
    public class ValidadorVeiculosTest
    {

        private readonly Veiculos veiculo;
        private readonly ValidadorVeiculos validador;

            public ValidadorVeiculosTest ()
            {

                veiculo = new()
                {
                    Modelo = "Fusca 99",
                    Marca = "Volkswagen",
                    Ano = "2003",
                    Cor = "Azul",
                    Placa = "ABD5597",
                    QuilometroPercorrido = "2000",
                    CapacidadeTanque = "15",       
                    TipoCombustivel = "Gasolina"
                };
            
            validador = new ValidadorVeiculos();
        }

        #region MODELO
        [TestMethod]
        public void Modelo_deve_ser_obrigatorio()
        {
            veiculo.Modelo = null;

            var resultado = validador.TestValidate(veiculo);

            resultado.ShouldHaveValidationErrorFor(veiculo => veiculo.Modelo);
        }

        [TestMethod]
        public void Modelo_deve_ter_no_minimo_2_caracteres()
        {
            veiculo.Modelo = "A";

            var resultado = validador.TestValidate(veiculo);

            resultado.ShouldHaveValidationErrorFor(veiculo => veiculo.Modelo);
        }

        [TestMethod]
        public void Modelo_nao_deve_ter_caracteres_especiais()
        {
            veiculo.Modelo = "ASD$";

            var resultado = validador.TestValidate(veiculo);

            resultado.ShouldHaveValidationErrorFor(veiculo => veiculo.Modelo);
        }

        #endregion

        #region MARCA
        [TestMethod]
        public void Marca_deve_ser_obrigatorio()
        {
            veiculo.Marca = null;

            var resultado = validador.TestValidate(veiculo);

            resultado.ShouldHaveValidationErrorFor(veiculo => veiculo.Marca);
        }

        [TestMethod]
        public void Marca_deve_ter_no_minimo_2_caracteres()
        {
            veiculo.Marca = "V";

            var resultado = validador.TestValidate(veiculo);

            resultado.ShouldHaveValidationErrorFor(veiculo => veiculo.Marca);
        }

        [TestMethod]
        public void Marca_nao_deve_ter_caracteres_especiais_e_numeros()
        {
            veiculo.Marca = "E$23";

            var resultado = validador.TestValidate(veiculo);

            resultado.ShouldHaveValidationErrorFor(veiculo => veiculo.Marca);
        }

        #endregion

        #region ANO

        [TestMethod]
        public void Ano_deve_ser_obrigatorio()
        {
            veiculo.Ano = null;

            var resultado = validador.TestValidate(veiculo);

            resultado.ShouldHaveValidationErrorFor(veiculo => veiculo.Ano);
        }

        #endregion

        #region COR
        [TestMethod]
        public void Cor_deve_ser_obrigatorio()
        {
            veiculo.Cor = null;

            var resultado = validador.TestValidate(veiculo);

            resultado.ShouldHaveValidationErrorFor(veiculo => veiculo.Cor);
        }

        [TestMethod]
        public void Cor_deve_ter_no_minimo_3_caracteres()
        {
            veiculo.Cor = "A";

            var resultado = validador.TestValidate(veiculo);

            resultado.ShouldHaveValidationErrorFor(veiculo => veiculo.Cor);
        }

        [TestMethod]
        public void Cor_nao_deve_ter_caracteres_especiais_e_numeros()
        {
            veiculo.Cor = "@zul$";

            var resultado = validador.TestValidate(veiculo);

            resultado.ShouldHaveValidationErrorFor(veiculo => veiculo.Cor);
        }

        #endregion

        #region PLACA
        [TestMethod]
        public void Placa_deve_ser_obrigatorio()
        {
            veiculo.Placa = null;

            var resultado = validador.TestValidate(veiculo);

            resultado.ShouldHaveValidationErrorFor(veiculo => veiculo.Placa);
        }

        [TestMethod]
        public void Placa_deve_ter_7_caracteres()
        {
            veiculo.Placa = "A";

            var resultado = validador.TestValidate(veiculo);

            resultado.ShouldHaveValidationErrorFor(veiculo => veiculo.Placa);
        }

        [TestMethod]
        public void Placa_nao_deve_ter_caracteres_especiais()
        {
            veiculo.Placa = "ABCD1@7";

            var resultado = validador.TestValidate(veiculo);

            resultado.ShouldHaveValidationErrorFor(veiculo => veiculo.Placa);
        }

        [TestMethod]
        public void Placa_deve_ser_valida()
        {
            veiculo.Placa = "1234567";

            var resultado = validador.TestValidate(veiculo);

            resultado.ShouldHaveValidationErrorFor(veiculo => veiculo.Placa);
        }
        #endregion

        #region TIPO_COMBUSTIVEL
        [TestMethod]
        public void Tipo_de_combustivel_deve_ser_obrigatorio()
        {
            veiculo.TipoCombustivel = null;

            var resultado = validador.TestValidate(veiculo);

            resultado.ShouldHaveValidationErrorFor(veiculo => veiculo.TipoCombustivel);
        }

        #endregion

        #region CAPACIDADE_TANQUE
        [TestMethod]
        public void Capacidade_do_tanque_deve_ser_obrigatorio()
        {
            veiculo.TipoCombustivel = null;

            var resultado = validador.TestValidate(veiculo);

            resultado.ShouldHaveValidationErrorFor(veiculo => veiculo.TipoCombustivel);
        }

        #endregion

        #region GRUPO_VEICULOS
        /*
        [TestMethod]
        public void Grupo_de_veiculos_deve_ser_obrigatorio()
        {
            veiculo.Modelo = "Fusca 99";
            veiculo.Marca = "Volkswagen";
            veiculo.Ano = "2003";
            veiculo.Cor = "Azul";
            veiculo.Placa = "ABC7D12";
            veiculo.QuilometroPercorrido = "2000";
            veiculo.CapacidadeTanque = "13";
         //   veiculo.GrupoVeiculoss = null;
            veiculo.TipoCombustivel = "Gasolina";

            var resultado = validador.TestValidate(veiculo);

            resultado.ShouldHaveValidationErrorFor(veiculo => veiculo.Modelo);
        }
        */
        #endregion

        #region IMAGEM
        /*
        [TestMethod]
        public void Imagem_deve_ser_obrigatorio()
        {
            veiculo.Modelo = "Fusca 99";
            veiculo.Marca = "Volkswagen";
            veiculo.Ano = "2003";
            veiculo.Cor = "Azul";
            veiculo.Placa = "ABC0J97";
            veiculo.QuilometroPercorrido = "2000";
            veiculo.CapacidadeTanque = "13";

            veiculo.GrupoVeiculoss = gv;

            veiculo.TipoCombustivel = "Gasolina";

            veiculo.Imagem = null;


            var resultado = validador.TestValidate(veiculo);

            resultado.ShouldHaveValidationErrorFor(veiculo => veiculo.Modelo);

        }

       */
        #endregion

    }
}

