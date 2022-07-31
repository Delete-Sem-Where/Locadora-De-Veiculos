using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloFuncionario
{
    public class RepositorioFuncionarioOrm : IRepositorioFuncionario
    {
        private DbSet<Funcionario> funcionarios;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioFuncionarioOrm(LocadoraDeVeiculosDbContext dbContext)
        {
            funcionarios = dbContext.Set<Funcionario>();
            this.dbContext = dbContext;
        }

        public void Inserir(Funcionario novoRegistro)
        {
            funcionarios.Add(novoRegistro);
        }

        public void Editar(Funcionario registro)
        {
            funcionarios.Update(registro);
        }

        public void Excluir(Funcionario registro)
        {
            funcionarios.Remove(registro);
        }

        public List<Funcionario> SelecionarTodos()
        {
            return funcionarios.ToList();
        }

        public Funcionario SelecionarPorId(Guid id)
        {
            return funcionarios.SingleOrDefault(x => x.Id == id);
        }

        public Funcionario SelecionarFuncionarioPorNome(string nome)
        {
            return funcionarios.FirstOrDefault(x => x.Nome == nome);
        }

        public Funcionario SelecionarFuncionarioPorLogin(string usuario)
        {
            return funcionarios.FirstOrDefault(x => x.Login == usuario);
        }
    }
}
