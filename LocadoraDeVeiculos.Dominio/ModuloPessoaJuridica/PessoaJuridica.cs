using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloPessoaJuridica
{
    public class PessoaJuridica : EntidadeBase<PessoaJuridica>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string CNPJ { get; set; }

        public PessoaJuridica Clonar()
        {
            return MemberwiseClone() as PessoaJuridica;
        }

        public override bool Equals(object? obj)
        {
            PessoaJuridica funcionario = obj as PessoaJuridica;

            if (funcionario == null)
                return false;

            return
                funcionario.Id.Equals(Id) &&
                funcionario.Nome.Equals(Nome) &&
                funcionario.Email.Equals(Email) &&
                funcionario.Telefone.Equals(Telefone) &&
                funcionario.Endereco.Equals(Endereco) &&
                funcionario.CNPJ.Equals(CNPJ);
        }
    }
}
