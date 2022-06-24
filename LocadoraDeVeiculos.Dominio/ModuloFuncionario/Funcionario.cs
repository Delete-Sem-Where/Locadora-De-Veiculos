using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloFuncionario
{
    public class Funcionario : EntidadeBase<Funcionario>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public double Salario { get; set; }
        public DateTime DataDeAdmissao { get; set; }

        public Funcionario()
        {
            DataDeAdmissao = DateTime.Now.Date;
        }

        public Funcionario Clonar()
        {
            return MemberwiseClone() as Funcionario;
        }

        public override bool Equals(object? obj)
        {
            Funcionario funcionario = obj as Funcionario;

            if (funcionario == null)
                return false;

            return
                funcionario.Id.Equals(Id) &&
                funcionario.Nome.Equals(Nome) &&
                funcionario.Email.Equals(Email) &&
                funcionario.Telefone.Equals(Telefone) &&
                funcionario.Endereco.Equals(Endereco) &&
                funcionario.Login.Equals(Login) &&
                funcionario.Senha.Equals(Senha) &&
                funcionario.Salario.Equals(Salario) &&
                funcionario.DataDeAdmissao.Equals(DataDeAdmissao);
        }
    }
}
