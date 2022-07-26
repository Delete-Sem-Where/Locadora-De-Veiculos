using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public class Cliente : EntidadeBase<Cliente>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public TipoCliente TipoCliente { get; set; }
        public string Documento { get; set; }

        public Cliente Clonar()
        {
            return MemberwiseClone() as Cliente;
        }

        public override string ToString()
        {
            if(TipoCliente == TipoCliente.PessoaJuridica)
                return $"{Nome} - CNPJ: {CNPJ}";
            else
                return $"{Nome} - CPF: {CPF}";
        }

        public override bool Equals(object? obj)
        {
            Cliente cliente = obj as Cliente;

            if (cliente == null)
                return false;

            if(cliente.TipoCliente == TipoCliente.PessoaJuridica)
                    return
                        cliente.Id.Equals(Id) &&
                        cliente.Nome.Equals(Nome) &&
                        cliente.Email.Equals(Email) &&
                        cliente.Telefone.Equals(Telefone) &&
                        cliente.Endereco.Equals(Endereco) &&
                        cliente.CNPJ.Equals(CNPJ) &&
                        cliente.TipoCliente.Equals(TipoCliente);
            else 
                return
                    cliente.Id.Equals(Id) &&
                    cliente.Nome.Equals(Nome) &&
                    cliente.Email.Equals(Email) &&
                    cliente.Telefone.Equals(Telefone) &&
                    cliente.Endereco.Equals(Endereco) &&
                    cliente.CPF.Equals(CPF) &&
                    cliente.TipoCliente.Equals(TipoCliente);
        }
    }
}
