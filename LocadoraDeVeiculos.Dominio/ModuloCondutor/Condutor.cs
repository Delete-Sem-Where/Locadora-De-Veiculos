using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public class Condutor : EntidadeBase<Condutor>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string CPF { get; set; }
        public string CNH { get; set; }
        public DateTime ValidadeCNH { get; set; }
        public Cliente Cliente { get; set; }

        public override string ToString()
        {
            return $"{Nome} - CPF: {CPF}";
        }

        public Condutor Clonar()
        {
            return MemberwiseClone() as Condutor;
        }

        public override bool Equals(object? obj)
        {
            Condutor condutor = obj as Condutor;

            if (condutor == null)
                return false;

            return
                condutor.Id.Equals(Id) &&
                condutor.Nome.Equals(Nome) &&
                condutor.Email.Equals(Email) &&
                condutor.Telefone.Equals(Telefone) &&
                condutor.Endereco.Equals(Endereco) &&
                condutor.CPF.Equals(CPF) &&
                condutor.CNH.Equals(CNH) &&
                condutor.ValidadeCNH.Date.Equals(ValidadeCNH.Date) &&
                condutor.Cliente.Equals(Cliente);
        }
    }
}
