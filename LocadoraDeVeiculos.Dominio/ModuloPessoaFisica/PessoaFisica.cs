using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloPessoaFisica
{
    public class PessoaFisica : EntidadeBase<PessoaFisica>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string CPF { get; set; }
        public string CNH { get; set; }

        public PessoaFisica Clonar()
        {
            return MemberwiseClone() as PessoaFisica;
        }

        public override string ToString()
        {
            return $"{Nome} - CPF: {CPF}";
        }

        public override bool Equals(object? obj)
        {
            PessoaFisica pessoaFisica = obj as PessoaFisica;

            if (pessoaFisica == null)
                return false;

            return
                pessoaFisica.Id.Equals(Id) &&
                pessoaFisica.Nome.Equals(Nome) &&
                pessoaFisica.Email.Equals(Email) &&
                pessoaFisica.Telefone.Equals(Telefone) &&
                pessoaFisica.Endereco.Equals(Endereco) &&
                pessoaFisica.CPF.Equals(CPF) &&
                pessoaFisica.CNH.Equals(CNH);
        }

    }
}
