using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloTaxa
{
    [TestClass]
    public class ValidadorTaxaTest
    {
        private readonly Taxa taxa;
        private readonly ValidadorTaxa validadorTaxa;

        public ValidadorTaxaTest()
        {
            taxa = new()
            {
                Descricao = "GPS",
                Valor = 10
            };

            validadorTaxa = new ValidadorTaxa();            
        }

        [TestMethod]
        public void Descricao_do_taxa_deve_ser_obrigatorio()
        {
            taxa.Descricao = null;
            var resultado = validadorTaxa.TestValidate(taxa);
            resultado.ShouldHaveValidationErrorFor(taxa => taxa.Descricao); 
        }

        [TestMethod]
        public void Nao_deve_inserir_taxa_com_menos_de_2_caracteres()
        {
            taxa.Descricao = "a";
            var resultado = validadorTaxa.TestValidate(taxa);
            resultado.ShouldHaveValidationErrorFor(taxa => taxa.Descricao);
        }
        
        [TestMethod]
        public void Descricao_deve_ser_valida()
        {
            taxa.Descricao = "/^^ç";
            var resultado = validadorTaxa.TestValidate(taxa);
            resultado.ShouldHaveValidationErrorFor(taxa => taxa.Descricao);
        }

        [TestMethod]
        public void Valor_da_taxa_deve_ser_obrigatorio()
        {
            taxa.Valor = -1;
            var resultado = validadorTaxa.TestValidate(taxa);
            resultado.ShouldHaveValidationErrorFor(taxa => taxa.Valor);
        }
    }
}
