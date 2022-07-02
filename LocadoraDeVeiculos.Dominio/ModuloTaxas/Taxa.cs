﻿using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxas
{
    public class Taxa:EntidadeBase<Taxa>
    {
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }

        public override string ToString()
        {
            return $"Descrição: {Descricao}; Valor: {Valor};";
        }

        public Taxa Clonar()
        {
            return MemberwiseClone() as Taxa;
        }

        public override bool Equals(object? obj)
        {
            Taxa taxa = obj as Taxa;

            if (taxa == null)
                return false;

            return
                taxa.Id.Equals(Id) &&
                taxa.Descricao.Equals(Descricao) &&
                taxa.Valor.Equals(Valor);
        }
    }
}