using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloPessoaFisica
{
    public interface IRepositorioPessoaFisica : IRepositorio<PessoaFisica>
    {
        PessoaFisica SelecionarPessoaFisicaPorNome(string nome);

        PessoaFisica SelecionarPessoaFisicaPorCPF(string cpf);
    }
}
