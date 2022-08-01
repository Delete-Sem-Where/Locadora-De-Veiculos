using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloCondutor
{
    public class RepositorioCondutorOrm : IRepositorioCondutor
    {
        private DbSet<Condutor> condutores;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioCondutorOrm(LocadoraDeVeiculosDbContext dbContext)
        {
            condutores = dbContext.Set<Condutor>();
            this.dbContext = dbContext;
        }

        public void Inserir(Condutor novoRegistro)
        {
            condutores.Add(novoRegistro);
        }

        public void Editar(Condutor registro)
        {
            condutores.Update(registro);
        }

        public void Excluir(Condutor registro)
        {
            condutores.Remove(registro);
        }

        public List<Condutor> SelecionarTodos()
        {
            return condutores.ToList();
        }

        public Condutor SelecionarPorId(Guid id)
        {
            return condutores.SingleOrDefault(x => x.Id == id);
        }

        public Condutor SelecionarCondutorPorNome(string nome)
        {
            return condutores.FirstOrDefault(x => x.Nome == nome);
        }

        public Condutor SelecionarCondutorPorCPF(string cpf)
        {
            return condutores.FirstOrDefault(x => x.CPF == cpf);
        }
    }
}
