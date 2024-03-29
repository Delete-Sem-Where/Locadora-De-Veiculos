﻿using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloPessoaJuridica
{
    public interface IRepositorioPessoaJuridica : IRepositorio<PessoaJuridica>
    {
        PessoaJuridica SelecionarPessoaJuridicaPorNome(string nome);

        PessoaJuridica SelecionarPessoaJuridicaPorCNPJ(string cnpj);
    }
}
